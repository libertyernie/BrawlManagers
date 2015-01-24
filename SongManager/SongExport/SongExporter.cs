using BrawlLib.SSBB.ResourceNodes;
using BrawlManagerLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BrawlSongManager.SongExport {
	
	/// <summary>
	/// Contains logic for exporting music song files to an easily editable 
	/// directory structure.
	/// </summary> 
	public class SongExporter {

		public bool ExportStageDirs { get; set; }

		private ProgressDialog prog;
		private SongEditor songEditor;

		public SongExporter() {
			prog = new ProgressDialog();
			songEditor = new SongEditor();
		}

		public void Export(string musicExportDir) {
			Console.WriteLine("Exporting music from: " + musicExportDir);
			prog.ClearLog();
			songEditor.PrepareResources();

			var confirmResult = MessageBox.Show(
				"About to export all songs in current directory to '" 
				+ musicExportDir + "'. Existing *.brstm files may be overwritten."
				+ "\nDo you want to continue?", 
				"Confirm Overwrite", MessageBoxButtons.OKCancel);
			if (confirmResult != DialogResult.OK) {
				return;
			}

			var exportDir = new DirectoryInfo(musicExportDir);

			prog.ProgressTitle = "Exporting songs...";
			prog.InProgressLabel = "Exporting songs...";
			prog.ProgressCompletionAt = 100;

			var bgw = SetupBackgroundExport(exportDir, prog);
			bgw.RunWorkerAsync();

			prog.ShowDialog();
		}

		private BackgroundWorker SetupBackgroundExport(DirectoryInfo exportDir, ProgressDialog prog) {
			BackgroundWorker bgw = new BackgroundWorker();
			bgw.DoWork += (object sender, DoWorkEventArgs e) => {
				ExportSongs(exportDir, sender as BackgroundWorker);
			};
			bgw.WorkerReportsProgress = true;
			bgw.ProgressChanged += (object sender, ProgressChangedEventArgs e) => {
				prog.Progress = e.ProgressPercentage;
				if (e.UserState != null) {
					prog.InProgressLabel = (string)e.UserState;
				}
			};
			bgw.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) => {
				prog.Progress = 100;
				Log("");
				if (e.Error != null) {
					Log("Error exporting songs." + e.Error.Message);
				} else {
					Log("Completed export!");
				}
			};
			return bgw;
		}

		private void ExportSongs(DirectoryInfo exportDir, BackgroundWorker bgw) {
			object[] stageSongs = SongsByStage.FromCurrentDir;

			HashSet<string> filenamesAdded = new HashSet<string>();
			string currentDir = exportDir.FullName;
			for (int i = 0; i < stageSongs.Length; i++) {
				bgw.ReportProgress(i * 100 / stageSongs.Length);
				object curObj = stageSongs[i];
				if (curObj is string) {
					string cur = (string)curObj;
					bgw.ReportProgress(i * 100 / stageSongs.Length, "Exporting songs for stage: " + cur);
					cur = FileOperations.SantizeFilename(cur);
					if (ExportStageDirs) {
						currentDir = exportDir.CreateSubdirectory(cur).FullName;
					}
				} else if (curObj is SongInfo) {
					SongInfo cur = (SongInfo)curObj;
					ExportSong(currentDir, cur);
					filenamesAdded.Add(cur.File.Name);
				}
			}
		}

		private void ExportSong(string currentDir, SongInfo cur) {
			string srcName = Path.GetFileNameWithoutExtension(cur.File.Name);
			Song song = songEditor.ReadSong(srcName);
			if (song == null) {
				Log("Skipped unknown song: " + cur.File.FullName);
				return;
			}

			string vol = "0";
			if (song.DefaultVolume.HasValue) {
				vol = song.DefaultVolume.Value.ToString();
			}
			string title = FileOperations.SantizeFilename(song.DefaultName);
			string destFilename = srcName + "." + vol + "." + title + cur.File.Extension;
			string dest = Path.Combine(currentDir, destFilename);

			if (cur.File.Exists) {
				File.Copy(cur.File.FullName, dest, true);
			} else {
				// Create an empty placeholder file.
				File.Create(dest).Dispose();
			}
		}

		private void Log(string message) {
			if (prog.InvokeRequired) {
				prog.BeginInvoke((Action)(() => { prog.AppendLogLine(message); }));
			} else {
				prog.AppendLogLine(message);
			}
		}
	}
}
