using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlStageManager.SingleUseDialogs {
	public partial class BatchAddPAT0Dialog : Form {
		public bool UseSameMarksForAll {
			get {
				return radioCopyFromPrevious.Checked;
			}
		}

		public BatchAddPAT0Dialog() {
			InitializeComponent();
		}
	}
}
