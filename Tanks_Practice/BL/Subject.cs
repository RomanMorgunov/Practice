using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class Subject
    {
        internal protected int X { get; set; }
        internal protected int Y { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        internal Subject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
