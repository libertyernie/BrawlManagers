using BrawlLib.SSBB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BrawlManagerLib {
    public class CNMT {
        public readonly Dictionary<ushort, string> Map;

        public CNMT(byte[] data) {
            Map = new Dictionary<ushort, string>();
            for (int lineskip = 0; lineskip < data.Length; lineskip += 8) {
                if (data[lineskip] != 0x06) continue;

                int id = data[lineskip + 1] << 16
                    | data[lineskip + 2] << 8
                    | data[lineskip + 3];

                int songId = (id - 4031616) / 144;
                if (songId < 0x286C || songId > 0x2BBD) continue;

                if (data[lineskip + 4] != 0x00) continue;
                if (data[lineskip + 5] != 0x00) continue;
                if (data[lineskip + 6] != 0x00) continue;

                int bytes = data[lineskip + 7];

                char[] charArray = data
                    .Skip(lineskip)
                    .Skip(8)
                    .Take(bytes)
                    .Select(b => (char)b)
                    .ToArray();
                Map.Add((ushort)songId, new string(charArray));
            }
        }
    }
}
