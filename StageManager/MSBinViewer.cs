using System;
using System.Drawing;
using BrawlLib.SSBB.ResourceNodes;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrawlStageManager
{
    public class MSBinViewer : UserControl
    {
        private MSBinNode _node;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MSBinNode CurrentNode
        {
            get { return _node; }
            set
            {
                if (_node == value)
                    return;

                _node = value;
                InitNode();
            }
        }

        public MSBinViewer()
        {
            InitializeComponent();
        }

        private void InitNode()
        {
            txtEditor.Text = "";

            if (_node != null)
            {
				foreach (string s in _node._strings) {
					txtEditor.Text += s + "\r\n";
				}
            }
        }

        #region Designer

		private TextBox txtEditor;

        private void InitializeComponent()
        {
			this.txtEditor = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtEditor
			// 
			this.txtEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtEditor.Location = new System.Drawing.Point(0, 0);
			this.txtEditor.Margin = new System.Windows.Forms.Padding(0);
			this.txtEditor.Multiline = true;
			this.txtEditor.Name = "txtEditor";
			this.txtEditor.ReadOnly = true;
			this.txtEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtEditor.Size = new System.Drawing.Size(285, 211);
			this.txtEditor.TabIndex = 3;
			// 
			// MSBinViewer
			// 
			this.Controls.Add(this.txtEditor);
			this.Name = "MSBinViewer";
			this.Size = new System.Drawing.Size(285, 211);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

    }
}
