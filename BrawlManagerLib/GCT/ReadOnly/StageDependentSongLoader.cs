using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlManagerLib {
	/// <summary>
	/// Allows read-only access to all Stage-Dependent Song Loader instances in a GCT codeset.
	/// </summary>
	public class StageDependentSongLoader {
		private static byte[] SDSL_HEADER = { 0x28, 0x70, 0x8c, 0xeb, 0x00, 0x00, 0x00 };

		private Dictionary<byte, Song> SongsByStage { get; set; }

		public StageDependentSongLoader(byte[] data) {
			SongsByStage = new Dictionary<byte, Song>();

			for (int line = 0; line < data.Length; line += 8) {
				if (ByteUtilities.ByteArrayEquals(data, line, SDSL_HEADER, 0, SDSL_HEADER.Length)) {
					byte stageID = data[line + 7];
					byte songID1 = data[line + 22];
					byte songID2 = data[line + 23];
					ushort songID = (ushort)(0x100 * songID1 + songID2);
					Song s = (from g in SongIDMap.Songs
							  where g.ID == songID
							  select g).FirstOrDefault();
					if (s != null) {
						if (SongsByStage.ContainsKey(stageID)) {
							Console.WriteLine(String.Format("WARNING: code mapping stage {0} to song {1} will not " +
								"take effect, since a later code maps it to song {2}", stageID, SongsByStage[stageID], s));
							SongsByStage.Remove(stageID);
						}
						SongsByStage.Add(stageID, s);
						line += 24;
					} else {
						Console.WriteLine("Unknown song ID " + songID.ToString("X4") + " - not currently supported.");
					}
				}
			}
		}

		public bool TryGetSong(byte key, out Song value) {
			return SongsByStage.TryGetValue(key, out value);
		}
	}
}
