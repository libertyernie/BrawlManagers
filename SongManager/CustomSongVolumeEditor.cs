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

		public event EventHandler ValueChanged;

		public CustomSongVolumeEditor() {
			InitializeComponent();
		}

		private void reload() {
			if (CSV != null && CSV.Settings.ContainsKey(ID)) {
				btnAdd.Text = "Remove";
				nudVolume.Enabled = true;
				nudVolume.Value = CSV.Settings[ID];
			} else {
				btnAdd.Text = "Add";
				nudVolume.Enabled = false;
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
			CSV.Settings[ID] = Value;
			ValueChanged(this, new EventArgs());
		}
	}
}
