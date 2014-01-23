using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlManagerLib {
	public class Song {
		public string DefaultName { get; private set; }
		public string Filename { get; private set; }
		public int? InfoPacIndex { get; private set; }
		public ushort ID { get; private set; }

		public Song(string name, string filename, int id, int? infoPacIndex) {
			DefaultName = name;
			Filename = filename;
			InfoPacIndex = infoPacIndex;
			ID = (ushort)id;
		}
	}
}
