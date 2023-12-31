﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget.Forms
{
    class FButton : Control
    {

        private bool Shadow_ = true;
        public bool Shadow
        {
            get { return Shadow_; }
            set
            {
                Shadow_ = value;
                Invalidate();
            }
        }

        public FButton()
        {
            SetStyle((ControlStyles)8198, true);
            Colors = new Pigment[] {
            new Pigment("Border", 254, 133, 0),
            new Pigment("Backcolor", 25, 25, 25),
            new Pigment("Highlight", 255, 197, 19),
            new Pigment("Gradient1", 255, 175, 12),
            new Pigment("Gradient2", 255, 127, 1),
            new Pigment("Text Color", Color.White),
            new Pigment("Text Shadow", 30, 0, 0, 0)
        };
            Font = new Font("Verdana", 8);
        }

        const byte Count = 7;
        private Pigment[] C;
        public Pigment[] Colors
        {
            get { return C; }
            set
            {
                if (value.Length != Count)
                    throw new IndexOutOfRangeException();

                P1 = new Pen(value[0].Value);
                P2 = new Pen(value[2].Value);

                B1 = new SolidBrush(value[6].Value);
                B2 = new SolidBrush(value[5].Value);

                C = value;
                Invalidate();
            }
        }
        private Pen P1;
        private Pen P2;
        private SolidBrush B1;
        private SolidBrush B2;
        private LinearGradientBrush B3;
        private Size SZ;

        private Point PT;
        private Graphics G;
        private Bitmap B;
        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            if (Down)
            {
                B3 = new LinearGradientBrush(ClientRectangle, C[4].Value, C[3].Value, 90f);
            }
            else
            {
                B3 = new LinearGradientBrush(ClientRectangle, C[3].Value, C[4].Value, 90f);
            }
            G.FillRectangle(B3, ClientRectangle);

            if (!string.IsNullOrEmpty(Text))
            {
                SZ = G.MeasureString(Text, Font).ToSize();
                PT = new Point(Convert.ToInt32(Width / 2 - SZ.Width / 2), Convert.ToInt32(Height / 2 - SZ.Height / 2));
                if (Shadow_)
                    G.DrawString(Text, Font, B1, PT.X + 1, PT.Y + 1);
                G.DrawString(Text, Font, B2, PT);
            }

            G.DrawRectangle(P1, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawRectangle(P2, new Rectangle(1, 1, Width - 3, Height - 3));

            B.SetPixel(0, 0, C[1].Value);
            B.SetPixel(Width - 1, 0, C[1].Value);
            B.SetPixel(Width - 1, Height - 1, C[1].Value);
            B.SetPixel(0, Height - 1, C[1].Value);

            e.Graphics.DrawImage(B, 0, 0);
            B3.Dispose();
            G.Dispose();
            B.Dispose();
        }

        private bool Down;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Down = true;
                Invalidate();
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            Down = false;
            Invalidate();
            base.OnMouseUp(e);
        }

    }
}
