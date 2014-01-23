namespace SSSEditor {
	partial class SSSEditorForm {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SSSEditorForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openCodesetgcttxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openStageIconspacbrresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.openSDCardRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveCodesetgctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveSSSCodeOnlytxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.highlightUnusedPairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabSSS2 = new System.Windows.Forms.TabPage();
			this.tblSSS2 = new System.Windows.Forms.TableLayoutPanel();
			this.tabSSS1 = new System.Windows.Forms.TabPage();
			this.tblSSS1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabDefinitions = new System.Windows.Forms.TabPage();
			this.tblStageDefinitions = new System.Windows.Forms.TableLayoutPanel();
			this.tblColorCodeKeys = new System.Windows.Forms.TableLayoutPanel();
			this.lblGreen = new System.Windows.Forms.Label();
			this.lblYellow = new System.Windows.Forms.Label();
			this.lblBlue = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPreview1 = new System.Windows.Forms.TabPage();
			this.tabPreview2 = new System.Windows.Forms.TabPage();
			this.tabMyMusic1 = new System.Windows.Forms.TabPage();
			this.tabMyMusic2 = new System.Windows.Forms.TabPage();
			this.tblButtonRow = new System.Windows.Forms.TableLayoutPanel();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.sssPrev1 = new SSSEditor.SSSPrev();
			this.sssPrev2 = new SSSEditor.SSSPrev();
			this.myMusic1 = new SSSEditor.SSSPrev();
			this.myMusic2 = new SSSEditor.SSSPrev();
			this.menuStrip1.SuspendLayout();
			this.tabSSS2.SuspendLayout();
			this.tabSSS1.SuspendLayout();
			this.tabDefinitions.SuspendLayout();
			this.tblColorCodeKeys.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPreview1.SuspendLayout();
			this.tabPreview2.SuspendLayout();
			this.tabMyMusic1.SuspendLayout();
			this.tabMyMusic2.SuspendLayout();
			this.tblButtonRow.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewCodeToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(376, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCodesetgcttxtToolStripMenuItem,
            this.openStageIconspacbrresToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openSDCardRootToolStripMenuItem});
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// openCodesetgcttxtToolStripMenuItem
			// 
			this.openCodesetgcttxtToolStripMenuItem.Name = "openCodesetgcttxtToolStripMenuItem";
			this.openCodesetgcttxtToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.openCodesetgcttxtToolStripMenuItem.Text = "Codeset (gct/txt)";
			this.openCodesetgcttxtToolStripMenuItem.Click += new System.EventHandler(this.openCodesetgcttxtToolStripMenuItem_Click);
			// 
			// openStageIconspacbrresToolStripMenuItem
			// 
			this.openStageIconspacbrresToolStripMenuItem.Name = "openStageIconspacbrresToolStripMenuItem";
			this.openStageIconspacbrresToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.openStageIconspacbrresToolStripMenuItem.Text = "Stage icons (pac/brres)";
			this.openStageIconspacbrresToolStripMenuItem.Click += new System.EventHandler(this.openStageIconspacbrresToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
			// 
			// openSDCardRootToolStripMenuItem
			// 
			this.openSDCardRootToolStripMenuItem.Name = "openSDCardRootToolStripMenuItem";
			this.openSDCardRootToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.openSDCardRootToolStripMenuItem.Text = "SD card root";
			this.openSDCardRootToolStripMenuItem.Click += new System.EventHandler(this.openSDCardRootToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCodesetgctToolStripMenuItem,
            this.saveSSSCodeOnlytxtToolStripMenuItem});
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveCodesetgctToolStripMenuItem
			// 
			this.saveCodesetgctToolStripMenuItem.Name = "saveCodesetgctToolStripMenuItem";
			this.saveCodesetgctToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.saveCodesetgctToolStripMenuItem.Text = "Codeset (gct)";
			this.saveCodesetgctToolStripMenuItem.Click += new System.EventHandler(this.saveCodesetgctToolStripMenuItem_Click);
			// 
			// saveSSSCodeOnlytxtToolStripMenuItem
			// 
			this.saveSSSCodeOnlytxtToolStripMenuItem.Name = "saveSSSCodeOnlytxtToolStripMenuItem";
			this.saveSSSCodeOnlytxtToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.saveSSSCodeOnlytxtToolStripMenuItem.Text = "SSS code only (txt)";
			this.saveSSSCodeOnlytxtToolStripMenuItem.Click += new System.EventHandler(this.saveSSSCodeOnlytxtToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// viewCodeToolStripMenuItem
			// 
			this.viewCodeToolStripMenuItem.Name = "viewCodeToolStripMenuItem";
			this.viewCodeToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
			this.viewCodeToolStripMenuItem.Text = "View code";
			this.viewCodeToolStripMenuItem.Click += new System.EventHandler(this.viewCodeToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highlightUnusedPairsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// highlightUnusedPairsToolStripMenuItem
			// 
			this.highlightUnusedPairsToolStripMenuItem.Name = "highlightUnusedPairsToolStripMenuItem";
			this.highlightUnusedPairsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.highlightUnusedPairsToolStripMenuItem.Text = "Highlight unused pairs";
			this.highlightUnusedPairsToolStripMenuItem.Click += new System.EventHandler(this.highlightUnusedPairsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// tabSSS2
			// 
			this.tabSSS2.Controls.Add(this.tblSSS2);
			this.tabSSS2.Location = new System.Drawing.Point(4, 22);
			this.tabSSS2.Name = "tabSSS2";
			this.tabSSS2.Size = new System.Drawing.Size(368, 379);
			this.tabSSS2.TabIndex = 2;
			this.tabSSS2.Text = "SSS #2";
			this.tabSSS2.UseVisualStyleBackColor = true;
			// 
			// tblSSS2
			// 
			this.tblSSS2.AutoScroll = true;
			this.tblSSS2.ColumnCount = 1;
			this.tblSSS2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tblSSS2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblSSS2.Location = new System.Drawing.Point(0, 0);
			this.tblSSS2.Name = "tblSSS2";
			this.tblSSS2.RowCount = 1;
			this.tblSSS2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tblSSS2.Size = new System.Drawing.Size(368, 379);
			this.tblSSS2.TabIndex = 3;
			// 
			// tabSSS1
			// 
			this.tabSSS1.Controls.Add(this.tblSSS1);
			this.tabSSS1.Location = new System.Drawing.Point(4, 22);
			this.tabSSS1.Name = "tabSSS1";
			this.tabSSS1.Size = new System.Drawing.Size(368, 379);
			this.tabSSS1.TabIndex = 1;
			this.tabSSS1.Text = "SSS #1";
			this.tabSSS1.UseVisualStyleBackColor = true;
			// 
			// tblSSS1
			// 
			this.tblSSS1.AutoScroll = true;
			this.tblSSS1.ColumnCount = 1;
			this.tblSSS1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tblSSS1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblSSS1.Location = new System.Drawing.Point(0, 0);
			this.tblSSS1.Name = "tblSSS1";
			this.tblSSS1.RowCount = 1;
			this.tblSSS1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tblSSS1.Size = new System.Drawing.Size(368, 379);
			this.tblSSS1.TabIndex = 2;
			// 
			// tabDefinitions
			// 
			this.tabDefinitions.Controls.Add(this.tblStageDefinitions);
			this.tabDefinitions.Controls.Add(this.tblColorCodeKeys);
			this.tabDefinitions.Location = new System.Drawing.Point(4, 22);
			this.tabDefinitions.Name = "tabDefinitions";
			this.tabDefinitions.Size = new System.Drawing.Size(368, 379);
			this.tabDefinitions.TabIndex = 0;
			this.tabDefinitions.Text = "Stage/Icon Pairs";
			this.tabDefinitions.UseVisualStyleBackColor = true;
			// 
			// tblStageDefinitions
			// 
			this.tblStageDefinitions.AutoScroll = true;
			this.tblStageDefinitions.ColumnCount = 1;
			this.tblStageDefinitions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tblStageDefinitions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblStageDefinitions.Location = new System.Drawing.Point(0, 80);
			this.tblStageDefinitions.Name = "tblStageDefinitions";
			this.tblStageDefinitions.RowCount = 1;
			this.tblStageDefinitions.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tblStageDefinitions.Size = new System.Drawing.Size(368, 299);
			this.tblStageDefinitions.TabIndex = 1;
			// 
			// tblColorCodeKeys
			// 
			this.tblColorCodeKeys.ColumnCount = 1;
			this.tblColorCodeKeys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tblColorCodeKeys.Controls.Add(this.lblGreen, 0, 2);
			this.tblColorCodeKeys.Controls.Add(this.lblYellow, 0, 1);
			this.tblColorCodeKeys.Controls.Add(this.lblBlue, 0, 0);
			this.tblColorCodeKeys.Controls.Add(this.label1, 0, 3);
			this.tblColorCodeKeys.Dock = System.Windows.Forms.DockStyle.Top;
			this.tblColorCodeKeys.Location = new System.Drawing.Point(0, 0);
			this.tblColorCodeKeys.Name = "tblColorCodeKeys";
			this.tblColorCodeKeys.RowCount = 4;
			this.tblColorCodeKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tblColorCodeKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tblColorCodeKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tblColorCodeKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
			this.tblColorCodeKeys.Size = new System.Drawing.Size(368, 80);
			this.tblColorCodeKeys.TabIndex = 2;
			// 
			// lblGreen
			// 
			this.lblGreen.BackColor = System.Drawing.Color.Green;
			this.lblGreen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblGreen.ForeColor = System.Drawing.Color.White;
			this.lblGreen.Location = new System.Drawing.Point(3, 40);
			this.lblGreen.Name = "lblGreen";
			this.lblGreen.Size = new System.Drawing.Size(362, 20);
			this.lblGreen.TabIndex = 2;
			this.lblGreen.Text = "Green: both on My Music AND chosen on random";
			this.lblGreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblYellow
			// 
			this.lblYellow.BackColor = System.Drawing.Color.Yellow;
			this.lblYellow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblYellow.ForeColor = System.Drawing.Color.Black;
			this.lblYellow.Location = new System.Drawing.Point(3, 20);
			this.lblYellow.Name = "lblYellow";
			this.lblYellow.Size = new System.Drawing.Size(362, 20);
			this.lblYellow.TabIndex = 1;
			this.lblYellow.Text = "Yellow: missing from My Music (Hanenbow)";
			this.lblYellow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblBlue
			// 
			this.lblBlue.BackColor = System.Drawing.Color.Red;
			this.lblBlue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblBlue.ForeColor = System.Drawing.Color.White;
			this.lblBlue.Location = new System.Drawing.Point(3, 0);
			this.lblBlue.Name = "lblBlue";
			this.lblBlue.Size = new System.Drawing.Size(362, 20);
			this.lblBlue.TabIndex = 0;
			this.lblBlue.Text = "Red: never gets chosen on random";
			this.lblBlue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabDefinitions);
			this.tabControl1.Controls.Add(this.tabSSS1);
			this.tabControl1.Controls.Add(this.tabSSS2);
			this.tabControl1.Controls.Add(this.tabPreview1);
			this.tabControl1.Controls.Add(this.tabPreview2);
			this.tabControl1.Controls.Add(this.tabMyMusic1);
			this.tabControl1.Controls.Add(this.tabMyMusic2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(376, 405);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPreview1
			// 
			this.tabPreview1.Controls.Add(this.sssPrev1);
			this.tabPreview1.Location = new System.Drawing.Point(4, 22);
			this.tabPreview1.Name = "tabPreview1";
			this.tabPreview1.Size = new System.Drawing.Size(368, 379);
			this.tabPreview1.TabIndex = 3;
			this.tabPreview1.Text = "Preview #1";
			this.tabPreview1.UseVisualStyleBackColor = true;
			// 
			// tabPreview2
			// 
			this.tabPreview2.Controls.Add(this.sssPrev2);
			this.tabPreview2.Location = new System.Drawing.Point(4, 22);
			this.tabPreview2.Name = "tabPreview2";
			this.tabPreview2.Size = new System.Drawing.Size(368, 379);
			this.tabPreview2.TabIndex = 4;
			this.tabPreview2.Text = "Preview #2";
			this.tabPreview2.UseVisualStyleBackColor = true;
			// 
			// tabMyMusic1
			// 
			this.tabMyMusic1.Controls.Add(this.myMusic1);
			this.tabMyMusic1.Location = new System.Drawing.Point(4, 22);
			this.tabMyMusic1.Name = "tabMyMusic1";
			this.tabMyMusic1.Size = new System.Drawing.Size(368, 379);
			this.tabMyMusic1.TabIndex = 5;
			this.tabMyMusic1.Text = "My Music #1";
			this.tabMyMusic1.UseVisualStyleBackColor = true;
			// 
			// tabMyMusic2
			// 
			this.tabMyMusic2.Controls.Add(this.myMusic2);
			this.tabMyMusic2.Location = new System.Drawing.Point(4, 22);
			this.tabMyMusic2.Name = "tabMyMusic2";
			this.tabMyMusic2.Size = new System.Drawing.Size(368, 379);
			this.tabMyMusic2.TabIndex = 6;
			this.tabMyMusic2.Text = "My Music #2";
			this.tabMyMusic2.UseVisualStyleBackColor = true;
			// 
			// tblButtonRow
			// 
			this.tblButtonRow.ColumnCount = 2;
			this.tblButtonRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblButtonRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblButtonRow.Controls.Add(this.btnAdd, 0, 0);
			this.tblButtonRow.Controls.Add(this.btnDelete, 1, 0);
			this.tblButtonRow.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tblButtonRow.Location = new System.Drawing.Point(0, 429);
			this.tblButtonRow.Name = "tblButtonRow";
			this.tblButtonRow.RowCount = 1;
			this.tblButtonRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblButtonRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tblButtonRow.Size = new System.Drawing.Size(376, 32);
			this.tblButtonRow.TabIndex = 0;
			// 
			// btnAdd
			// 
			this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnAdd.Location = new System.Drawing.Point(3, 3);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(182, 26);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Add (Ctrl+N)";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnDelete.Location = new System.Drawing.Point(191, 3);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(182, 26);
			this.btnDelete.TabIndex = 1;
			this.btnDelete.Text = "Delete (Ctrl+Del)";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Green;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(3, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(362, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "(Double-click to hide this box.)";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// sssPrev1
			// 
			this.sssPrev1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sssPrev1.IconOrder = null;
			this.sssPrev1.Location = new System.Drawing.Point(0, 0);
			this.sssPrev1.MyMusic = false;
			this.sssPrev1.Name = "sssPrev1";
			this.sssPrev1.NumIcons = 23;
			this.sssPrev1.Size = new System.Drawing.Size(368, 379);
			this.sssPrev1.TabIndex = 0;
			// 
			// sssPrev2
			// 
			this.sssPrev2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sssPrev2.IconOrder = null;
			this.sssPrev2.Location = new System.Drawing.Point(0, 0);
			this.sssPrev2.MyMusic = false;
			this.sssPrev2.Name = "sssPrev2";
			this.sssPrev2.NumIcons = 23;
			this.sssPrev2.Size = new System.Drawing.Size(368, 379);
			this.sssPrev2.TabIndex = 0;
			// 
			// myMusic1
			// 
			this.myMusic1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myMusic1.IconOrder = null;
			this.myMusic1.Location = new System.Drawing.Point(0, 0);
			this.myMusic1.MyMusic = true;
			this.myMusic1.Name = "myMusic1";
			this.myMusic1.NumIcons = 23;
			this.myMusic1.Size = new System.Drawing.Size(368, 379);
			this.myMusic1.TabIndex = 0;
			// 
			// myMusic2
			// 
			this.myMusic2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myMusic2.IconOrder = null;
			this.myMusic2.Location = new System.Drawing.Point(0, 0);
			this.myMusic2.MyMusic = true;
			this.myMusic2.Name = "myMusic2";
			this.myMusic2.NumIcons = 23;
			this.myMusic2.Size = new System.Drawing.Size(368, 379);
			this.myMusic2.TabIndex = 0;
			// 
			// SSSEditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(376, 461);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.tblButtonRow);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "SSSEditorForm";
			this.Text = "SSS Editor";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabSSS2.ResumeLayout(false);
			this.tabSSS1.ResumeLayout(false);
			this.tabDefinitions.ResumeLayout(false);
			this.tblColorCodeKeys.ResumeLayout(false);
			this.tblColorCodeKeys.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPreview1.ResumeLayout(false);
			this.tabPreview2.ResumeLayout(false);
			this.tabMyMusic1.ResumeLayout(false);
			this.tabMyMusic2.ResumeLayout(false);
			this.tblButtonRow.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.TabPage tabSSS2;
		private System.Windows.Forms.TableLayoutPanel tblSSS2;
		private System.Windows.Forms.TabPage tabSSS1;
		private System.Windows.Forms.TableLayoutPanel tblSSS1;
		private System.Windows.Forms.TabPage tabDefinitions;
		private System.Windows.Forms.TableLayoutPanel tblStageDefinitions;
		private System.Windows.Forms.TableLayoutPanel tblColorCodeKeys;
		private System.Windows.Forms.Label lblGreen;
		private System.Windows.Forms.Label lblYellow;
		private System.Windows.Forms.Label lblBlue;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openCodesetgcttxtToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openStageIconspacbrresToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openSDCardRootToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveCodesetgctToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveSSSCodeOnlytxtToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewCodeToolStripMenuItem;
		private System.Windows.Forms.TabPage tabPreview1;
		private SSSPrev sssPrev1;
		private System.Windows.Forms.TabPage tabPreview2;
		private SSSPrev sssPrev2;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem highlightUnusedPairsToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel tblButtonRow;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.TabPage tabMyMusic1;
		private SSSPrev myMusic1;
		private System.Windows.Forms.TabPage tabMyMusic2;
		private SSSPrev myMusic2;
		private System.Windows.Forms.Label label1;
	}
}

