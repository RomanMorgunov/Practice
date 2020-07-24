using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Tank : Entity
    {
        //in percents
        const int PROBABILITY_OF_SHOT = 1;
        const int PROBABILITY_OF_DIRECTION_CHANGE = 25;
        

        const int MOVE_DELAY = 500;

        DateTime _timeOfTheLastMove;

        internal Tank(int x, int y, int width, int height, int speed)
            : base(x, y, width, height, speed) { }

        internal Bullet Act(in Kolobok kolobok, in List<Subject> barriers, in List<Tank> tanks, int fieldWidth, int fieldHeight)
        {
            Move(barriers, fieldWidth, fieldHeight, tanks);
            return Shoot(in kolobok);            
        }

        void Move(in List<Subject> barriers, int fieldWidth, int fieldHeight, in List<Tank> tanks)
        {
            if ((DateTime.Now - _timeOfTheLastMove).TotalMilliseconds > MOVE_DELAY)
            {
                _timeOfTheLastMove = DateTime.Now;

                if (new Random().Next(101) <= PROBABILITY_OF_DIRECTION_CHANGE)
                    ToMove((Direction)new Random().Next(5), in barriers, fieldWidth, fieldHeight, in tanks);
                else
                    ToMove(this.DirectionOfFire, in barriers, fieldWidth, fieldHeight, in tanks);
            }
        }

        void ToMove(Direction direction, in List<Subject> barriers, int fieldWidth, int fieldHeight, in List<Tank> tanks)
        {
            DirectionOfFire = direction;
            switch (direction)
            {
                case Direction.Left:
                    X -= Speed;
                    if (!isMoving(barriers, fieldWidth, fieldHeight) || 
                        IsTank(tanks))
                    {
                        X += Speed;
                        DirectionOfFire = Direction.Right;
                    }
                    break;

                case Direction.Up:
                    Y -= Speed;
                    if (!isMoving(barriers, fieldWidth, fieldHeight) ||
                        IsTank(tanks))
                    {
                        Y += Speed;
                        DirectionOfFire = Direction.Down;
                    }
                    break;

                case Direction.Right:
                    X += Speed;
                    if (!isMoving(barriers, fieldWidth, fieldHeight) ||
                        IsTank(tanks))
                    {
                        X -= Speed;
                        DirectionOfFire = Direction.Left;
                    }
                    break;

                case Direction.Down:
                    Y += Speed;
                    if (!isMoving(barriers, fieldWidth, fieldHeight) ||
                        IsTank(tanks))
                    {
                        Y -= Speed;
                        DirectionOfFire = Direction.Up;
                    }
                    break;
            }
        }

        bool IsTank(List<Tank> tanks)
        {
            int count = 0;
            foreach (var item in tanks)
            {
                if (IsCollides(item.X, item.Y, item.Width, item.Height))
                {
                    count++;
                }

                //the list of tanks contains itself
                if (count > 1)
                    return true;
            }
            return false;
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
