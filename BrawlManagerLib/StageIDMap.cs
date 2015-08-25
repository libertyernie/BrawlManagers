using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BrawlManagerLib {
	public class StageIDMap {
		#region Definition of "Stage" inner class
		public class Stage {
			public byte ID { get; private set; }
			public string Name { get; private set; }
			public string RelName { get; private set; }
			public string PacBasename { get; private set; }

			#region Finding .pac names - for the stage sorter in MainForm and the MenSelmapMark report
			public string[] PacNames {
				get {
					string s = PacBasename;
					return  s == "starfox" ? new string[] { "STGSTARFOX_GDIFF.pac" } :
							s == "emblem" ? new string[] {
								"STGEMBLEM_00.pac",
								"STGEMBLEM_01.pac",
								"STGEMBLEM_02.pac" } :
							s == "mariopast" ? new string[] {
								"STGMARIOPAST_00.pac",
								"STGMARIOPAST_01.pac" } :
							s == "metalgear" ? new string[] {
								"STGMETALGEAR_00.pac",
								"STGMETALGEAR_01.pac",
								"STGMETALGEAR_02.pac" } :
							s == "tengan" ? new string[] {
								"STGTENGAN_1.pac",
								"STGTENGAN_2.pac",
								"STGTENGAN_3.pac" } :
							s == "village" ? new string[] {
								"STGVILLAGE_00.pac",
								"STGVILLAGE_01.pac",
								"STGVILLAGE_02.pac",
								"STGVILLAGE_03.pac",
								"STGVILLAGE_04.pac" } :
							s == "custom" ? new string[0] :
							new string[] { "STG" + s.ToUpper() + ".pac" };
				}
			}
			private static string[] from(string basename, int start, int count) {
				return (from i in Enumerable.Range(start, count) select "STG" + basename + i.ToString("X2") + ".pac").ToArray();
			}
			#endregion

			public bool ContainsPac(string filename) {
				int i = filename.IndexOfAny(new char[] { '.', '_' });
				if (filename.Length < 3 || i < 0) return false;

				string input_basename = filename.Substring(3, i - 3);
				return String.Equals(input_basename.ToLower(), PacBasename.ToLower(), StringComparison.InvariantCultureIgnoreCase);
			}

			public Stage(byte id, string name, string relname, string pac_basename) {
				this.ID = id;
				this.Name = name;
				this.RelName = relname;
				this.PacBasename = pac_basename;
			}

			public override string ToString() { return Name; }
		}
		#endregion

		public static ReadOnlyCollection<Stage> Stages { get; private set; }
		public static ReadOnlyCollection<KeyValuePair<byte, string>> StagesByID { get; private set; }

		static StageIDMap() {
			// static initializer
			#region Arrays containing stage data
			string[] relnames = {"st_custom##",
				"st_battle", "st_final",
				"st_dolpic", "st_mansion", "st_mariopast",
				"st_kart", "st_donkey", "st_jungle",
				"st_pirates", "st_norfair", "st_orpheon",
				"st_crayon", "st_halberd", "st_starfox",
				"st_stadium", "st_tengan", "st_fzero",
				"st_ice", "st_gw", "st_emblem",
				"st_madein", "st_earth", "st_palutena",
				"st_famicom", "st_newpork", "st_village",
				"st_metalgear", "st_greenhill", "st_pictchat",
				"st_plankton", "st_config", "st_dxshrine",
				"st_dxyorster", "st_dxgarden", "st_dxonett",
				"st_dxgreens", "st_dxpstadium", "st_dxrcruise",
				"st_dxcorneria", "st_dxbigblue", "st_dxzebes",
				"st_oldin", "st_homerun", "st_stageedit",
				"st_heal", "st_otrain", "st_tbreak"};
			string[] pac_basenames = {"custom",
				"battlefield", "final",
				"dolpic", "mansion", "mariopast",
				"kart", "donkey", "jungle",
				"pirates", "norfair", "orpheon",
				"crayon", "halberd", "starfox",
				"stadium", "tengan", "fzero",
				"ice", "gw", "emblem",
				"madein", "earth", "palutena",
				"famicom", "newpork", "village",
				"metalgear", "greenhill", "pictchat",
				"plankton", "configtest", "dxshrine",
				"dxyorster", "dxgarden", "dxonett",
				"dxgreens", "dxpstadium", "dxrcruise",
				"dxcorneria", "dxbigblue", "dxzebes",
				"oldin", "homerun", "edit",
				"heal", "onlinetraining", "targetlv"};
			string[] stagenames = {"STGCUSTOM##.pac", "Battlefield",
				"Final Destination", "Delfino Plaza", "Luigi's Mansion",
				"Mushroomy Kingdom", "Mario Circuit", "75 m",
				"Rumble Falls", "Pirate Ship", "Norfair",
				"Frigate Orpheon", "Yoshi's Island (Brawl)", "Halberd",
				"Lylat Cruise", "Pokemon Stadium 2", "Spear Pillar",
				"Port Town Aero Dive", "Summit", "Flat Zone 2",
				"Castle Siege", "WarioWare Inc.", "Distant Planet",
				"Skyworld", "Mario Bros.", "New Pork City", "Smashville",
				"Shadow Moses Island", "Green Hill Zone", "PictoChat",
				"Hanenbow", "ConfigTest", "Temple",
				"Yoshi's Island (Melee)", "Jungle Japes", "Onett",
				"Green Greens", "Pokemon Stadium", "Rainbow Cruise",
				"Corneria", "Big Blue", "Brinstar", "Bridge of Eldin",
				"Homerun", "Edit", "Heal", "Online Practice Stage",
				"TargetBreak"};
			byte[] ids = {0,1,2,3,4,5,6,7,
				8,9,11,12,13,14,19,20,21,
				22,23,24,25,28,29,30,31,32,33,
				34,35,36,37,38,41,
				42,43,44,45,46,47,48,49,50,51,
				52,53,54,55,56};
			#endregion

			List<Stage> list = new List<Stage>(ids.Length);
			for (int i = 0; i < ids.Length; i++) {
				list.Add(new Stage(ids[i], stagenames[i], relnames[i], pac_basenames[i]));
			}
			Stages = list.AsReadOnly();

			List<KeyValuePair<byte, string>> byID = new List<KeyValuePair<byte, string>>();
			for (byte b = 1; b <= 100; b++) {
				string pac = StageIDMap.PacBasenameForStageID(b);
				if (pac != null) byID.Add(new KeyValuePair<byte, string>(b, pac.ToUpper()));
			}
			StagesByID = byID.AsReadOnly();
		}

		public static List<string> PacFilesBySSSOrder(CustomSSSCodeset sss) {
			List<string> list = new List<string>();
			foreach (int stage_id in sss.StageIDsInOrder) {
				if (stage_id >= 0x40) {
					list.Add("STGCUSTOM" + (stage_id - 0x3F).ToString("X2") + ".pac");
				} else {
					var q = from s in Stages
							where s.ID == stage_id
							select s.PacNames;
					foreach (string[] ss in q) {
						list.AddRange(ss);
					}
				}
			}
			return list;
		}

		public static int StageIDForPac(string filename) {
			int stageID = -1;
			if (filename.StartsWith("STGCUSTOM", StringComparison.InvariantCultureIgnoreCase)) {
				stageID = Convert.ToInt32(filename.Substring(9, 2), 16) + 0x3F;
			} else {
				var q = from s in Stages
						where s.ContainsPac(filename)
						select s.ID;
				if (q.Count() > 1) {
					Console.WriteLine("More than one stage matches the search pattern: " + filename);
					return q.First();
				} else if (q.Count() < 1) {
					Console.WriteLine("No stage matches the search pattern: " + filename);
					return -1;
				}
				stageID = q.First();
			}
			return stageID;
		}

		public static string PacBasenameForStageID(int stageID) {
			if (stageID >= 0x40) {
				return "custom" + (stageID - 0x3F).ToString("X2");
			} else {
				var q = from s in Stages
						where s.ID == stageID
						select s.PacBasename;
				if (!q.Any()) return null;
				return q.First();
			}
		}

		public static string RelNameForPac(string filename, bool differentForAlternateStage) {
			string asl_append = "";
			if (differentForAlternateStage) {
				string lastsix = ("++++++" + filename).Substring(filename.Length, 6);
				if (lastsix[0] == '_') {
					asl_append = "_" + lastsix[1];
				}
			}
			if (filename.StartsWith("STGCUSTOM", StringComparison.InvariantCultureIgnoreCase)) {
				return "st_custom" + filename.Substring(9, 2) + asl_append + ".rel";
			} else {
				var q = from s in Stages
						where s.ContainsPac(filename)
						select s.RelName;
				if (q.Count() > 1) {
					Console.WriteLine("More than one stage matches the search pattern: " + filename);
				} else if (q.Count() < 1) {
					Console.WriteLine("No stage matches the search pattern: " + filename);
					return "none";
				}
				return q.First() + asl_append + ".rel";
			}
		}

		#region sc_selcharacter2
		// the sss3 index is also the index in MiscData[1] in sc_selcharacter2
		private static int[] sc_selcharacter2_icon_from_sss3_index = {
			1, // Battlefield
			2, // Final Destination
			3, // Delfino Plaza
			4, // Luigi's Mansion
			5, // Mushroomy Kingdom
			6, // Mario Circuit
			25, // 75 m
			7, // Rumble Falls
			9, // Pirate Ship
			8, // Bridge of Eldin
			10, // Norfair
			11, // Frigate Orpheon
			12, // Yoshi's Island (Brawl)
			13, // Halberd
			14, // Lylat Cruise
			15, // Pokemon Stadium 2
			16, // Spear Pillar
			17, // Port Town Aero Dive
			23, // Summit
			27, // Flat Zone 2
			18, // Castle Siege
			19, // WarioWare Inc.
			20, // Distant Planet
			24, // Skyworld
			26, // Mario Bros.
			22, // New Pork City
			21, // Smashville
			30, // Shadow Moses Island
			31, // Green Hill Zone
			28, // PictoChat
			29, // Hanenbow
			50, // Temple
			51, // Yoshi's Island (Melee)
			52, // Jungle Japes
			53, // Onett
			54, // Green Greens
			55, // Rainbow Cruise
			56, // Corneria
			57, // Big Blue
			58, // Brinstar
			59, // Pokemon Stadium
		};
		public static int sssPositionForSelcharacter2Icon(int selcharacter2Icon) {
			int index = -1;
			for (int i = 0; i < sc_selcharacter2_icon_from_sss3_index.Length; i++) {
				if (sc_selcharacter2_icon_from_sss3_index[i] == selcharacter2Icon) {
					index = i;
					break;
				}
			}
			return index;
		}
		#endregion
	}
}
