using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrawlLib.SSBB.ResourceNodes;
using System.Windows.Forms;
using BrawlManagerLib;

namespace BrawlCostumeManager {
	public class InfoStockIconViewer : PortraitViewer {
		private int _charNum, _costumeNum;

		private static PortraitViewerTextureData[] textureData = {
			new PortraitViewerTextureData(32, 32, (i,j) => "MiscData[30]/Textures(NW4R)/InfStc." + (i*10 + j + 1).ToString("D3"))
		};

		private string _openFilePath;
        private FlowLayoutPanel additionalTexturesPanel;
        private Button saveButton;
		/// <summary>
		/// The info.pac file currently being used.
		/// </summary>
		private ResourceNode info_en;

		public InfoStockIconViewer() {
            InitializeComponent();
			foreach (var atd in textureData) {
                additionalTexturesPanel.Controls.Add(atd.Panel);
				atd.OnUpdate = delegate(PortraitViewerTextureData sender) {
					UpdateImage(_charNum, _costumeNum);
				};

                var copyPreview = new ToolStripMenuItem("Copy preview");
                copyPreview.Click += (o, e) => Clipboard.SetImage(atd.Panel.BackgroundImage);
                atd.Panel.ContextMenuStrip.Items.Add(copyPreview);
			}
			UpdateDirectory();
		}

		public override bool UpdateImage(int charNum, int costumeNum) {
			_charNum = charNum;
			_costumeNum = costumeNum;
			foreach (var atd in textureData) {
				atd.TextureFrom(info_en, charNum, costumeNum);
			}
			return true;
		}

		public override void UpdateDirectory() {
			if (File.Exists("../info2/info.pac")) {
				string path = "../info2/info.pac";
				info_en = NodeFactory.FromFile(null, path);
				_openFilePath = path;
			} else if (File.Exists("../info2/info_en.pac")) {
				string path = "../info2/info_en.pac";
				info_en = NodeFactory.FromFile(null, path);
				_openFilePath = path;
			}
		}

		private void saveButton_Click(object sender, EventArgs e) {
			if (info_en == null) {
				return;
			}

			info_en.Merge();
			info_en.Export(_openFilePath);
		}

        private void InitializeComponent()
        {
			this.additionalTexturesPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.saveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// additionalTexturesPanel
			// 
			this.additionalTexturesPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.additionalTexturesPanel.Location = new System.Drawing.Point(0, 0);
			this.additionalTexturesPanel.Margin = new System.Windows.Forms.Padding(0);
			this.additionalTexturesPanel.Name = "additionalTexturesPanel";
			this.additionalTexturesPanel.Size = new System.Drawing.Size(72, 48);
			this.additionalTexturesPanel.TabIndex = 1;
			// 
			// saveButton
			// 
			this.saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.saveButton.Location = new System.Drawing.Point(72, 0);
			this.saveButton.Margin = new System.Windows.Forms.Padding(0);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(56, 48);
			this.saveButton.TabIndex = 2;
			this.saveButton.Text = "Save info.pac";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// InfoStockIconViewer
			// 
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.additionalTexturesPanel);
			this.Name = "InfoStockIconViewer";
			this.Size = new System.Drawing.Size(128, 48);
			this.ResumeLayout(false);

        }
	}
}
