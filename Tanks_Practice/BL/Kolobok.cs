using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class Kolobok : Entity
    {
        int _applesCount;

        internal int ApplesCount => _applesCount;

        internal Kolobok(int x, int y, int width, int height, int speed)
            : base(x, y, width, height, speed)
        {
            _applesCount = 0;
        }

        internal void Move(Direction direction, in List<Subject> barriers, int fieldWidth, int fieldHeight)
        {
            DirectionOfFire = direction;

            switch (direction)
            {
                case Direction.Left:
                    X -= Speed;

                    if (!isMoving(barriers, fieldWidth, fieldHeight))
                        X += Speed;
                    break;

                case Direction.Up:
                    Y -= Speed;

                    if (!isMoving(barriers, fieldWidth, fieldHeight))
                        Y += Speed;
                    break;

                case Direction.Right:
                    X += Speed;

                    if (!isMoving(barriers, fieldWidth, fieldHeight))
                        X -= Speed;
                    break;

                case Direction.Down:
                    Y += Speed;

                    if (!isMoving(barriers, fieldWidth, fieldHeight))
                        Y -= Speed;
                    break;
            }
        }

        internal Bullet Shoot()
        {
            Bullet bullet = null;

            if ((DateTime.Now - _timeOfTheLastShot).TotalMilliseconds > SHOT_DELAY)
            {
                _timeOfTheLastShot = DateTime.Now;
                switch (DirectionOfFire)
                {
                    case Direction.Left:
                        bullet = new Bullet(X - BULLET_WIDTH - 1, Y + Height / 2 - BULLET_HEIGHT / 2, 
                            BULLET_WIDTH, BULLET_HEIGHT, DirectionOfFire);
                        break;

                    case Direction.Up:
                        bullet = new Bullet(X + Width / 2 - BULLET_WIDTH / 2, Y - BULLET_HEIGHT - 1, 
                            BULLET_WIDTH, BULLET_HEIGHT, DirectionOfFire);
                        break;

                    case Direction.Right:
                        bullet = new Bullet(X + Width, Y + Height / 2 - BULLET_HEIGHT / 2, 
                            BULLET_WIDTH, BULLET_HEIGHT, DirectionOfFire);
                        break;

                    case Direction.Down:
                        bullet = new Bullet(X + Width / 2 - BULLET_WIDTH / 2, Y + Height, 
                            BULLET_WIDTH, BULLET_HEIGHT, DirectionOfFire);
                        break;
                }
            }

            return bullet;
        }

        internal void Eat() => _applesCount++;
    }
}
