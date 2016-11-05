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
		public bool UseSameSelchrMarksForAll {
			get {
				return radioCopyFromPrevious.Checked;
			}
		}

		public bool UseSameSelmapMarksForAll {
			get {
				return radioCopyFromPrevious.Checked || radioNewSelchrSameSelmap.Checked;
			}
		}

        public bool AddNewTextures {
            get {
                return chkAddNewTextures.Checked;
            }
        }

		public BatchAddPAT0Dialog() {
			InitializeComponent();
		}
	}
}
