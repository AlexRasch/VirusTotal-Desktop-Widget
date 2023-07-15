using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget.Forms
{
    class GroupBox : ThemeContainerControl
    {

        public GroupBox()
        {
            AllowTransparent();
            _Border1 = new Pen(Color.FromArgb(90, Color.Black));
            _Border2 = new Pen(Color.FromArgb(14, Color.White));
        }

        private Pen _Border1;
        public Color Border1
        {
            get { return _Border1.Color; }
            set
            {
                _Border1 = new Pen(value);
                Invalidate();
            }
        }

        private Pen _Border2;
        public Color Border2
        {
            get { return _Border2.Color; }
            set
            {
                _Border2 = new Pen(value);
                Invalidate();
            }
        }

        private Color _FillColor = Color.Transparent;
        public Color FillColor
        {
            get { return _FillColor; }
            set
            {
                _FillColor = value;
                Invalidate();
            }
        }

        public override void PaintHook()
        {
            G.Clear(_FillColor);
            DrawBorders(_Border1, _Border2, ClientRectangle);
            DrawCorners(BackColor, ClientRectangle);
        }

    }
}
