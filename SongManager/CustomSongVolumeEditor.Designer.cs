namespace BrawlSongManager {
	partial class CustomSongVolumeEditor {
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
			this.btnAdd = new System.Windows.Forms.Button();
			this.nudVolume = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nudVolume)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(0, 0);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// nudVolume
			// 
			this.nudVolume.Location = new System.Drawing.Point(81, 0);
			this.nudVolume.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
			this.nudVolume.Name = "nudVolume";
			this.nudVolume.Size = new System.Drawing.Size(69, 20);
			this.nudVolume.TabIndex = 1;
			this.nudVolume.ValueChanged += new System.EventHandler(this.nudVolume_ValueChanged);
			// 
			// CustomSongVolumeEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nudVolume);
			this.Controls.Add(this.btnAdd);
			this.Name = "CustomSongVolumeEditor";
			this.Size = new System.Drawing.Size(150, 32);
			((System.ComponentModel.ISupportInitialize)(this.nudVolume)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.NumericUpDown nudVolume;
	}
}
