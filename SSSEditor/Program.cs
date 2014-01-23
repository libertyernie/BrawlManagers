using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSSEditor {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var D = BrawlLib.Properties.Settings.Default;
			if (D.GetType().GetProperty("HideMDL0Errors") != null) {
				D.GetType().InvokeMember("HideMDL0Errors", System.Reflection.BindingFlags.SetProperty, null, D, new object[] { true });
			}

			string gct = args.Length > 0 ? args[0]
				: File.Exists(@"data\gecko\codes\RSBE01.gct") ? @"data\gecko\codes\RSBE01.gct"
				: File.Exists(@"codes\RSBE01.gct") ? @"codes\RSBE01.gct"
				: null;
			string pac = args.Length > 1 ? args[1]
				: File.Exists(@"private\wii\app\RSBE\pf\system\common5.pac") ? @"private\wii\app\RSBE\pf\system\common5.pac"
				: File.Exists(@"projectm\pf\system\common5.pac") ? @"projectm\pf\system\common5.pac"
				: File.Exists(@"minusery\pf\system\common5.pac") ? @"minusery\pf\system\common5.pac"
				: null;

			if (gct == null) using (var dialog = new OpenFileDialog()) {
				dialog.Filter = "Ocarina codes (*.gct, *.txt)|*.gct;*.txt";
				dialog.Multiselect = false;
				if (dialog.ShowDialog() == DialogResult.OK) {
					gct = dialog.FileName;
				} else {
					return;
				}
			}
			if (pac == null) using (var dialog = new OpenFileDialog()) {
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
	}
}
