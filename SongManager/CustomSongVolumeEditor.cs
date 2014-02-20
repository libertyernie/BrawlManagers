using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlManagerLib;

namespace BrawlSongManager {
	[DefaultEvent("ValueChanged")]
	public partial class CustomSongVolumeEditor : UserControl {
		private CustomSongVolume _csv;
		public CustomSongVolume CSV {
			get {
				return _csv;
			}
			set {
				_csv = value;
				reload();
			}
		}
		private ushort _id;
		public ushort ID {
			get {
				return _id;
			}
			set {
				_id = value;
				reload();
			}
		}

		public byte Value {
			get {
				return (byte)nudVolume.Value;
			}
			set {
				nudVolume.Value = value;
			}
		}

		public Image Icon {
			get {
				return pictureBox1.BackgroundImage;
			}
			set {
				pictureBox1.BackgroundImage = value == null ? value : BitmapUtilities.Resize(value, pictureBox1.Size);
			}
		}

		public event EventHandler ValueChanged;

		public CustomSongVolumeEditor() {
			InitializeComponent();
		}

		public void SetBasename(string basename) {
			Song song = SongIDMap.Songs.Where(s => s.Filename == basename).FirstOrDefault();
			this.ID = (song != null ? song.ID : (ushort)0);
		}

		private void reload() {
			Song song = SongIDMap.Songs.Where(s => s.ID == ID).FirstOrDefault();
			if (song == null) {
				//songPanel1.VolumeToolTip = "Filename not recognized";
				this.Icon = SystemIcons.Warning.ToBitmap();

				btnAdd.Text = "Add";
				btnAdd.Enabled = false;
				nudVolume.Enabled = true;
				nudVolume.Value = 80;
			} else if (CSV != null && CSV.Settings.ContainsKey(song.ID)) {
				//songPanel1.VolumeToolTip = "Custom Song Volume code set";
				this.Icon = SystemIcons.Information.ToBitmap();

				btnAdd.Text = "Remove";
				btnAdd.Enabled = true;
				nudVolume.Enabled = true;
				nudVolume.Value = CSV.Settings[ID];
			} else if (song.DefaultVolume == null) {
				//songPanel1.VolumeToolTip = "Default volume unknown";
				this.Icon = SystemIcons.Warning.ToBitmap();

				btnAdd.Text = "Add";
				btnAdd.Enabled = true;
				nudVolume.Enabled = false;
				nudVolume.Value = defaultFor(ID);
			} else {
				//songPanel1.VolumeToolTip = null;
				this.Icon = null;

				btnAdd.Text = "Add";
				btnAdd.Enabled = true;
				nudVolume.Enabled = false;
				nudVolume.Value = defaultFor(ID);
			}
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			if (CSV.Settings.ContainsKey(ID)) {
				CSV.Settings.Remove(ID);
			} else {
				CSV.Settings.Add(ID, defaultFor(ID));
			}
			reload();
		}

		private static byte defaultFor(ushort ID) {
			return (from s in SongIDMap.Songs
					where s.ID == ID
					select s.DefaultVolume).FirstOrDefault() ?? 0;
		}

		private void nudVolume_ValueChanged(object sender, EventArgs e) {
			if (nudVolume.Enabled && ID > 0) CSV.Settings[ID] = Value;
			if (ValueChanged != null) ValueChanged(this, new EventArgs());
		}
	}
}
