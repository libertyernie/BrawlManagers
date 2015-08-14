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

        [Bindable(true), DefaultValue(0.5), Description("The maximum proportion (out of 1.0) of the length of the splitter taken up by the button")]
        public double MaxProportion { get; set; }

        [Bindable(true), DefaultValue(64), Description("Tne length of the button. Ignored if Proportion is not null")]
        public int ButtonLength { get; set; }

        private Cursor OldCursor;

        [Bindable(true), DefaultValue(true), Description("Whether the splitter can be moved")]
        public bool AllowResizing { get; set; }

        public BrawlSplitter() {
            SeparatorColorDark = SystemColors.ControlDark;
            SeparatorColorLight = SystemColors.ControlLightLight;
            Height = 11;
            MaxProportion = 0.5;
            ButtonLength = 64;
            AllowResizing = true;

            Button = new Button() {
                Cursor = Cursors.Default,
                FlatStyle = FlatStyle.Popup
            };
            this.Controls.Add(Button);

            this.MouseEnter += BrawlSplitter_MouseEnter;

            this.Resize += BrawlSplitter_Resize;
            this.Button.Click += Button_Click;
            this.Button.Paint += Button_Paint;
        }

        void BrawlSplitter_MouseEnter(object sender, EventArgs e) {
            if (!AllowResizing) {
                MinSize = this.SplitPosition;
                MinExtra = this.Parent.Width - this.SplitPosition;
                OldCursor = Cursor;
                Cursor = Cursors.Default;
            } else if (OldCursor != null) {
                Cursor = OldCursor;
                OldCursor = null;
            }
        }

        void Button_Paint(object sender, PaintEventArgs e) {
            SolidBrush brush = new SolidBrush(SystemColors.ControlText);
            if (ControlToHide != null) {
                if (this.Width > this.Height) {
                    int top = (Button.Height / 2) - 2;
                    int bottom = (Button.Height / 2) + 2;
                    int left = (Button.Width / 2) - 4;
                    int right = (Button.Width / 2) + 4;
                    if (ControlToHide.Visible ^ (Dock == DockStyle.Bottom || Dock == DockStyle.Left)) {
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
                    if (ControlToHide.Visible ^ (Dock == DockStyle.Bottom || Dock == DockStyle.Left)) {
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
                if (this.Width * MaxProportion < ButtonLength) {
                    Button.Width = (int)(this.Width * MaxProportion);
                    Button.Height = this.Height;
                    Button.Top = 0;
                    Button.Left = (int)(this.Width * (1.0 - MaxProportion) / 2);
                } else {
                    Button.Width = ButtonLength;
                    Button.Height = this.Height;
                    Button.Top = 0;
                    Button.Left = (this.Width - ButtonLength) / 2;
                }
            } else if (this.Width < this.Height) {
                // tall
                if (this.Height * MaxProportion < ButtonLength) {
                    Button.Width = this.Width;
                    Button.Height = (int)(this.Height * MaxProportion);
                    Button.Top = (int)(this.Height * (1.0 - MaxProportion) / 2);
                    Button.Left = 0;
                } else {
                    Button.Width = this.Width;
                    Button.Height = ButtonLength;
                    Button.Top = (this.Height - ButtonLength) / 2;
                    Button.Left = 0;
                }
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
