using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Tank : Entity
    {
        //in percents
        const int PROBABILITY_OF_SHOT = 1;
        const int MOVE_DELAY = 500;

        DateTime _timeOfTheLastMove;

        internal Tank(int x, int y, int width, int height, int speed)
            : base(x, y, width, height, speed) { }

        internal Bullet Act(in Kolobok kolobok, in List<Subject> barriers, int fieldWidth, int fieldHeight)
        {
            Move(barriers, fieldWidth, fieldHeight);
            return Shoot(in kolobok);            
        }

        void Move(in List<Subject> barriers, int fieldWidth, int fieldHeight)
        {
            if ((DateTime.Now - _timeOfTheLastMove).TotalMilliseconds > MOVE_DELAY)
            {
                _timeOfTheLastMove = DateTime.Now;
                switch (new Random().Next(5))
                {
                    case (int)Direction.Left:
                        X -= Speed;
                        DirectionOfFire = Direction.Left;

                        if (!isMoving(barriers, fieldWidth, fieldHeight))
                            X += Speed;
                        break;

                    case (int)Direction.Up:
                        Y -= Speed;
                        DirectionOfFire = Direction.Up;

                        if (!isMoving(barriers, fieldWidth, fieldHeight))
                            Y += Speed;
                        break;

                    case (int)Direction.Right:
                        X += Speed;
                        DirectionOfFire = Direction.Right;

                        if (!isMoving(barriers, fieldWidth, fieldHeight))
                            X -= Speed;
                        break;

                    case (int)Direction.Down:
                        Y += Speed;
                        DirectionOfFire = Direction.Down;

                        if (!isMoving(barriers, fieldWidth, fieldHeight))
                            Y -= Speed;
                        break;
                }
            }
        }

        Bullet Shoot(in Kolobok kolobok)
        {
            Bullet bullet = null;

            if ((DateTime.Now - _timeOfTheLastShot).TotalMilliseconds > SHOT_DELAY &&
                new Random().Next(101) <= PROBABILITY_OF_SHOT)
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
    }
}
