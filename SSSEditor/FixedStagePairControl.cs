using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSSEditor {
	public class FixedStagePairControl : StagePairControl {
		private Control definitionsContainer;

		public FixedStagePairControl(Control definitionsContainer) : base() {
            this.definitionsContainer = definitionsContainer;
            SetNUDToOwnIndex = false;
			ddlStagePacs.Enabled = false;
			nudIconID.Enabled = false;
            //colorCode.Visible = false;
            nudDefIndex.Enabled = true;

			nudDefIndex.ValueChanged += nudDefIndex_ValueChanged;
			this.Paint += FixedStagePairControl_Paint;
		}

		private byte lastStage;
		private byte lastIcon;
		void FixedStagePairControl_Paint(object sender, PaintEventArgs e) {
			if (Stage != lastStage) {
				lastStage = Stage;
				Stage = Stage;
			}
			if (Icon != lastIcon) {
				lastIcon = Icon;
				Icon = Icon;
			}
		}

		private StagePair lastPairPtr;
		void nudDefIndex_ValueChanged(object sender, EventArgs e) {
			if (nudDefIndex.Value >= definitionsContainer.Controls.Count) {
				nudDefIndex.Value = definitionsContainer.Controls.Count - 1;
			}
            if (nudDefIndex.Value == -1) {
                MessageBox.Show(this, "Resetting entry " + lblIndex.Text + " to 00 - the previous stage/icon pair has been removed.");
                nudDefIndex.Value = 0;
                return;
            } else {
                Control c = definitionsContainer.Controls[(int)nudDefIndex.Value];
                if (c is StagePairControl) {
                    var p = ((StagePairControl)c).Pair;
                    if (p != lastPairPtr) {
                        lastPairPtr = p;
                        Pair = p;
                    }
                }
            }
		}

		protected override StagePairControl CreateNewControl() {
			return new FixedStagePairControl(definitionsContainer) {
				NUDDefValue = 0,
				MiscData80 = MiscData80,
				Dock = Dock,
			};
		}
	}
}
