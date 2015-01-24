using BrawlLib.SSBB.ResourceNodes;
using BrawlManagerLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BrawlSongManager.SongExport {
	class SongEditor {
		static readonly string[] GCT_PATHS = {
			"RSBE01.gct",
			"/data/gecko/codes/RSBE01.gct",
			"/codes/RSBE01.gct",
			"../../../../codes/RSBE01.gct",
		};
		static readonly string[] MUM_PATHS = { 
			"../../menu2/mu_menumain.pac",
			"../../menu2/mu_menumain_en.pac",
			"../../../pfmenu2/mu_menumain.pac",
			"../../../pfmenu2/mu_menumain_en.pac"
		};
		static readonly string[] INFO_PATHS = {
			"..\\..\\info2\\info.pac",
			"..\\..\\info2\\info_en.pac",
			"..\\info.pac"
		};
		static readonly string[] TRNG_PATHS = {
			"..\\..\\info2\\info_training.pac",
			"..\\..\\info2\\info_training_en.pac",
			"..\\info_training.pac"
		};

		// MU_MenuMain Details
		private string mumPath;
		private MSBinNode mumMsbn;

		// INFO Details
		private string infoPath;
		private MSBinNode infoMsbn;

		// TRNG Details
		private string trngPath;
		private MSBinNode trngMsbn;

		// Volume Details
		private string gctPath;
		private CustomSongVolume gctCsv;

		public SongEditor() {

		}

		public void PrepareResources() {
			PrepareMUM();
			PrepareINFO();
			PrepareTRNG();
			PrepareGCT();
		}

		public Song ReadSong(string filename) {
			Song mapSong = GetDefaultSong(filename);
			if (mapSong == null) {
				return null;
			}
			return UpdateSongFromFileData(mapSong);
		}

		public Song GetDefaultSong(string filename) {
			return (from s in SongIDMap.Songs
					where s.Filename == filename
					select s).FirstOrDefault();
		}

		public void WriteSong(Song song) {
			if (song.InfoPacIndex.HasValue) {
				mumMsbn._strings[song.InfoPacIndex.Value] = song.DefaultName;
				mumMsbn.SignalPropertyChange();
				infoMsbn._strings[song.InfoPacIndex.Value] = song.DefaultName;
				infoMsbn.SignalPropertyChange();
				trngMsbn._strings[song.InfoPacIndex.Value] = song.DefaultName;
				trngMsbn.SignalPropertyChange();
			}
			if (song.DefaultVolume.HasValue) {
				gctCsv.Settings[song.ID] = song.DefaultVolume.Value;
			}
		}

		public void SaveResources() {
			SaveMUM();
			SaveINFO();
			SaveTRNG();
			SaveGCT();
		}

		private Song UpdateSongFromFileData(Song song) {
			string title = song.DefaultName;
			if (song.InfoPacIndex.HasValue) {
				title = mumMsbn._strings[song.InfoPacIndex.Value];
			}

			byte? volume = song.DefaultVolume;
			if (gctCsv.Settings.ContainsKey(song.ID)) {
				volume = gctCsv.Settings[song.ID];
			}

			return new Song(title, song.Filename, song.ID, volume, song.InfoPacIndex);
		}

		private void PrepareMUM() {
			mumPath = FindFile(MUM_PATHS);
			mumMsbn = LoadPacMsbn(mumPath, "MiscData[7]");
		}

		private void SaveMUM() {
			mumMsbn.Rebuild();
			SavePacMsbn(mumMsbn, mumPath, "MiscData[7]");
		}

		private void PrepareINFO() {
			infoPath = FindFile(INFO_PATHS);
			infoMsbn = LoadPacMsbn(infoPath, "MiscData[140]");
		}

		private void SaveINFO() {
			infoMsbn.Rebuild();
			SavePacMsbn(infoMsbn, infoPath, "MiscData[140]");
		}

		private void PrepareTRNG() {
			trngPath = FindFile(TRNG_PATHS);
			trngMsbn = LoadPacMsbn(trngPath, "MiscData[140]");
		}

		private void SaveTRNG() {
			trngMsbn.Rebuild();
			SavePacMsbn(trngMsbn, trngPath, "MiscData[140]");
		}

		private void PrepareGCT() {
			gctPath = FindFile(GCT_PATHS);
			gctCsv = new CustomSongVolume(File.ReadAllBytes(gctPath));
			int ct = gctCsv.Settings.Count;
			Console.WriteLine("Loaded Custom Song Volume (" + ct + " settings)");
		}

		private void SaveGCT() {
			File.WriteAllBytes(gctPath, gctCsv.ExportGCT());
		}

		private MSBinNode LoadPacMsbn(string path, string childNodeName) {
			using (ResourceNode node = NodeFactory.FromFile(null, path)) {
				var childNode = node.FindChild(childNodeName, true) as MSBinNode;
				if (childNode == null) {
					throw new Exception("Node '" + childNodeName + "' not found in '" + path + "'");
				}
				return childNode;
			}
		}

		private void SavePacMsbn(MSBinNode msbn, string pacPath, string childNodeName) {
			string tmpPac = Path.GetTempFileName();
			string tmpMsbn = Path.GetTempFileName();
			msbn.Export(tmpMsbn);
			File.Copy(pacPath, tmpPac, true);

			using (ResourceNode tmpPacNode = NodeFactory.FromFile(null, tmpPac)) {
				MSBinNode tmpPacChildNode = tmpPacNode.FindChild(childNodeName, true) as MSBinNode;
				if (tmpPacChildNode == null) {
					throw new Exception("Error saving '" + pacPath
						+ "': The file does not appear to have a '" + childNodeName + "'");
				} else {
					tmpPacChildNode.Replace(tmpMsbn);
					tmpPacNode.Merge();
					tmpPacNode.Export(pacPath);
				}
			}

			File.Delete(tmpPac);
			File.Delete(tmpMsbn);
		}

		private string FindFile(string[] paths) {
			foreach (string path in paths) {
				if (File.Exists(path)) {
					return path;
				}
			}
			throw new FileNotFoundException("Could not find any file in: ['"
				+ string.Join("','", paths) + "']");
		}
	}
}
