using BrawlLib.SSBB.ResourceNodes;
using BrawlManagerLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSSEditor {
	public partial class SSSEditorForm : Form {
		// Source data
		private CustomSSSwithSDSL sss;
		private BRESNode md80;

		#region Collect data from controls
		private List<StagePair> getDefinitions() {
			List<StagePair> definitions = new List<StagePair>();
			foreach (Control c in tblStageDefinitions.Controls) {
				if (c is StagePairControl) {
					definitions.Add(((StagePairControl)c).Pair);
				}
			}
			return definitions;
		}
		private List<StagePair> getScreen1() {
			List<StagePair> screen1 = new List<StagePair>();
			foreach (Control c in tblSSS1.Controls) {
				if (c is StagePairControl) {
					screen1.Add(((StagePairControl)c).Pair);
				}
			}
			return screen1;
		}
		private List<StagePair> getScreen2() {
			List<StagePair> screen2 = new List<StagePair>();
			foreach (Control c in tblSSS2.Controls) {
				if (c is StagePairControl) {
					screen2.Add(((StagePairControl)c).Pair);
				}
			}
			return screen2;
		}
		#endregion

		public SSSEditorForm(string gct, string pac) {
			InitializeComponent();
			foreach (Control c in tblColorCodeKeys.Controls) {
				c.DoubleClick += (o, e) => {
					tblColorCodeKeys.Visible = false;
				};
			}
			try {
				Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetCallingAssembly().Location);
			} catch (Exception e) {
				Console.WriteLine(e.StackTrace);
			}

			tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;

			sss = new CustomSSSwithSDSL(gct);
			ReloadIfValidPac(pac);
		}

		private void ReloadData() {
			tblStageDefinitions.Controls.Clear();
			tblSSS1.Controls.Clear();
			tblSSS2.Controls.Clear();

			if (sss.OtherCodesIgnoredInSameFile > 0) {
				MessageBox.Show(this, "More than one Custom SSS code found in the codeset. All but the last one will be ignored.",
					this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			var screen1 = new List<StagePair>();
			var screen2 = new List<StagePair>();
			var definitions = new List<StagePair>();
			for (int i = 0; i < sss.sss3.Length; i += 2) {
				definitions.Add(new StagePair {
					stage = sss.sss3[i],
					icon = sss.sss3[i + 1],
				});
			}
			foreach (byte b in sss.sss1) {
				screen1.Add(definitions[b]);
			}
			foreach (byte b in sss.sss2) {
				screen2.Add(definitions[b]);
			}

			foreach (StagePair pair in definitions) {
				var spc = new StagePairControl {
					Pair = pair,
					MiscData80 = md80,
					Dock = DockStyle.Fill,
				};
				if (sss.SongsByStage.ContainsKey(pair.stage)) {
					Song s = sss.SongsByStage[pair.stage];
					spc.Song = s.Filename;
					spc.SongToolTip = s.ID.ToString("X4") + " - " + s.DefaultName;
				}
				spc.FindUsageClick += spc_FindUsageClick;
				spc.SwapWithSelectedClick += spc_SwapWithSelectedClick;
				tblStageDefinitions.Controls.Add(spc);
			}

			foreach (StagePair pair in screen1) {
				var spc = new FixedStagePairControl(tblStageDefinitions) {
					Pair = pair,
					MiscData80 = md80,
					Dock = DockStyle.Fill,
				};
				spc.FindUsageClick += spc_FindUsageClick;
				spc.SwapWithSelectedClick += spc_SwapWithSelectedClick;
				tblSSS1.Controls.Add(spc);
			}

			foreach (StagePair pair in screen2) {
				var spc = new FixedStagePairControl(tblStageDefinitions) {
					Pair = pair,
					MiscData80 = md80,
					Dock = DockStyle.Fill,
				};
				spc.FindUsageClick += spc_FindUsageClick;
				tblSSS2.Controls.Add(spc);
			}
		}

		private void spc_FindUsageClick(StagePairControl sender) {
			StagePair pair = sender.Pair;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("SSS #1:");
			List<StagePair> screen1 = getScreen1();
			for (int i=0; i<screen1.Count; i++) {
				if (screen1[i] == pair) {
					sb.AppendLine(i.ToString());
				}
			}
			sb.AppendLine("SSS #2:");
			List<StagePair> screen2 = getScreen2();
			for (int i = 0; i < screen2.Count; i++) {
				if (screen2[i] == pair) {
					sb.AppendLine(i.ToString());
				}
			}
			MessageBox.Show(sb.ToString());
		}

		private void spc_SwapWithSelectedClick(StagePairControl sender) {
			AskSwapDialog dialog = new AskSwapDialog();
			Control tbl = tabControl1.SelectedTab.Controls[0];
			foreach (Control c in tbl.Controls) {
				if (c is StagePairControl && c != sender) {
					StagePairControl spc = (StagePairControl)c;
					dialog.Add(spc);
				}
			}
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				int index1 = tbl.Controls.GetChildIndex(sender);
				int index2 = tbl.Controls.GetChildIndex(dialog.Selected);
				tbl.Controls.SetChildIndex(sender, index2);
				tbl.Controls.SetChildIndex(dialog.Selected, index1);
			} foreach (Control c in tbl.Controls) {
				if (c is StagePairControl) {
					((StagePairControl)c).Recolor();
				}
			}
		}

		private void ReloadIfValidPac(string file, CustomSSSwithSDSL sssIfOtherFileValid = null) {
			ResourceNode node = NodeFactory.FromFile(null, file);
			ResourceNode p1icon = node.FindChild("MenSelmapCursorPly.1", true);
			BRESNode candidate = (p1icon != null) ? p1icon.Parent.Parent as BRESNode : null;
			if (candidate == null) {
				MessageBox.Show(this, "No SSS icons were found in the selected file.",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} else {
				if (md80 != null) md80.Dispose();
				md80 = candidate;
				sss = sssIfOtherFileValid ?? sss;
				ReloadData();
			}
		}

		#region Conversion to code text
		private string ToCodeLines(List<StagePair> list, List<StagePair> definitions) {
			StringBuilder sb = new StringBuilder();
			string[] s = (from sp in list
						  select definitions.Contains(sp)
						  ? definitions.IndexOf(sp).ToString("X2")
						  : "__").ToArray();
			for (int i = 0; i < s.Length; i += 8) {
				sb.Append("* ");
				for (int j = i; j < i + 4; j++) {
					sb.Append(j < s.Length ? s[j] : "00");
				}
				sb.Append(" ");
				for (int j = i + 4; j < i + 8; j++) {
					sb.Append(j < s.Length ? s[j] : "00");
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}

		private string ToCodeLines(List<StagePair> definitions) {
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < definitions.Count; i += 4) {
				sb.Append("* ");
				for (int j = i; j < i + 2; j++) {
					sb.Append(j < definitions.Count ? definitions[j].ToUshort().ToString("X4") : "0000");
				}
				sb.Append(" ");
				for (int j = i + 2; j < i + 4; j++) {
					sb.Append(j < definitions.Count ? definitions[j].ToUshort().ToString("X4") : "0000");
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}

		public string ToCode() {
			List<StagePair> definitions = getDefinitions();
			List<StagePair> screen1 = getScreen1();
			List<StagePair> screen2 = getScreen2();
			return String.Format(
@"* 046B8F5C 7C802378
* 046B8F64 7C6300AE
* 040AF618 5460083C
* 040AF68C 38840002
* 040AF6AC 5463083C
* 040AF6C0 88030001
* 040AF6E8 3860FFFF
* 040AF59C 3860000C
* 060B91C8 00000018
* BFA10014 7CDF3378
* 7CBE2B78 7C7D1B78
* 2D05FFFF 418A0014
* 006B929C 000000{0}
* 066B99D8 000000{0}
{1}* 006B92A4 000000{2}
* 066B9A58 000000{2}
{3}* 06407AAC 000000{4}
{5}",
			screen1.Count.ToString("X2"), ToCodeLines(screen1, definitions),
			screen2.Count.ToString("X2"), ToCodeLines(screen2, definitions),
			(2*definitions.Count).ToString("X2"), ToCodeLines(definitions));
		}
		#endregion

		void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
			List<StagePair> definitions = getDefinitions();
			if (tabControl1.SelectedTab == tabSSS1) {
				foreach (Control c in tblSSS1.Controls) {
					if (c is FixedStagePairControl) {
						var f = ((FixedStagePairControl)c);
						((FixedStagePairControl)c).NUDDefValue = definitions.IndexOf(f.Pair);
					}
				}
			} else if (tabControl1.SelectedTab == tabSSS2) {
				foreach (Control c in tblSSS2.Controls) {
					if (c is FixedStagePairControl) {
						var f = ((FixedStagePairControl)c);
						((FixedStagePairControl)c).NUDDefValue = definitions.IndexOf(f.Pair);
					}
				}
			} else if (tabControl1.SelectedTab == tabPreview1) {
				sssPrev1.MiscData80 = this.md80;
				sssPrev1.NumIcons = tblSSS1.Controls.Count;
				sssPrev1.IconOrder = (from p in getScreen1()
									  select p.icon).ToArray();
			} else if (tabControl1.SelectedTab == tabPreview2) {
				sssPrev2.MiscData80 = this.md80;
				sssPrev2.NumIcons = tblSSS2.Controls.Count;
				sssPrev2.IconOrder = (from p in getScreen2()
									  select p.icon).ToArray();
			} else if (tabControl1.SelectedTab == tabMyMusic1) {
				myMusic1.MiscData80 = this.md80;
				myMusic1.IconOrder = (from p in getScreen1()
									  where p != definitions[0x1E]
									  select p.icon).ToArray();
				myMusic1.NumIcons = myMusic1.IconOrder.Length;
			} else if (tabControl1.SelectedTab == tabMyMusic2) {
				myMusic2.MiscData80 = this.md80;
				myMusic2.IconOrder = (from p in getScreen2()
									  where p != definitions[0x1E]
									  select p.icon).Concat(
									  from b in new byte[] {0x64}
									  select b).ToArray();
				myMusic2.NumIcons = myMusic2.IconOrder.Length;
			}
		}

		private void openCodesetgcttxtToolStripMenuItem_Click(object sender, EventArgs e) {
			using (var dialog = new OpenFileDialog()) {
				dialog.Filter = "Ocarina codes (*.gct, *.txt)|*.gct;*.txt";
				dialog.Multiselect = false;
				if (dialog.ShowDialog() == DialogResult.OK) {
					sss = new CustomSSSwithSDSL(dialog.FileName);
					ReloadData();
				}
			}
		}

		private void openStageIconspacbrresToolStripMenuItem_Click(object sender, EventArgs e) {
			using (var dialog = new OpenFileDialog()) {
				dialog.Filter = "Brawl data files (*.pac, *.brres)|*.pac;*.brres";
				dialog.Multiselect = false;
				if (dialog.ShowDialog() == DialogResult.OK) {
					ReloadIfValidPac(dialog.FileName);
				}
			}
		}

		private void openSDCardRootToolStripMenuItem_Click(object sender, EventArgs e) {
			using (var dialog = new FolderBrowserDialog()) {
				if (dialog.ShowDialog() == DialogResult.OK) {
					CustomSSSwithSDSL candidateSSS;

					if (File.Exists(dialog.SelectedPath + "/codes/RSBE01.gct")) {
						candidateSSS = new CustomSSSwithSDSL(dialog.SelectedPath + "/codes/RSBE01.gct");
					} else if (File.Exists(dialog.SelectedPath + "/data/gecko/codes/RSBE01.gct")) {
						candidateSSS = new CustomSSSwithSDSL(dialog.SelectedPath + "/data/gecko/codes/RSBE01.gct");
					} else if (File.Exists(dialog.SelectedPath + "/RSBE01.gct")) {
						candidateSSS = new CustomSSSwithSDSL(dialog.SelectedPath + "/RSBE01.gct");
					} else {
						MessageBox.Show(this, "Could not find codes/RSBE01.gct or data/gecko/codes/RSBE01.gct.",
							"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					string root = null;
					foreach (string folder in new string[] { "/private/wii/app/RSBE/pf", "/projectm/pf", "/minusery/pf" }) {
						foreach (string file in new string[] { "menu2/sc_selmap.pac", "sc_selmap_en.pac", "system/common5.pac", "system/common5_en.pac" }) {
							if (File.Exists(dialog.SelectedPath + folder + "/" + file)) {
								root = dialog.SelectedPath + folder + "/" + file;
								break;
							}
						}
					}
					if (root == null) {
						MessageBox.Show(this, "Could not find common5 or sc_selmap.",
							"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					ReloadIfValidPac(root, candidateSSS);
				}
			}
		}

		private void saveCodesetgctToolStripMenuItem_Click(object sender, EventArgs e) {
			using (var dialog = new SaveFileDialog()) {
				dialog.Filter = "Ocarina codes (*.gct)|*.gct";
				dialog.OverwritePrompt = true;
				if (dialog.ShowDialog() == DialogResult.OK) {
					using (var fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write)) {
						foreach (byte[] b in new byte[][] {
							sss.DataBefore, ByteUtilities.StringToByteArray(ToCode()), sss.DataAfter
						}) {
							fs.Write(b, 0, b.Length);
						}
					}
				}
			}
		}

		private void saveSSSCodeOnlytxtToolStripMenuItem_Click(object sender, EventArgs e) {
			using (var dialog = new SaveFileDialog()) {
				dialog.Filter = "Text files (*.txt)|*.txt";
				dialog.OverwritePrompt = true;
				if (dialog.ShowDialog() == DialogResult.OK) {
					File.WriteAllText(dialog.FileName, ToCode());
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void viewCodeToolStripMenuItem_Click(object sender, EventArgs e) {
			using (Form f = new Form() { Text = "Custom SSS Code" }) {
				TextBox t = new TextBox() {
					Multiline = true,
					Dock = DockStyle.Fill,
					ScrollBars = ScrollBars.Vertical,
					Text = ToCode(),
					Font = new System.Drawing.Font("Consolas", 12)
				};
				f.Controls.Add(t);
				f.ShowDialog(this);
			}
		}

		private void highlightUnusedPairsToolStripMenuItem_Click(object sender, EventArgs e) {
			List<StagePair> screens = new List<StagePair>();
			foreach (Control c in tblSSS1.Controls) {
				if (c is StagePairControl) {
					screens.Add(((StagePairControl)c).Pair);
				}
			}
			foreach (Control c in tblSSS2.Controls) {
				if (c is StagePairControl) {
					screens.Add(((StagePairControl)c).Pair);
				}
			}

			foreach (Control c in tblStageDefinitions.Controls) {
				if (c is StagePairControl) {
					var s = (StagePairControl)c;
					if (!screens.Contains(s.Pair)) {
						s.BackColor = Color.LightBlue;
					}
				}
			}
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			TableLayoutPanel table = tabControl1.SelectedTab.Controls[0] as TableLayoutPanel;
			if (table != null) {
				StagePairControl fallback = null;
				foreach (Control c in table.Controls) {
					if (c is StagePairControl) {
						fallback = (StagePairControl)c;
						if (fallback.Checked) {
							fallback.Insert();
							return;
						}
					}
				}
				if (fallback != null) {
					fallback.Insert();
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			TableLayoutPanel table = tabControl1.SelectedTab.Controls[0] as TableLayoutPanel;
			if (table != null) {
				foreach (Control c in table.Controls) {
					if (c is StagePairControl && ((StagePairControl)c).Checked) {
						((StagePairControl)c).Delete();
						return;
					}
				}
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			new AboutBSM(null, System.Reflection.Assembly.GetExecutingAssembly()).ShowDialog(this);
		}
	}
}
