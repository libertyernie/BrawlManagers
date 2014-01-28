using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThreeFrontStnameGenerator {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static int Main(string[] args) {
			using (var dialog = new ThreeStageFrontStnameDialog()) {
				if (args.Length == 0) {
					MessageBox.Show("Usage: [program.exe] [filename.png]\nName this program genname.exe and put it in the same folder as BrawlStageManager.exe.");
					dialog.Text = "Demo";
					dialog.ShowDialog();
					return 0;
				}

				if (dialog.ShowDialog() == DialogResult.OK) {
					Bitmap bmp = dialog.Bitmap;
					bmp.Save(args[0]);
					return 0;
				} else {
					return 1;
				}
			}
		}
	}
}
