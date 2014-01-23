namespace BrawlStageManager {
	partial class PortraitViewer {
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
			this.label1 = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.prevbase = new BrawlStageManager.ImagePreviewPanel();
			this.icon = new BrawlStageManager.ImagePreviewPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnGenerateName = new System.Windows.Forms.Button();
			this.lblIconTex = new System.Windows.Forms.Label();
			this.frontstname = new BrawlStageManager.ImagePreviewPanel();
			this.seriesicon = new BrawlStageManager.ImagePreviewPanel();
			this.selmap_mark = new BrawlStageManager.ImagePreviewPanel();
			this.fileSizeBar = new System.Windows.Forms.ProgressBar();
			this.fileSizeLabel = new System.Windows.Forms.Label();
			this.modifyPAT0 = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 446);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(204, 40);
			this.label1.TabIndex = 1;
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(0, 364);
			this.saveButton.Margin = new System.Windows.Forms.Padding(0);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(208, 23);
			this.saveButton.TabIndex = 2;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.prevbase);
			this.flowLayoutPanel1.Controls.Add(this.icon);
			this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
			this.flowLayoutPanel1.Controls.Add(this.frontstname);
			this.flowLayoutPanel1.Controls.Add(this.seriesicon);
			this.flowLayoutPanel1.Controls.Add(this.selmap_mark);
			this.flowLayoutPanel1.Controls.Add(this.saveButton);
			this.flowLayoutPanel1.Controls.Add(this.fileSizeBar);
			this.flowLayoutPanel1.Controls.Add(this.fileSizeLabel);
			this.flowLayoutPanel1.Controls.Add(this.modifyPAT0);
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(210, 500);
			this.flowLayoutPanel1.TabIndex = 3;
			// 
			// prevbase
			// 
			this.prevbase.AllowDrop = true;
			this.prevbase.BorderChangeItemEnabled = false;
			this.prevbase.Location = new System.Drawing.Point(0, 0);
			this.prevbase.Margin = new System.Windows.Forms.Padding(0);
			this.prevbase.Name = "prevbase";
			this.prevbase.Size = new System.Drawing.Size(176, 176);
			this.prevbase.TabIndex = 0;
			// 
			// icon
			// 
			this.icon.AllowDrop = true;
			this.icon.BorderChangeItemEnabled = true;
			this.icon.Location = new System.Drawing.Point(0, 176);
			this.icon.Margin = new System.Windows.Forms.Padding(0);
			this.icon.Name = "icon";
			this.icon.Size = new System.Drawing.Size(64, 56);
			this.icon.TabIndex = 3;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.btnGenerateName, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblIconTex, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(67, 179);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(120, 56);
			this.tableLayoutPanel1.TabIndex = 11;
			// 
			// btnGenerateName
			// 
			this.btnGenerateName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGenerateName.Location = new System.Drawing.Point(3, 31);
			this.btnGenerateName.Name = "btnGenerateName";
			this.btnGenerateName.Size = new System.Drawing.Size(114, 22);
			this.btnGenerateName.TabIndex = 10;
			this.btnGenerateName.Text = "Generate name -- ]";
			this.btnGenerateName.UseVisualStyleBackColor = true;
			this.btnGenerateName.Visible = false;
			this.btnGenerateName.Click += new System.EventHandler(this.btnGenerateName_Click);
			// 
			// lblIconTex
			// 
			this.lblIconTex.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblIconTex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIconTex.Location = new System.Drawing.Point(3, 0);
			this.lblIconTex.Name = "lblIconTex";
			this.lblIconTex.Size = new System.Drawing.Size(114, 28);
			this.lblIconTex.TabIndex = 11;
			this.lblIconTex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frontstname
			// 
			this.frontstname.AllowDrop = true;
			this.frontstname.BorderChangeItemEnabled = false;
			this.frontstname.Location = new System.Drawing.Point(0, 238);
			this.frontstname.Margin = new System.Windows.Forms.Padding(0);
			this.frontstname.Name = "frontstname";
			this.frontstname.Size = new System.Drawing.Size(208, 56);
			this.frontstname.TabIndex = 4;
			// 
			// seriesicon
			// 
			this.seriesicon.AllowDrop = true;
			this.seriesicon.BorderChangeItemEnabled = false;
			this.seriesicon.Location = new System.Drawing.Point(3, 297);
			this.seriesicon.Name = "seriesicon";
			this.seriesicon.Size = new System.Drawing.Size(64, 64);
			this.seriesicon.TabIndex = 7;
			// 
			// selmap_mark
			// 
			this.selmap_mark.AllowDrop = true;
			this.selmap_mark.BorderChangeItemEnabled = false;
			this.selmap_mark.Location = new System.Drawing.Point(73, 297);
			this.selmap_mark.Name = "selmap_mark";
			this.selmap_mark.Size = new System.Drawing.Size(120, 56);
			this.selmap_mark.TabIndex = 8;
			// 
			// fileSizeBar
			// 
			this.fileSizeBar.Location = new System.Drawing.Point(0, 387);
			this.fileSizeBar.Margin = new System.Windows.Forms.Padding(0);
			this.fileSizeBar.Name = "fileSizeBar";
			this.fileSizeBar.Size = new System.Drawing.Size(208, 23);
			this.fileSizeBar.TabIndex = 5;
			// 
			// fileSizeLabel
			// 
			this.fileSizeLabel.Location = new System.Drawing.Point(3, 410);
			this.fileSizeLabel.Name = "fileSizeLabel";
			this.fileSizeLabel.Size = new System.Drawing.Size(204, 13);
			this.fileSizeLabel.TabIndex = 6;
			this.fileSizeLabel.Text = "fileSizeLabel";
			this.fileSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// modifyPAT0
			// 
			this.modifyPAT0.Location = new System.Drawing.Point(0, 423);
			this.modifyPAT0.Margin = new System.Windows.Forms.Padding(0);
			this.modifyPAT0.Name = "modifyPAT0";
			this.modifyPAT0.Size = new System.Drawing.Size(208, 23);
			this.modifyPAT0.TabIndex = 9;
			this.modifyPAT0.Text = "Modify PAT0 mapping (~)";
			this.modifyPAT0.UseVisualStyleBackColor = true;
			this.modifyPAT0.Click += new System.EventHandler(this.modifyPAT0_Click);
			// 
			// PortraitViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "PortraitViewer";
			this.Size = new System.Drawing.Size(210, 500);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public BrawlStageManager.ImagePreviewPanel prevbase;
		public BrawlStageManager.ImagePreviewPanel icon;
		public BrawlStageManager.ImagePreviewPanel frontstname;
		public BrawlStageManager.ImagePreviewPanel seriesicon;
		public BrawlStageManager.ImagePreviewPanel selmap_mark;
		protected System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.ProgressBar fileSizeBar;
		private System.Windows.Forms.Label fileSizeLabel;
		private System.Windows.Forms.Button modifyPAT0;
		private System.Windows.Forms.Button btnGenerateName;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblIconTex;
	}
}
