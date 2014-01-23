using System;
using System.Drawing;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using BrawlManagerLib;

namespace SSSEditor {
	public delegate void SPCEvent(StagePairControl sender);
	public partial class StagePairControl : UserControl {
		public event SPCEvent FindUsageClick;
		public event SPCEvent SwapWithSelectedClick;

		private BRESNode miscdata80;
		/// <summary>
		/// The MiscData[80] file to read icons from.
		/// </summary>
		public BRESNode MiscData80 {
			get {
				return miscdata80;
			}
			set {
				if (miscdata80 != null) {
					miscdata80.Dispose();
				}
				miscdata80 = value;
				Icon = Icon;
			}
		}

        public bool SetNUDToOwnIndex;

		/// <summary>
		/// Checks the radio button, and if 'true', focuses it as well.
		/// </summary>
		public bool Checked {
			get {
				return radioButton1.Checked;
			}
			set {
				radioButton1.Checked = value;
				if (value) radioButton1.Focus();
			}
		}

		/// <summary>
		/// Gets or sets the value of the leftmost number spinner, which may toggle update events.
		/// </summary>
        public decimal NUDDefValue {
            get {
                return nudDefIndex.Value;
            }
            set {
                nudDefIndex.Value = value;
            }
        }

		public string Song {
			get {
				return lblSong.Text;
			}
			set {
				lblSong.Text = value;
				lblSong.Visible = (value != null);
			}
		}
		public string SongToolTip {
			get {
				return toolTip1.GetToolTip(lblSong);
			}
			set {
				toolTip1.SetToolTip(lblSong, value);
			}
		}

		private StagePair _pair;
		private TextureContainer textures;
		/// <summary>
		/// Gets/sets the pair object being pointed to by this control.
		/// </summary>
		public StagePair Pair {
			get {
				return _pair;
			}
			set {
				_pair = value;
				Stage = Stage;
				Icon = Icon;
			}
		}
		/// <summary>
		/// Gets/sets the stage ID of the pair and updates the dropdown list.
		/// </summary>
		public byte Stage {
			get {
				return Pair == null ? (byte)0xff : Pair.stage;
			}
			set {
				if (Pair != null) {
					Pair.stage = value;
					ddlStagePacs.SelectedValue = value;
					lblStageID.Text = value.ToString("X2");
				}
			}
		}
		/// <summary>
		/// Gets/sets the icon ID of the pair and updates the icon ID and images.
		/// </summary>
		public byte Icon {
			get {
				return Pair == null ? (byte)0xff : Pair.icon;
			}
			set {
				if (Pair != null) {
					Pair.icon = value;
					if (miscdata80 == null) {
						radioButton1.Image = null;
                        pictureBox1.Image = null;
					} else {
                        textures = new TextureContainer(miscdata80, Icon);
                        radioButton1.Image = (textures.icon.tex0 == null) ? null : textures.icon.tex0.GetImage(0);
                        pictureBox1.Image = (textures.frontstname.tex0 == null) ? null : textures.frontstname.tex0.GetImage(0);
					}
					nudIconID.Value = value;
					lblIconID.Text = value.ToString("X2");
				}
			}
		}

		public StagePairControl() {
			InitializeComponent();
            SetNUDToOwnIndex = true;

			radioButton1.KeyDown += keyDown;
			foreach (Control c in this.Controls) {
				if (!(c is ComboBox || c is NumericUpDown)) {
					c.Click += CheckRadioButton;
					c.MouseUp += ShowMenuOnRightClick;
				}
			} foreach (Control c in panel1.Controls) {
				if (!(c is ComboBox || c is NumericUpDown)) {
					c.Click += CheckRadioButton;
					c.MouseUp += ShowMenuOnRightClick;
				}
			}

            ddlStagePacs.DisplayMember = "Value";
            ddlStagePacs.ValueMember = "Key";
            ddlStagePacs.DataSource = StageIDMap.StagesByID;
            ddlStagePacs.Resize += (o, e) =>
            {
                if (!ddlStagePacs.Focused) ddlStagePacs.SelectionLength = 0;
            };
			ddlStagePacs.LostFocus += (o, e) => {
				if (ddlStagePacs.SelectedIndex == -1) {
					byte entered;
					if (byte.TryParse(ddlStagePacs.Text,
						System.Globalization.NumberStyles.HexNumber,
						System.Globalization.CultureInfo.InvariantCulture,
						out entered)) {
						ddlStagePacs.SelectedValue = entered;
					} else if (ddlStagePacs.Text.StartsWith("c")
						&& byte.TryParse(ddlStagePacs.Text.Substring(1),
						System.Globalization.NumberStyles.HexNumber,
						System.Globalization.CultureInfo.InvariantCulture,
						out entered)) {
						ddlStagePacs.SelectedValue = (byte)(entered + 0x3F);
					}
				}
			};

            this.ParentChanged += (o, e) => {
                Recolor();
            };

            nudDefIndex.ValueChanged += (o, e) => {
                colorCode.BackColor =
                  nudDefIndex.Value == 0x1E ? Color.Yellow
                : nudDefIndex.Value < 0x29 ? Color.Green
                : Color.Red;
            };

            nudIconID.ValueChanged += (o, e) => {
                Icon = (byte)nudIconID.Value;
            };
		}

		/// <summary>
		/// Picks a new color for the color-code panel and (if applicable) updates the leftmost spinner.
		/// </summary>
		public void Recolor() {
			if (Parent == null) return;
			int i = Parent.Controls.GetChildIndex(this);
            lblIndex.Text = i + ".";
            if (SetNUDToOwnIndex) nudDefIndex.Value = i;
            Invalidate();
		}

		public void Delete() {
			var C = Parent.Controls;
			int index = C.IndexOf(this);
			Control control = (index == C.Count - 1)
				? C[index - 1]
				: C[index + 1];
			if (control is StagePairControl) {
				((StagePairControl)control).Checked = true;
			}

			Parent.Controls.Remove(this);
			this.Dispose();
		}

		protected virtual StagePairControl CreateNewControl() {
			return new StagePairControl() {
				Pair = new StagePair(),
				MiscData80 = miscdata80,
				Dock = Dock,
			};
		}

		public void Insert() {
			var C = Parent.Controls;
			int index = C.IndexOf(this);
			var newspc = CreateNewControl();
			C.Add(newspc);
			C.SetChildIndex(newspc, index+1);

			foreach (Control c in C) {
				if (c is StagePairControl) ((StagePairControl)c).Recolor();
			}
		}

        private void CheckRadioButton(object sender, EventArgs e) {
            radioButton1.Focus();
			radioButton1.Checked = true;
        }

		void ShowMenuOnRightClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) contextMenuStrip1.Show(Cursor.Position);
		}

		private void ddlStagePacs_SelectedIndexChanged(object sender, EventArgs e) {
			if (ddlStagePacs.SelectedValue != null) Stage = (byte)ddlStagePacs.SelectedValue;
		}

		private void btnUp_Click(object sender, EventArgs e) {
			var C = Parent.Controls;
			int index = C.IndexOf(this);
			if (index == 0) return;

			Control control = C[index - 1];
            C.SetChildIndex(this, index - 1);
            C.SetChildIndex(control, index);

            Recolor();
            if (control is StagePairControl) ((StagePairControl)control).Recolor();
		}

		private void btnDown_Click(object sender, EventArgs e) {
			var C = Parent.Controls;
			int index = C.IndexOf(this);
			if (index == C.Count - 1) return;

			Control control = C[index + 1];
			C.SetChildIndex(this, index + 1);
            C.SetChildIndex(control, index);

            Recolor();
            if (control is StagePairControl) ((StagePairControl)control).Recolor();
		}

		void keyDown(object sender, KeyEventArgs e) {
			if (!radioButton1.Checked) return;
			Console.WriteLine(e.KeyCode);
			switch (e.KeyCode) {
				case Keys.Up:
					e.Handled = true;
					btnUp.PerformClick();
					if (Parent is Panel) ((Panel)Parent).ScrollControlIntoView(this);
					break;
				case Keys.Down:
					e.Handled = true;
					btnDown.PerformClick();
					if (Parent is Panel) ((Panel)Parent).ScrollControlIntoView(this);
					break;
				case Keys.Delete:
					if (Control.ModifierKeys == Keys.Control) {
						e.Handled = true;
						Delete();
					}
					break;
				case Keys.N:
					if (Control.ModifierKeys == Keys.Control) {
						e.Handled = true;
						Insert();
					}
					break;
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e) {
			BackColor = radioButton1.Checked ? SystemColors.Highlight : SystemColors.Control;
			if (radioButton1.Checked) {
				foreach (Control c in Parent.Controls) {
					if (c is StagePairControl && c != this) {
						((StagePairControl)c).Checked = false;
					}
				}
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
			Delete();
		}

		private void findUsageToolStripMenuItem_Click(object sender, EventArgs e) {
			FindUsageClick.Invoke(this);
		}

		private void swapWithSelectedToolStripMenuItem_Click(object sender, EventArgs e) {
			SwapWithSelectedClick.Invoke(this);
		}
	}
}
