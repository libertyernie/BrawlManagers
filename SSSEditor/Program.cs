using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSSEditor {
	static class Program {
		private static string gct, pac;
		private static void findFiles(string[] args) {
			args = args ?? new string[0];
			gct = args.Length > 0 ? args[0]
				: File.Exists(@"data\gecko\codes\RSBE01.gct") ? @"data\gecko\codes\RSBE01.gct"
				: File.Exists(@"codes\RSBE01.gct") ? @"codes\RSBE01.gct"
				: null;
			pac = args.Length > 1 ? args[1]
				: File.Exists(@"private\wii\app\RSBE\pf\system\common5.pac") ? @"private\wii\app\RSBE\pf\system\common5.pac"
				: File.Exists(@"projectm\pf\system\common5.pac") ? @"projectm\pf\system\common5.pac"
				: File.Exists(@"minusery\pf\system\common5.pac") ? @"minusery\pf\system\common5.pac"
				: null;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try {
				accessLibraries();
			} catch (Exception e) {
				MessageBox.Show(null, e.Message, e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			findFiles(args);

			if (gct == null && pac == null) {
				using (var dialog = new FolderBrowserDialog()) {
					dialog.Description = "Select the SD card root in the tree below.\n" +
						"To choose RSBE01.gct and common5.pac separately instead, press Cancel.";
					if (dialog.ShowDialog() == DialogResult.OK) {
						Environment.CurrentDirectory = dialog.SelectedPath;
						findFiles(null);
					}
				}
			}

			if (gct == null) using (var dialog = new OpenFileDialog()) {
				dialog.Title = "Open GCT codeset";
				dialog.Filter = "Ocarina codes (*.gct, *.txt)|*.gct;*.txt";
				dialog.Multiselect = false;
				if (dialog.ShowDialog() == DialogResult.OK) {
					gct = dialog.FileName;
				} else {
					return;
				}
			}
			if (pac == null) using (var dialog = new OpenFileDialog()) {
				dialog.Title = "Open stage icon file (common5)";
				dialog.Filter = "Brawl data files (*.pac, *.brres)|*.pac;*.brres";
				dialog.Multiselect = false;
				if (dialog.ShowDialog() == DialogResult.OK) {
					pac = dialog.FileName;
				} else {
					return;
				}
			}

			Application.Run(new SSSEditorForm(gct, pac));
		}

		private static void accessLibraries() {
			var D = BrawlLib.Properties.Settings.Default;
			if (D.GetType().GetProperty("HideMDL0Errors") != null) {
				D.GetType().InvokeMember("HideMDL0Errors", System.Reflection.BindingFlags.SetProperty, null, D, new object[] { true });
			}
			var Q = new BrawlManagerLib.CollapsibleSplitter();
		}
	}
}
