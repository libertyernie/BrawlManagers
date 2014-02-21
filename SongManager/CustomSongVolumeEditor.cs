using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrawlManagerLib;
using System.Reflection;

namespace BrawlSongManager {
	[DefaultEvent("ValueChanged")]
	public partial class CustomSongVolumeEditor : UserControl {
		private static Image SPEAKER = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("BrawlSongManager.speaker.png"));

		public bool ChangeMadeSinceCSVLoaded {get; private set;}

		private CustomSongVolume _csv;
		public CustomSongVolume CSV {
			get {
				return _csv;
			}
			set {
				_csv = value;
				ChangeMadeSinceCSVLoaded = false;
				reload();
			}
		}

		private string _basenameRequested;
		private Song _song;
		public Song Song {
			get {
				return _song;
			}
			set {
				_basenameRequested = value == null ? null : value.Filename;
				_song = value;
				reload();
			}
		}
		public string SongFilename {
			get {
				return _basenameRequested;
			}
			set {
				_basenameRequested = value;
				_song = value == null
					? null
					: SongIDMap.Songs.Where(s => s.Filename == value).FirstOrDefault();
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

		public Image VolumeIcon {
			get {
				return pictureBox1.BackgroundImage;
			}
			set {
				pictureBox1.BackgroundImage = value == null ? value : BitmapUtilities.Resize(value, pictureBox1.Size);
			}
		}

		public string VolumeToolTip {
			set {
				toolTip1.SetToolTip(pictureBox1, value);
			}
		}

		public event EventHandler ValueChanged;

		public CustomSongVolumeEditor() {
			InitializeComponent();
		}

		private void reload() {
			this.VolumeToolTip = null;
			this.VolumeIcon = null;
			btnAdd.Text = "Add";

			lblSongID.Text =
				_basenameRequested == null ? ""
				: Song == null ? "Playback volume:"
				: Song.ID.ToString("X4");

			if (_basenameRequested == null) {
				btnAdd.Visible = false;
				lblUnknownVolume.Visible = false;
				nudVolume.Visible = false;
				nudVolume.Enabled = false;
			} else if (Song == null) {
				this.VolumeToolTip = "Filename not recognized - volume will only affect playback in this program and will not be saved";
				this.VolumeIcon = SPEAKER;

				btnAdd.Visible = false;
				lblUnknownVolume.Visible = false;
				nudVolume.Visible = true;
				nudVolume.Enabled = true;
				nudVolume.Value = 80;
			} else if (CSV != null && CSV.Settings.ContainsKey(Song.ID)) {
				this.VolumeToolTip = "Custom Song Volume code set";

				btnAdd.Text = "Remove";
				btnAdd.Visible = true;
				lblUnknownVolume.Visible = false;
				nudVolume.Visible = true;
				nudVolume.Enabled = true;
				nudVolume.Value = CSV.Settings[Song.ID];
			} else if (Song.DefaultVolume == null) {
				this.VolumeToolTip = "Default volume unknown";
				this.VolumeIcon = SystemIcons.Warning.ToBitmap();

				btnAdd.Visible = true;
				lblUnknownVolume.Visible = true;
				nudVolume.Visible = true;
				nudVolume.Enabled = false;
				nudVolume.Value = 80;
			} else {
				btnAdd.Visible = true;
				lblUnknownVolume.Visible = false;
				nudVolume.Visible = true;
				nudVolume.Enabled = false;
				nudVolume.Value = Song.DefaultVolume ?? 0;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			if (CSV.Settings.ContainsKey(Song.ID)) {
				CSV.Settings.Remove(Song.ID);
			} else {
				CSV.Settings.Add(Song.ID, (byte)nudVolume.Value);
			}
			ChangeMadeSinceCSVLoaded = true;
			reload();
		}

		private void nudVolume_ValueChanged(object sender, EventArgs e) {
			// Don't update the CSV code if the song is unknown (in which case the number spinner acts only as a playback control)
			if (nudVolume.Enabled && Song != null) {
				byte oldval = CSV.Settings[Song.ID];
				if (oldval != Value) {
					ChangeMadeSinceCSVLoaded = true;
					CSV.Settings[Song.ID] = Value;
				}
			}
			if (ValueChanged != null) ValueChanged(this, new EventArgs());
		}
	}
}
