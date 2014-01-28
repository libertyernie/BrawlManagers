using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreeFrontStnameGenerator {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static int Main() {
			using (var dialog = new ThreeStageFrontStnameDialog()) {
				if (dialog.ShowDialog() == DialogResult.OK) {
					Bitmap bmp = dialog.Bitmap;
					Stream stream = System.Console.OpenStandardOutput();
					bmp.Save(stream, ImageFormat.Png);
					return 0;
				} else {
					return 1;
				}
			}
		}
	}
}
