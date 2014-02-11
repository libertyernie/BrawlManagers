using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using BrawlStageManager.RegistryUtilities;

namespace BrawlStageManager {
	public static class Program {
		private static MainForm form;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			if (args.Length > 0) if (args[0] == "--help" || args[0] == "/c") {
				Console.WriteLine(BSMHelp());
				return;
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try {
				accessLibraries();
			} catch (Exception e) {
				MessageBox.Show(null, e.Message, e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string dir = null;
			bool useRelDescription = true;
			foreach (string arg in args) {
				if (arg == "/d") {
					useRelDescription = true;
				} else if (arg == "/D") {
					useRelDescription = false;
				} else if (new DirectoryInfo(arg).Exists) {
					dir = arg;
				}
			}
			if (dir == null) {
				dir = DefaultDirectory.GetIfExists()
					?? System.IO.Directory.GetCurrentDirectory();
			}

			form = new MainForm(dir, useRelDescription);
			Application.Run(form);
		}

		private static void accessLibraries() {
			var D = BrawlLib.Properties.Settings.Default;
			if (D.GetType().GetProperty("HideMDL0Errors") != null) {
				D.GetType().InvokeMember("HideMDL0Errors", System.Reflection.BindingFlags.SetProperty, null, D, new object[] { true });
			}
			var Q = new BrawlManagerLib.CollapsibleSplitter();
		}

		private static string BSMHelp() {
			return "Usage: " + Process.GetCurrentProcess().ProcessName + " [args] [path to stage/melee folder]\n" +
				"\n" +
				"Arguments:\n" +
				"  /d  Show .rel description (default)\n" +
				"  /D  Show .rel original filename";
		}
	}
}
