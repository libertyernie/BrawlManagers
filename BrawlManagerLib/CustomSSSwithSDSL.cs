using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlManagerLib {
    /// <summary>
    /// Allows read-write access to Custom SSS code, and read-only access to all Stage-Dependent Song Loader instances.
    /// This class will store the entire codeset, split between itself (the SSS code) and the portions before/after (in raw byte[]).
    /// </summary>
	public class CustomSSSwithSDSL : CustomSSS {
		public CustomSSSwithSDSL(string[] s) : base(s) {
			SongsByStage = SDSLScanner.SongsByStage(this);
		}
		public CustomSSSwithSDSL(byte[] data) : base(data) {
			SongsByStage = SDSLScanner.SongsByStage(this);
		}
		public CustomSSSwithSDSL(string filename) : base(filename) {
			SongsByStage = SDSLScanner.SongsByStage(this);
		}

		public Dictionary<byte, Song> SongsByStage { get; private set; }
	}
}
