using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BrawlManagerLib {
	public class TempFiles {
		//private static Stack<string> tempFiles = new Stack<string>();
		public static bool Printout = true;

		static TempFiles() {
			string p = Path.Combine(Path.GetTempPath(), "StageManager");
			if (Directory.Exists(p)) {
				try {
					Directory.Delete(p, true);
				} catch (IOException) {
					Console.WriteLine("could not clear out " + p + " (files probably in use)");
				}
			}
			Directory.CreateDirectory(p);
		}

		public static string Create() {
			return Create(".dat");
		}

		public static string Create(string extension) {
			if (!extension.StartsWith(".")) extension = "." + extension;
			string f = Path.Combine(Path.GetTempPath(), "StageManager", Guid.NewGuid() + extension);
			//tempFiles.Push(f);
			if (Printout) Console.WriteLine("Returning path: " + f);
			return f;
		}

		public static void TryToDeleteAll() {
			foreach (string s in Directory.EnumerateFiles(Path.Combine(Path.GetTempPath(), "StageManager"))) {
				try {
					File.Delete(s);
				} catch (Exception e) {
					Console.WriteLine(s + ": " + e.Message);
				}
			}
			/*while (tempFiles.Any()) {
				string s = tempFiles.Pop();
				try {
					File.Delete(s);
				} catch (Exception e) {
					Console.WriteLine(s + ": " + e.Message);
				}
			}*/
		}
	}
}
