using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlStageManager {
	public partial class AskNameDialog : Form {
		public AskNameDialog(Bitmap bg) {
			InitializeComponent();
			panel1.BackgroundImage = bg;
			textBox1.Text = "MenSelmapMark.";
			AcceptButton = button1;
		}

		public string NameText {
			get {
				return textBox1.Text;
			}
			set {
				textBox1.Text = value;
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			NameText = Text;
		}
	}
}
