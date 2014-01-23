using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlManagerLib {
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
