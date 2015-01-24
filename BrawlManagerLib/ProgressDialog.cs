using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlManagerLib {
	public partial class ProgressDialog : Form {
		public ProgressDialog() {
			InitializeComponent();
		}

		public string ProgressTitle {
			get { return Text; }
			set { Text = value; }
		}

		public string InProgressLabel {
			get { return ProgressLabel.Text; }
			set { ProgressLabel.Text = value; }
		}

		public int ProgressCompletionAt {
			get { return ProgressBar.Maximum; }
			set { ProgressBar.Maximum = value; }
		}

		public int Progress {
			get { return ProgressBar.Value; }
			set { ProgressBar.Value = value; }
		}
	}
}
