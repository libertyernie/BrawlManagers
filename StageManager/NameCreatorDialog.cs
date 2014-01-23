using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrawlStageManager {
	public partial class NameCreatorDialog : Form {
		private NameCreatorSettings _settings;
		public NameCreatorSettings Settings {
			get {
				return _settings;
			}
			set {
				_settings = value;
				updateText();
			}
		}

		public NameCreatorDialog() {
			InitializeComponent();
		}

		private void btnImpact_Click(object sender, EventArgs e) {
			Settings = new NameCreatorSettings {
				Font = new Font("Impact", 22.5f),
				VerticalOffset = -1,
			};
		}

		private void btnEdo_Click(object sender, EventArgs e) {
			Settings = new NameCreatorSettings {
				Font = new Font("Edo SZ", 22f, FontStyle.Bold),
				VerticalOffset = 2,
			};
		}

		private void btnCustom_Click(object sender, EventArgs e) {
			using (FontDialog d = new FontDialog()) {
				if (Settings != null && Settings.Font != null) {
					d.Font = Settings.Font;
				}
				try {
					DialogResult dr = d.ShowDialog();
					if (dr == DialogResult.OK) {
						Settings = new NameCreatorSettings {
							Font = d.Font,
							VerticalOffset = (int)nudOffset.Value,
						};
					}
				} catch (ArgumentException ex) {
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void NameCreatorDialog_Load(object sender, EventArgs e) {
			//updateText();
		}

		private void updateText() {
			lblCurrentFont.Text = (Settings == null)
			? "No font selected"
			: Settings.ToString();
		}

		private void btnClearFont_Click(object sender, EventArgs e) {
			Settings = null;
		}
	}
}
