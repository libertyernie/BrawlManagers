using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrawlStageManager {
	public class NameCreator {
		public static NameCreatorSettings selectFont(NameCreatorSettings previous = null) {
			using (NameCreatorDialog d = new NameCreatorDialog()) {
				if (previous != null) d.Settings = previous;
				if (d.ShowDialog() == DialogResult.OK) {
					return d.Settings;
				} else {
					return null;
				}
			}
		}

		public static Bitmap createImage(NameCreatorSettings fontData, string text) {
			int linebreak = text.IndexOf("\\n");
			if (linebreak > -1) {
				return createImage(fontData,
					text.Substring(0, linebreak),
					text.Substring(linebreak + 2));
			}

			Bitmap b = new Bitmap(208, 56);
			Graphics g = Graphics.FromImage(b);
			g.FillRectangle(new SolidBrush(Color.Black), 0, 0, 208, 56);

			bool corner = fontData.Corner;
			int x = corner ? -4 : 104;
			int y = corner ? 62 : 28 - fontData.VerticalOffset;
			g.DrawString(text, fontData.Font, new SolidBrush(Color.White), x, y, new StringFormat() {
				Alignment = corner ? StringAlignment.Near : StringAlignment.Center,
				LineAlignment = corner ? StringAlignment.Far : StringAlignment.Center,
			});
			return b;
		}

		public static Bitmap createImage(NameCreatorSettings fontData, string line1, string line2) {
			Bitmap b = new Bitmap(208, 56);
			Graphics g = Graphics.FromImage(b);
			g.FillRectangle(new SolidBrush(Color.Black), 0, 0, 208, 56);
			g.DrawString(line1, fontData.Font, new SolidBrush(Color.White), 104, 13 - fontData.VerticalOffset, new StringFormat() {
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center,
			});
			g.DrawString(line2, fontData.Font, new SolidBrush(Color.White), 104, 43 - fontData.VerticalOffset, new StringFormat() {
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center,
			});
			return b;
		}
	}
}
