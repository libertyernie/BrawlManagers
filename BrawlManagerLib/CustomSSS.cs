using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BrawlManagerLib {
	public class CustomSSS {
		public byte[] sss1 { get; private set; }
		public byte[] sss2 { get; private set; }
		public byte[] sss3 { get; private set; }

		public byte[] DataBefore { get; private set; }
		public byte[] DataAfter { get; private set; }

		public int OtherCodesIgnoredInSameFile { get; private set; }

		public Tuple<byte, byte> this[int index] {
			get {
				return new Tuple<byte, byte>(sss3[2 * index], sss3[2 * index + 1]);
			}
		}

		private Tuple<byte[], byte[]> _iconsInGroups;
		public Tuple<byte[], byte[]> IconsInGroups {
			get {
				if (_iconsInGroups == null) {
					byte[] b1 = new byte[sss1.Length];
					for (int i = 0; i < b1.Length; i++) {
						b1[i] = sss3[sss1[i] * 2 + 1];
					}
					byte[] b2 = new byte[sss2.Length];
					for (int i = 0; i < b2.Length; i++) {
						b2[i] = sss3[sss2[i] * 2 + 1];
					}
					_iconsInGroups = new Tuple<byte[], byte[]>(b1, b2);
				}
				return _iconsInGroups;
			}
		}

		private byte[] _stageIDsInOrder;
		public byte[] StageIDsInOrder {
			get {
				if (_stageIDsInOrder == null) {
					_stageIDsInOrder = new byte[sss1.Length + sss2.Length];
					for (int i = 0; i < sss1.Length; i++) {
						_stageIDsInOrder[i] = sss3[sss1[i] * 2];
					}
					for (int i = 0; i < sss2.Length; i++) {
						_stageIDsInOrder[sss1.Length + i] = sss3[sss2[i] * 2];
					}
				}
				return _stageIDsInOrder;
			}
		}

		public byte IconForStage(int stage_id) {
			for (int i = 0; i < sss3.Length; i += 2) {
				if (sss3[i] == stage_id) {
					return sss3[i + 1];
				}
			}
			return 0xFF;
		}

		public byte StageForIcon(int icon_id) {
			for (int i = 0; i < sss3.Length; i += 2) {
				if (sss3[i + 1] == icon_id) {
					return sss3[i];
				}
			}
			return 0xFF;
		}

		public CustomSSS(string[] s) {
			init(s);
		}

		public CustomSSS(byte[] data) {
			init(data);
		}

		public CustomSSS(string filename) {
			if (filename.EndsWith("gct", StringComparison.InvariantCultureIgnoreCase)) {
				init(File.ReadAllBytes(filename));
			} else {
				init(File.ReadAllLines(filename));
			}
		}

		private static byte[] gctheader = { 0x00, 0xd0, 0xc0, 0xde, 0x00, 0xd0, 0xc0, 0xde };
		private static byte[] gctfooter = { 0xf0, 0, 0, 0, 0, 0, 0, 0 };
		private void init(string[] s) {
			Regex r = new Regex(@"(\* )?[A-Fa-f0-9]{8} [A-Fa-f0-9]{8}");
			var matching_lines =
				from line in s
				where r.IsMatch(line)
				select line;

			byte[] core = ByteUtilities.StringToByteArray(string.Join("\n", matching_lines));
			byte[] data = new byte[core.Length + 16];
			Array.ConstrainedCopy(gctheader, 0, data, 0, 8);
			Array.ConstrainedCopy(core, 0, data, 8, core.Length);
			Array.ConstrainedCopy(gctfooter, 0, data, data.Length - 8, 8);
			init(data);
		}

		private static byte[] SSS_HEADER = ByteUtilities.StringToByteArray("046b8f5c 7c802378");
		private void init(byte[] data) {
			OtherCodesIgnoredInSameFile = 0;
			int index = -1;
			for (int line = 0; line < data.Length; line += 8) {
				if (ByteUtilities.ByteArrayEquals(data, line, SSS_HEADER, 0, SSS_HEADER.Length)) {
					if (index != -1) {
						OtherCodesIgnoredInSameFile++;
					}
					index = line;
				}
			}

			if (index < 0) {
				MessageBox.Show("No custom SSS code found. A default code will be used.");
				DataBefore = data.ToArray();
				sss1 = ByteUtilities.StringToByteArray("00010203 04050709 080A0B0C 0D0E0F10 11141516 1A191217 0618131D 1E1B1C00");
				sss2 = ByteUtilities.StringToByteArray("1F202122 23242526 2728");
				sss3 = ByteUtilities.StringToByteArray("01010202 03030404 05050606 07070808 0909330A 0B0B0C0C 0D0D0E0E 130F1410 " +
													   "15111612 17131814 19151C16 1D171E18 1F19201A 211B221C 231D241E 251F2932 " +
													   "15111612 2A332B34 2C352D36 2F373038 3139323A 2E3BFFFF");
				DataAfter = new byte[0];
				return;
			}

			int start = index;
			DataBefore = new byte[start];
			Array.ConstrainedCopy(data, 0, DataBefore, 0, start);

			index += 14 * 8;
			byte sss1_count = data[index - 1];
			sss1 = new byte[sss1_count];
			Array.ConstrainedCopy(data, index, sss1, 0, sss1_count);

			index += sss1_count;
			while (index % 8 != 0) index++;

			index += 2 * 8;
			byte sss2_count = data[index - 1];
			sss2 = new byte[sss2_count];
			Array.ConstrainedCopy(data, index, sss2, 0, sss2_count);

			index += sss2_count;
			while (index % 8 != 0) index++;

			index += 1 * 8;
			byte sss3_count = data[index - 1];
			sss3 = new byte[sss3_count];
			Array.ConstrainedCopy(data, index, sss3, 0, sss3_count);

			index += sss3_count;
			while (index % 8 != 0) index++;

			DataAfter = new byte[data.Length - index];
			Array.ConstrainedCopy(data, index, DataAfter, 0, data.Length - index);
		}

		public override string ToString() {
			return String.Format("Custom SSS: {0}/{1} stages, from pool of {2} pairs",
				sss1.Length, sss2.Length, sss3.Length / 2);
		}
	}
}
