using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlStageManager {
	public partial class ThreeStageFrontStnameDialog : Form {
		public Bitmap Bitmap { get; private set; }

		public ThreeStageFrontStnameDialog() {
			InitializeComponent();
			foreach (Control c in Controls) {
				if (c is TextBox) ((TextBox)c).TextChanged += Redraw;
			}
		}

		static Font big = new Font("DejaVu Sans", 15f, FontStyle.Bold);
		static Font small = new Font("DejaVu Sans", 12f, FontStyle.Bold);
		static StringFormat sf = new StringFormat() {
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center,
		};
		static Brush whitebrush = new SolidBrush(Color.White);

		public void Redraw(object obj, EventArgs args) {
			Bitmap = new Bitmap(208, 168);
			Graphics g = Graphics.FromImage(Bitmap);
			g.FillRectangle(new SolidBrush(Color.Black), 0, 0, 208, 168);
			g.DrawLine(new Pen(Color.White), 0, 56, 208, 56);

			string[] s0 = txtMainStage.Text.Split('\n');
			if (s0.Length == 1) {
				g.DrawString(txtMainStage.Text, big, whitebrush, 104, 29, sf);
			} else {
				g.DrawString(s0[0], big, whitebrush, 104, 17, sf);
				g.DrawString(s0[1], big, whitebrush, 104, 41, sf);
			}

			g.DrawString(txtCombo1.Text, small, whitebrush, 24, 85, sf);
			string[] s1 = (txtCombo1Stage.Text + "\n").Split('\n');
			g.DrawString(s1[0], small, whitebrush, 128, 75, sf);
			g.DrawString(s1[1], small, whitebrush, 128, 95, sf);

			g.DrawString(txtCombo2.Text, small, whitebrush, 24, 141, sf);
			string[] s2 = (txtCombo2Stage.Text + "\n").Split('\n');
			g.DrawString(s2[0], small, whitebrush, 128, 131, sf);
			g.DrawString(s2[1], small, whitebrush, 128, 151, sf);

			panel1.BackgroundImage = Bitmap;
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
			Clipboard.SetImage(Bitmap);
		}
	}
}
