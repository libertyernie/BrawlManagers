namespace BrawlManagerLib {
	partial class ProgressDialog {
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
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ProgressLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(12, 45);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(305, 23);
			this.ProgressBar.TabIndex = 1;
			// 
			// ProgressLabel
			// 
			this.ProgressLabel.AutoSize = true;
			this.ProgressLabel.Location = new System.Drawing.Point(12, 20);
			this.ProgressLabel.Name = "ProgressLabel";
			this.ProgressLabel.Size = new System.Drawing.Size(57, 13);
			this.ProgressLabel.TabIndex = 2;
			this.ProgressLabel.Text = "Progress...";
			this.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ProgressDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 80);
			this.ControlBox = false;
			this.Controls.Add(this.ProgressLabel);
			this.Controls.Add(this.ProgressBar);
			this.Name = "ProgressDialog";
			this.Text = "Progress";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar ProgressBar;
		private System.Windows.Forms.Label ProgressLabel;
	}
}