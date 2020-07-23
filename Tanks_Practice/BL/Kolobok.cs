using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class Kolobok : Entity
    {
        internal Kolobok(int x, int y, int width, int height, int speed)
            : base(x, y, width, height, speed) { }

        internal void Move(Direction direction, in List<Subject> walls, int fieldWidth, int fieldHeight)
        {
            switch (direction)
            {
                case Direction.Left:
                    X -= Speed;

                    if (isMoving(walls, fieldWidth, fieldHeight))
                        DirectionOfFire = direction;
                    else
                        X += Speed;
                    break;

                case Direction.Up:
                    Y -= Speed;

                    if (isMoving(walls, fieldWidth, fieldHeight))
                        DirectionOfFire = direction;
                    else
                        Y += Speed;
                    break;

                case Direction.Right:
                    X += Speed;

                    if (isMoving(walls, fieldWidth, fieldHeight))
                        DirectionOfFire = direction;
                    else
                        X -= Speed;
                    break;

                case Direction.Down:
                    Y += Speed;

                    if (isMoving(walls, fieldWidth, fieldHeight))
                        DirectionOfFire = direction;
                    else
                        Y -= Speed;
                    break;
            }
        }

        internal Subject Shoot()
        {
            Subject bullet = null;

            switch (DirectionOfFire)
            {
                case Direction.Left:
                    bullet = new Subject(X - 2, Y + Height / 2, BULLET_WIDTH, BULLET_HEIGHT);
                    break;

                case Direction.Up:
                    bullet = new Subject(X + Width / 2, Y - 2, BULLET_WIDTH, BULLET_HEIGHT);
                    break;

                case Direction.Right:
                    bullet = new Subject(X + Width + 2, Y + Height / 2, BULLET_WIDTH, BULLET_HEIGHT);
                    break;

                case Direction.Down:
                    bullet = new Subject(X + Width / 2, Y + Height + 2, BULLET_WIDTH, BULLET_HEIGHT);
                    break;
            }

            return bullet;
        }
    }
}
