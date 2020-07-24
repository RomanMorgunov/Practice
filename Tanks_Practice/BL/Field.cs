using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace BL
{
    public class Field
    {
        const int BARRIER_WIDTH = 33;
        const int BARRIER_HEIGHT = 33;
        const int ENTITY_WIDTH = 28;
        const int ENTITY_HEIGHT = 28;
        const int APPLE_WIDTH = 15;
        const int APPLE_HEIGHT = 15;

        Kolobok _kolobok;
        List<Tank> _tanks;
        List<Subject> _walls;
        List<Subject> _water;
        List<Subject> _apples;
        List<Bullet> _bullets;

        public int FieldWidth { get; private set; }
        public int FieldHeight { get; private set; }
        public int TanksCount { get; private set; }
        public int AppleCount { get; private set; }
        public int SpeedEntities { get; private set; }
        public int Score => _kolobok.ApplesCount;

        List<Subject> Barriers => _walls.Concat(_water).ToList();

        public event EventHandler OnGameOver;
        public event EventHandler<TanksEventArgs> OnUpdateImage;

        public Field(int fieldWidth, int fieldHeight, int tanksCount, int appleCount, int speedEntities, 
            EventHandler onGameOver, EventHandler<TanksEventArgs> onUpdateImage)
        {
            FieldWidth = fieldWidth;
            FieldHeight = fieldHeight;
            TanksCount = tanksCount;
            AppleCount = appleCount;
            SpeedEntities = speedEntities;
            OnGameOver += onGameOver;
            OnUpdateImage += onUpdateImage;

            _bullets = new List<Bullet>();
            _tanks = new List<Tank>(TanksCount);
            _apples = new List<Subject>(AppleCount);
            _kolobok = new Kolobok(FieldWidth / 2 - ENTITY_WIDTH, FieldHeight - ENTITY_HEIGHT,
                ENTITY_WIDTH, ENTITY_HEIGHT, SpeedEntities);            

            InitBarriers(FieldWidth, FieldHeight);
            SpawnTanks();
            SpawnAplles();
        }

        void InitBarriers(int fieldWidth, int fieldHeight)
        {
            _walls = new List<Subject>();
            _water = new List<Subject>();

            int centerY = FieldHeight / 2 - BARRIER_HEIGHT / 2;
            for (int x = 0; x < fieldWidth - BARRIER_WIDTH; x += 4 * BARRIER_WIDTH)
            {
                _water.Add(new Subject(x, centerY, BARRIER_WIDTH, BARRIER_HEIGHT));
                _water.Add(new Subject(x + BARRIER_WIDTH, centerY, BARRIER_WIDTH, BARRIER_HEIGHT));
            }

            //for (int x = BARRIER_WIDTH; x < fieldWidth; x *= BARRIER_WIDTH)
            //{
            //    _walls.Add(new Subject(x, BARRIER_HEIGHT, BARRIER_WIDTH, BARRIER_HEIGHT));
            //    _walls.Add(new Subject(x, fieldHeight - BARRIER_HEIGHT, BARRIER_WIDTH, BARRIER_HEIGHT));
            //}
        }

        public void Simulation()
        {
            SpawnTanks();
            SpawnAplles();
            MoveBullets();
            MoveTanks();
            CheckCollisions();
            OnUpdateImage?.Invoke(this, new TanksEventArgs(Draw(), _kolobok.ApplesCount));
        }

        void CheckCollisions()
        {
            CheckKolobokCollisionsWithTanks();
            CheckEntityCollisionsWithBullets();
        }

        void CheckKolobokCollisionsWithTanks()
        {
            if (Entity.IsCollides(_kolobok.X, _kolobok.Y, _kolobok.Width, _kolobok.Height, _tanks.Cast<Subject>().ToList()))
            {
                OnGameOver?.Invoke(this, new EventArgs());
                return;
            }
        }

        void CheckEntityCollisionsWithBullets()
        {
            //Collisions with kolobok
            if (Entity.IsCollides(_kolobok.X, _kolobok.Y, _kolobok.Width, _kolobok.Height, 
                _bullets.Cast<Subject>().ToList()))
            {
                OnGameOver?.Invoke(this, new EventArgs());
                return;
            }

            //Collisions with tanks
            for (int j = _bullets.Count - 1; j >= 0; j--)
            {
                bool isContinue = false;
                for (int i = _tanks.Count - 1; i >= 0; i--)
                {
                    if (Entity.IsCollides(_tanks[i].X, _tanks[i].Y, _tanks[i].Width, _tanks[i].Height,
                        _bullets[j].X, _bullets[j].Y, _bullets[j].Width, _bullets[j].Height))
                    {
                        _tanks.RemoveAt(i);
                        _bullets.RemoveAt(j);

                        isContinue = true;
                        break;
                    }
                }

                if (isContinue)
                    continue;

                for (int i = _walls.Count - 1; i >= 0; i--)
                {
                    if (Entity.IsCollides(_walls[i].X, _walls[i].Y, _walls[i].Width, _walls[i].Height,
                        _bullets[j].X, _bullets[j].Y, _bullets[j].Width, _bullets[j].Height))
                    {
                        _walls.RemoveAt(i);
                        _bullets.RemoveAt(j);

                        isContinue = true;
                        break;
                    }
                }

                if (isContinue)
                    continue;

                //remove bullet if it goes off screen
                if (!Entity.IsCollides(_bullets[j].X, _bullets[j].Y, _bullets[j].Width, _bullets[j].Height, 
                    0, 0, FieldWidth, FieldHeight))
                {
                    _bullets.RemoveAt(j);
                }
            }

            //Collision of a kolobok with apples
            for (int i = _apples.Count - 1; i >= 0; i--)
            {
                if (Entity.IsCollides(_kolobok.X, _kolobok.Y, _kolobok.Width, _kolobok.Height,
                    _apples[i].X, _apples[i].Y, _apples[i].Width, _apples[i].Height))
                {
                    _apples.RemoveAt(i);
                    _kolobok.Eat();
                }
            }
        }

        void MoveBullets()
        {
            foreach (var item in _bullets)
            {
                item.Move();
            }
        }

        void MoveTanks()
        {
            foreach (var item in _tanks)
            {
                Bullet b = item.Act(in _kolobok, Barriers, FieldWidth, FieldHeight);
                if (!(b is null))
                    _bullets.Add(b);
            }
        }

        void SpawnAplles()
        {
            int count = this.AppleCount - _apples.Count;
            Random random = new Random();
            Subject apple;
            for (int i = 0; i < count; i++)
            {
                do
                {
                    apple = new Subject(random.Next(0, FieldWidth - APPLE_WIDTH), random.Next(0, FieldHeight - APPLE_HEIGHT),
                        APPLE_WIDTH, APPLE_HEIGHT);
                } while (Entity.IsCollides(apple.X, apple.Y, apple.Width, apple.Height, Barriers));
                _apples.Add(apple);
            }
        }

        void SpawnTanks()
        {
            int count = this.TanksCount - _tanks.Count;
            Tank tank;
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                do
                {
                    tank = new Tank(random.Next(FieldWidth - ENTITY_WIDTH), random.Next(FieldHeight / 2 - ENTITY_HEIGHT),
                        ENTITY_WIDTH, ENTITY_HEIGHT, SpeedEntities);
                } while (Entity.IsCollides(tank.X, tank.Y, tank.Width, tank.Height, Barriers) ||
                Entity.IsCollides(tank.X, tank.Y, tank.Width, tank.Height, _tanks.Cast<Subject>().ToList()));
                _tanks.Add(tank);
            }
        }

        Bitmap Draw()
        {
            Bitmap bitmap = new Bitmap(FieldWidth, FieldHeight);
            Graphics g = Graphics.FromImage(bitmap);

            g.DrawImage(Resources.kolobok_test, _kolobok.X, _kolobok.Y);
            foreach (var item in _tanks)
            {
                g.DrawImage(Resources.tank_test, item.X, item.Y);
            }
            foreach (var item in _walls)
            {
                g.DrawImage(Resources.brick, item.X, item.Y);
            }
            foreach (var item in _water)
            {
                g.DrawImage(Resources.water, item.X, item.Y);
            }
            foreach (var item in _bullets)
            {
                g.DrawImage(Resources.bullet, item.X, item.Y);
            }
            foreach (var item in _apples)
            {
                g.DrawImage(Resources.apple, item.X, item.Y);
            }

            return bitmap;
        }

        public void KeyDown(Keys key)
        {
            List<Subject> barriers = Barriers;

            switch (key)
            {
                case Keys.A:
                    _kolobok.Move(Direction.Left, in barriers, FieldWidth, FieldHeight);
                    break;

                case Keys.W:
                    _kolobok.Move(Direction.Up, in barriers, FieldWidth, FieldHeight);
                    break;

                case Keys.D:
                    _kolobok.Move(Direction.Right, in barriers, FieldWidth, FieldHeight);
                    break;

                case Keys.S:
                    _kolobok.Move(Direction.Down, in barriers, FieldWidth, FieldHeight);
                    break;

                case Keys.Space:
                    Bullet b = _kolobok.Shoot();
                    if (!(b is null))
                        _bullets.Add(b);
                    break;
            }
        }
    }

    public enum EntityType
    {
        Kolobok,
        Tank
    }
}
