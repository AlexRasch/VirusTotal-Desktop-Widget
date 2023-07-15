using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget.Forms
{
    class Pigment
    {
        public string Name { get; set; }
        public Color Value { get; set; }

        public Pigment()
        {
        }

        public Pigment(string n, Color v)
        {
            Name = n;
            Value = v;
        }

        public Pigment(string n, byte a, byte r, byte g, byte b)
        {
            Name = n;
            Value = Color.FromArgb(a, r, g, b);
        }

        public Pigment(string n, byte r, byte g, byte b)
        {
            Name = n;
            Value = Color.FromArgb(r, g, b);
        }
    }
}
