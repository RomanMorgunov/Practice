using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Bullet : Subject
    {
        const int SPEED = 10;

        internal Direction Direction;

        internal Bullet(int x, int y, int width, int height, Direction direction)
            :base (x, y, width, height)
        {
            this.Direction = direction;
        }

        internal void Move()
        {
            switch (this.Direction)
            {
                case Direction.Left:
                    X -= SPEED;
                    break;

                case Direction.Up:
                    Y -= SPEED;
                    break;

                case Direction.Right:
                    X += SPEED;
                    break;

                case Direction.Down:
                    Y += SPEED;
                    break;
            }
        }
    }
}
