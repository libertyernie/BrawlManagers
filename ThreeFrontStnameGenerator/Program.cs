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
					dialog.Text = "Demo";
				}
				if (dialog.ShowDialog() == DialogResult.OK) {
					Bitmap bmp = dialog.Bitmap;
					if (args.Length == 0) {
						using (SaveFileDialog d = new SaveFileDialog()) {
							if (d.ShowDialog() == DialogResult.OK) {
								bmp.Save(d.FileName);
							}
						}
					} else {
						bmp.Save(args[0]);
					}
					return 0;
				} else {
					return 1;
				}
			}
		}
	}
}
