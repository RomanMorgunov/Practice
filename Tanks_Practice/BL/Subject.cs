using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class Subject
    {
        internal protected int X { get; protected set; }
        internal protected int Y { get; protected set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        internal Subject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public override bool Equals(object obj)
        {
            return obj is Tank tank &&
                   X == tank.X &&
                   Y == tank.Y;
        }

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
