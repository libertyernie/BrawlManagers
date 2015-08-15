using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BrawlManagerLib {
    /// <summary>
    /// Allows read-only access to Custom SSS code, and read-only access to all Stage-Dependent Song Loader instances.
    /// This class will store the entire codeset, split between itself (the SSS code) and the portions before/after (in raw byte[]).
    /// </summary>
	public class CustomSSS {
		private static byte[] SDSL_HEADER = { 0x28, 0x70, 0x8c, 0xeb, 0x00, 0x00, 0x00 };
		private Dictionary<byte, Song> SongsByStage { get; set; }

        public byte[] sss1 { get; private set; }
		public byte[] sss2 { get; private set; }
		public byte[] sss3 { get; private set; }

		public byte[] DataBefore { get; private set; }
		public byte[] DataAfter { get; private set; }

		public int OtherCodesIgnoredInSameFile { get; private set; }
		public bool IgnoredMetadata { get; private set; }

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

		public CustomSSS() {
			init(new byte[0]);
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

		private CustomSSS(CustomSSS copyfrom, byte[] sss1, byte[] sss2, byte[] sss3) {
			this.SongsByStage = copyfrom.SongsByStage;
			this.sss1 = sss1;
			this.sss2 = sss2;
			this.sss3 = sss3;
			this.DataBefore = copyfrom.DataBefore;
			this.DataAfter = copyfrom.DataAfter;
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
			IgnoredMetadata = false;
			int index = -1;
			for (int line = 0; line < data.Length; line += 8) {
				if (ByteUtilities.ByteArrayEquals(data, line, SSS_HEADER, 0, SSS_HEADER.Length)) {
					if (index != -1) {
						OtherCodesIgnoredInSameFile++;
					}
					index = line;
				}
			}

			SongsByStage = new Dictionary<byte, Song>();

			if (index < 0 && data.Length > 0) {
				MessageBox.Show("No custom SSS code found. A default code will be used.");
				DataBefore = gctheader.ToArray();
				sss1 = ByteUtilities.StringToByteArray("00010203 04050709 080A0B0C 0D0E0F10 11141516 1A191217 0618131D 1E1B1C");
				sss2 = ByteUtilities.StringToByteArray("1F202122 23242526 2728");
				sss3 = ByteUtilities.StringToByteArray("01010202 03030404 05050606 07070808 0909330A 0B0B0C0C 0D0D0E0E 130F1410 " +
													   "15111612 17131814 19151C16 1D171E18 1F19201A 211B221C 231D241E 251F2932 " +
													   "15111612 2A332B34 2C352D36 2F373038 3139323A 2E3BFFFF");
				DataAfter = data.Skip(gctheader.Length).ToArray();
			} else {
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

				for (int line = 0; line < data.Length; line += 8) {
					if (ByteUtilities.ByteArrayEquals(data, line, SDSL_HEADER, 0, SDSL_HEADER.Length)) {
						byte stageID = data[line + 7];
						byte songID1 = data[line + 22];
						byte songID2 = data[line + 23];
						ushort songID = (ushort)(0x100 * songID1 + songID2);
						Song s = (from g in SongIDMap.Songs
								  where g.ID == songID
								  select g).First();
						if (SongsByStage.ContainsKey(stageID)) {
							Console.WriteLine(String.Format("WARNING: code mapping stage {0} to song {1} will not " +
								"take effect, since a later code maps it to song {2}", stageID, SongsByStage[stageID], s));
							SongsByStage.Remove(stageID);
						}
						SongsByStage.Add(stageID, s);
						line += 24;
					}
				}
			}

			bool footer_found = false;
			for (int i = 0; i < DataAfter.Length; i += 8) {
				if (footer_found) {
					IgnoredMetadata = true;
					DataAfter = DataAfter.Take(i).ToArray();
					break;
				} else {
					if (ByteUtilities.ByteArrayEquals(DataAfter, i, gctfooter, 0, 8)) {
						footer_found = true;
					}
				}
			}
		}

		public override string ToString() {
			return String.Format("Custom SSS: {0}/{1} stages, from pool of {2} pairs",
				sss1.Length, sss2.Length, sss3.Length / 2);
		}

		public bool TryGetValue(byte key, out Song value) {
			return SongsByStage.TryGetValue(key, out value);
		}
	}
}
