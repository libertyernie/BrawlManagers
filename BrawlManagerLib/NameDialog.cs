using System;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.Diagnostics;

namespace BrawlManagerLib
{
    public class NameDialog : Form
    {
		public string EntryText {
			get {
				return txtName.Text;
			}
			set {
				txtName.Text = value;
			}
		}
		public string LabelText {
			get {
				return label1.Text;
			}
			set {
				label1.Text = value;
				int h = 125;
				foreach (char c in value) {
					if (c == '\n') h += 13;
				}
				if (h > Height) Height = h;
			}
		}

		public NameDialog() { InitializeComponent();  }

        public DialogResult ShowDialog(IWin32Window owner, string text)
        {
			Text = text;
			return ShowDialog(owner);
		}
        private void btnOkay_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
			Close();
		}
		
		private void btnCharmap_Click(object sender, EventArgs e) {
			Process.Start("charmap.exe");
		}

		#region Designer

		private TextBox txtName;
        private Button btnCancel;
		private Label label1;
		private Button btnCharmap;
		private Button btnOkay;

        private void InitializeComponent()
        {
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOkay = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCharmap = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.HideSelection = false;
			this.txtName.Location = new System.Drawing.Point(12, 25);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(260, 20);
			this.txtName.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(197, 51);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOkay
			// 
			this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOkay.Location = new System.Drawing.Point(116, 51);
			this.btnOkay.Name = "btnOkay";
			this.btnOkay.Size = new System.Drawing.Size(75, 23);
			this.btnOkay.TabIndex = 3;
			this.btnOkay.Text = "&Okay";
			this.btnOkay.UseVisualStyleBackColor = true;
			this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "    ";
			// 
			// btnCharmap
			// 
			this.btnCharmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCharmap.Location = new System.Drawing.Point(12, 51);
			this.btnCharmap.Name = "btnCharmap";
			this.btnCharmap.Size = new System.Drawing.Size(75, 23);
			this.btnCharmap.TabIndex = 2;
			this.btnCharmap.Text = "Char. Map";
			this.btnCharmap.UseVisualStyleBackColor = true;
			this.btnCharmap.Click += new System.EventHandler(this.btnCharmap_Click);
			// 
			// NameDialog
			// 
			this.AcceptButton = this.btnOkay;
			this.AutoSize = true;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(284, 86);
			this.Controls.Add(this.btnCharmap);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOkay);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "NameDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Enter Name";
			this.ResumeLayout(false);
			this.PerformLayout();

        }


		#endregion
	}
}
