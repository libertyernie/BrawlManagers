using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlManagerLib {
    public class BrawlSplitter : Splitter {
        public Button Button { get; private set; }

        [Bindable(true), DefaultValue(null), Description("The control that the button in the splitter will show/hide")]
        public Control ControlToHide { get; set; }

        [Bindable(true), DefaultValue(typeof(Color), "ControlDark"), Description("The color of the seperator on either side of the button")]
        public Color SeparatorColorDark { get; set; }

        [Bindable(true), DefaultValue(typeof(Color), "ControlLightLight"), Description("The color of the seperator on either side of the button")]
        public Color SeparatorColorLight { get; set; }

        public BrawlSplitter() {
            SeparatorColorDark = SystemColors.ControlDark;
            SeparatorColorLight = SystemColors.ControlLightLight;
            Height = 11;

            Button = new Button() {
                Cursor = Cursors.Default,
                FlatStyle = FlatStyle.Popup
            };
            this.Controls.Add(Button);

            this.Resize += BrawlSplitter_Resize;
            this.Button.Click += Button_Click;
            this.Button.Paint += Button_Paint;
        }

        void Button_Paint(object sender, PaintEventArgs e) {
            SolidBrush brush = new SolidBrush(SystemColors.ControlText);
            if (ControlToHide != null) {
                if (this.Width > this.Height) {
                    int top = (Button.Height / 2) - 2;
                    int bottom = (Button.Height / 2) + 2;
                    int left = (Button.Width / 2) - 4;
                    int right = (Button.Width / 2) + 4;
                    if (ControlToHide.Visible ^ (Dock == DockStyle.Top || Dock == DockStyle.Left)) {
                        e.Graphics.FillPolygon(brush, new Point[] {
                            new Point(Button.Width / 2, top),
                            new Point(left, bottom),
                            new Point(right, bottom)
                        });
                    } else {
                        e.Graphics.FillPolygon(brush, new Point[] {
                            new Point(Button.Width / 2, bottom),
                            new Point(left, top),
                            new Point(right, top)
                        });
                    }
                } else {
                    int top = (Button.Height / 2) - 4;
                    int bottom = (Button.Height / 2) + 4;
                    int left = (Button.Width / 2) - 2;
                    int right = (Button.Width / 2) + 2;
                    if (ControlToHide.Visible ^ (Dock == DockStyle.Top || Dock == DockStyle.Left)) {
                        e.Graphics.FillPolygon(brush, new Point[] {
                            new Point(right, Button.Height / 2),
                            new Point(left, top),
                            new Point(left, bottom)
                        });
                    } else {
                        e.Graphics.FillPolygon(brush, new Point[] {
                            new Point(left, Button.Height / 2),
                            new Point(right, top),
                            new Point(right, bottom)
                        });
                    }
                }
            }
        }

        void BrawlSplitter_Resize(object sender, EventArgs e) {
            if (this.Width > this.Height) {
                // wide
                Button.Width = this.Width / 2;
                Button.Height = this.Height;
                Button.Top = 0;
                Button.Left = 1 * this.Width / 4;
            } else if (this.Width < this.Height) {
                // tall
                Button.Width = this.Width;
                Button.Height = this.Height / 2;
                Button.Top = 1 * this.Height / 4;
                Button.Left = 0;
            } else {
                // square
                Button.Width = this.Width;
                Button.Height = this.Height;
                Button.Top = 0;
                Button.Left = 0;
            }
        }

        void Button_Click(object sender, EventArgs e) {
            if (ControlToHide != null) {
                ControlToHide.Visible = !ControlToHide.Visible;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Pen pen = new Pen(this.SeparatorColorDark, 1);
            Pen pen2 = new Pen(this.SeparatorColorLight, 1);
            if (this.Width > this.Height) {
                // wide
                int middle = this.Height / 2;
                e.Graphics.DrawLine(pen, 0, middle, this.Width, middle);
                e.Graphics.DrawLine(pen2, 0, middle - 1, this.Width, middle - 1);
            } else if (this.Width < this.Height) {
                // tall
                int middle = this.Width / 2;
                e.Graphics.DrawLine(pen, middle, 0, middle, this.Height);
                e.Graphics.DrawLine(pen2, middle - 1, 0, middle - 1, this.Height);
            } else {
                // square - do nothing
            }
        }
    }
}
