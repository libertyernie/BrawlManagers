using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlManagerLib.ReadOnly {
	public class AlternateStageLoaderData {
		public class AlternateStageDefinition {
			public IEnumerable<Alternate> Random { get; set; }
			public IEnumerable<Alternate> ButtonActivated { get; set; }
		}

		public class Alternate {
			public ushort ButtonMask { get; set; }
			public char Letter { get; set; }
		}

		private static byte[] HEADER_BRAWL = {
			0x46, 0x00, 0x00, 0x10,
			0x00, 0x00, 0x00, 0x00,
			0x44, 0x00, 0x00, 0x00,
			0x00, 0x5A, 0x7D, 0x00};
		private static byte[] HEADER_PM36 = {
			0x46, 0x00, 0x00, 0x10,
			0x00, 0x00, 0x00, 0x00,
			0x44, 0x00, 0x00, 0x00,
			0x00, 0x5A, 0x7C, 0xB0};

		private Dictionary<string, AlternateStageDefinition> AlternatesByStage { get; set; }

		public AlternateStageLoaderData(byte[] data) {
			AlternatesByStage = new Dictionary<string, AlternateStageDefinition>();

			for (int index = 0; index < data.Length; index += 8) {
				if (ByteUtilities.ByteArrayEquals(data, index, HEADER_BRAWL, 0, HEADER_BRAWL.Length) || ByteUtilities.ByteArrayEquals(data, index, HEADER_PM36, 0, HEADER_PM36.Length)) {
					int countbyte = data[index + 19];
					index += 24;
					int endIndex = index + (8 * countbyte) - 8;
					while (index < endIndex) {
						char[] name = new char[4];
						name[0] = (char)data[index];
						name[1] = (char)data[index+1];
						name[2] = (char)data[index+2];
						name[3] = (char)data[index+3];

						int buttonActivatedCount = data[index + 4];
						int randomCount = data[index + 5];

						index += 8;

						List<Alternate> buttonActivated = new List<Alternate>();
						for (int j = 0; j < buttonActivatedCount; j++) {
							int buttonMask = data[index] << 8 + data[index + 1];
							char letter = (char)('A' + data[index + 3]);

							buttonActivated.Add(new Alternate {
								ButtonMask = (ushort)buttonMask,
								Letter = letter
							});

							index += 8;
						}

						List<Alternate> random = new List<Alternate>();
						for (int j = 0; j < randomCount; j++) {
							char letter = (char)('A' + j);
							random.Add(new Alternate {
								Letter = letter,
								ButtonMask = 0
							});
						}

						AlternatesByStage.Add(new string(name), new AlternateStageDefinition {
							Random = random,
							ButtonActivated = buttonActivated
						});
					}
					break;
				}
			}
		}

		public bool TryGetDefinition(string key, out AlternateStageDefinition value) {
			key = (key + "    ").Substring(0, 4).ToUpperInvariant();
			return AlternatesByStage.TryGetValue(key, out value);
		}
	}
}
