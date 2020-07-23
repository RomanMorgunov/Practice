using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal abstract class Entity : Subject
    {
        protected const int BULLET_WIDTH = 4;
        protected const int BULLET_HEIGHT = 4;

        internal protected int Speed { get; protected set; }
        internal protected Direction DirectionOfFire { get; protected set; }

        internal Entity(int x, int y, int width, int height, int speed)
            :base (x, y, width, height)
        {
            Speed = speed;
            DirectionOfFire = Direction.Up;
        }

        internal static bool IsCollides(int x, int y, int width, int height, int x2, int y2, int width2, int height2)
        {
            return !(x + width <= x2 || x > x2 + width2 || y + height <= y2 || y > y2 + height2);
        }

        internal static bool IsCollides(int x, int y, int width, int height, List<Subject> subjects)
        {
            foreach (var item in subjects)
            {
                if (IsCollides(x, y, width, height, item.X, item.Y, item.Width, item.Height))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool IsCollides(int x2, int y2, int width2, int height2)
        {
            return !(X + Width <= x2 || X > x2 + width2 || Y + Height <= y2 || Y > y2 + height2);
        }

        internal bool IsCollides(List<Subject> subjects)
        {
            foreach (var item in subjects)
            {
                if (IsCollides(item.X, item.Y, item.Width, item.Height))
                {
                    return true;
                }
            }
            return false;
        }

        protected bool isMoving(in List<Subject> walls, int fieldWidth, int fieldHeight)
        {
            return (X >= 0 && X + Width <= fieldWidth && Y >= 0 && Y + Height <= fieldHeight && !IsCollides(walls));
        }
    }

    enum Direction
    {
        Left,
        Up,
        Right,
        Down
    }
}
