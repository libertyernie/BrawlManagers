namespace SSSEditor {
	partial class StagePairControl {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.ddlStagePacs = new System.Windows.Forms.ComboBox();
			this.lblStageID = new System.Windows.Forms.Label();
			this.lblIconID = new System.Windows.Forms.Label();
			this.nudIconID = new System.Windows.Forms.NumericUpDown();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findUsageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.swapWithSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorCode = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblSong = new System.Windows.Forms.Label();
			this.lblIndex = new System.Windows.Forms.Label();
			this.nudDefIndex = new System.Windows.Forms.NumericUpDown();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.radioButton1 = new SSSEditor.UpDownKeyAwareRadioButton();
			((System.ComponentModel.ISupportInitialize)(this.nudIconID)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDefIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// ddlStagePacs
			// 
			this.ddlStagePacs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ddlStagePacs.FormattingEnabled = true;
			this.ddlStagePacs.Location = new System.Drawing.Point(26, 0);
			this.ddlStagePacs.Name = "ddlStagePacs";
			this.ddlStagePacs.Size = new System.Drawing.Size(185, 21);
			this.ddlStagePacs.TabIndex = 1;
			this.ddlStagePacs.SelectedIndexChanged += new System.EventHandler(this.ddlStagePacs_SelectedIndexChanged);
			// 
			// lblStageID
			// 
			this.lblStageID.AutoSize = true;
			this.lblStageID.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStageID.Location = new System.Drawing.Point(92, 32);
			this.lblStageID.Name = "lblStageID";
			this.lblStageID.Size = new System.Drawing.Size(24, 16);
			this.lblStageID.TabIndex = 3;
			this.lblStageID.Text = "01";
			// 
			// lblIconID
			// 
			this.lblIconID.AutoSize = true;
			this.lblIconID.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIconID.Location = new System.Drawing.Point(113, 32);
			this.lblIconID.Name = "lblIconID";
			this.lblIconID.Size = new System.Drawing.Size(24, 16);
			this.lblIconID.TabIndex = 4;
			this.lblIconID.Text = "01";
			// 
			// nudIconID
			// 
			this.nudIconID.Location = new System.Drawing.Point(143, 31);
			this.nudIconID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nudIconID.Name = "nudIconID";
			this.nudIconID.Size = new System.Drawing.Size(51, 20);
			this.nudIconID.TabIndex = 5;
			this.nudIconID.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
			// 
			// btnDown
			// 
			this.btnDown.Image = global::SSSEditor.Properties.Resources.downarr;
			this.btnDown.Location = new System.Drawing.Point(226, 30);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(20, 20);
			this.btnDown.TabIndex = 7;
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.Image = global::SSSEditor.Properties.Resources.uparr;
			this.btnUp.Location = new System.Drawing.Point(200, 30);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(20, 20);
			this.btnUp.TabIndex = 6;
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.findUsageToolStripMenuItem,
            this.swapWithSelectedToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(138, 70);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// findUsageToolStripMenuItem
			// 
			this.findUsageToolStripMenuItem.Name = "findUsageToolStripMenuItem";
			this.findUsageToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.findUsageToolStripMenuItem.Text = "Find Usage";
			this.findUsageToolStripMenuItem.Click += new System.EventHandler(this.findUsageToolStripMenuItem_Click);
			// 
			// swapWithSelectedToolStripMenuItem
			// 
			this.swapWithSelectedToolStripMenuItem.Name = "swapWithSelectedToolStripMenuItem";
			this.swapWithSelectedToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.swapWithSelectedToolStripMenuItem.Text = "Swap with...";
			this.swapWithSelectedToolStripMenuItem.Click += new System.EventHandler(this.swapWithSelectedToolStripMenuItem_Click);
			// 
			// colorCode
			// 
			this.colorCode.Dock = System.Windows.Forms.DockStyle.Right;
			this.colorCode.Location = new System.Drawing.Point(333, 0);
			this.colorCode.Margin = new System.Windows.Forms.Padding(0);
			this.colorCode.Name = "colorCode";
			this.colorCode.Size = new System.Drawing.Size(19, 62);
			this.colorCode.TabIndex = 9;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.nudDefIndex);
			this.panel1.Controls.Add(this.lblStageID);
			this.panel1.Controls.Add(this.lblIconID);
			this.panel1.Controls.Add(this.nudIconID);
			this.panel1.Controls.Add(this.btnUp);
			this.panel1.Controls.Add(this.btnDown);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(84, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(249, 62);
			this.panel1.TabIndex = 11;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.ddlStagePacs);
			this.panel2.Controls.Add(this.lblIndex);
			this.panel2.Controls.Add(this.lblSong);
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(243, 21);
			this.panel2.TabIndex = 12;
			// 
			// lblSong
			// 
			this.lblSong.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblSong.Location = new System.Drawing.Point(211, 0);
			this.lblSong.Name = "lblSong";
			this.lblSong.Size = new System.Drawing.Size(32, 21);
			this.lblSong.TabIndex = 10;
			this.lblSong.Text = "M88";
			this.lblSong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.lblSong, "Song");
			this.lblSong.Visible = false;
			// 
			// lblIndex
			// 
			this.lblIndex.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIndex.Location = new System.Drawing.Point(0, 0);
			this.lblIndex.Name = "lblIndex";
			this.lblIndex.Size = new System.Drawing.Size(26, 21);
			this.lblIndex.TabIndex = 9;
			this.lblIndex.Text = "88.";
			this.lblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nudDefIndex
			// 
			this.nudDefIndex.Enabled = false;
			this.nudDefIndex.Hexadecimal = true;
			this.nudDefIndex.Location = new System.Drawing.Point(29, 30);
			this.nudDefIndex.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nudDefIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.nudDefIndex.Name = "nudDefIndex";
			this.nudDefIndex.Size = new System.Drawing.Size(51, 20);
			this.nudDefIndex.TabIndex = 8;
			this.nudDefIndex.Value = new decimal(new int[] {
            123,
            0,
            0,
            0});
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Location = new System.Drawing.Point(352, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(208, 62);
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// radioButton1
			// 
			this.radioButton1.Dock = System.Windows.Forms.DockStyle.Left;
			this.radioButton1.Image = global::SSSEditor.Properties.Resources.stageicon;
			this.radioButton1.Location = new System.Drawing.Point(0, 0);
			this.radioButton1.Margin = new System.Windows.Forms.Padding(0);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(84, 62);
			this.radioButton1.TabIndex = 8;
			this.radioButton1.TabStop = true;
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// StagePairControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.colorCode);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.radioButton1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "StagePairControl";
			this.Size = new System.Drawing.Size(560, 62);
			((System.ComponentModel.ISupportInitialize)(this.nudIconID)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudDefIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		protected System.Windows.Forms.ComboBox ddlStagePacs;
		private System.Windows.Forms.Label lblStageID;
		private System.Windows.Forms.Label lblIconID;
		protected System.Windows.Forms.NumericUpDown nudIconID;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnDown;
		private SSSEditor.UpDownKeyAwareRadioButton radioButton1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		protected System.Windows.Forms.Panel colorCode;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		protected System.Windows.Forms.NumericUpDown nudDefIndex;
		private System.Windows.Forms.ToolStripMenuItem findUsageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem swapWithSelectedToolStripMenuItem;
		private System.Windows.Forms.Label lblSong;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolTip toolTip1;
		protected System.Windows.Forms.Label lblIndex;
	}
}
