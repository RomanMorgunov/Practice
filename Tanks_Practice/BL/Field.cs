using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BL
{
    public class Field
    {
        const int WALL_WIDTH = 33;
        const int WALL_HEIGHT = 33;
        const int ENTITY_WIDTH = 28;
        const int ENTITY_HEIGHT = 28;

        Kolobok _kolobok;
        List<Tank> _tanks;
        List<Subject> _walls;
        List<Subject> _water;
        List<Subject> _apples;
        List<Subject> _bullets;
        System.Timers.Timer timer;

        public int FieldWidth { get; private set; }
        public int FieldHeight { get; private set; }
        public int TanksCount { get; private set; }
        public int AppleCount { get; private set; }
        public int SpeedEntities { get; private set; }

        event EventHandler OnGameOver;

        public Field(int fieldWidth, int fieldHeight, int tanksCount, int appleCount, int speedEntities, 
            EventHandler onGameOver)
        {
            FieldWidth = fieldWidth;
            FieldHeight = fieldHeight;
            TanksCount = tanksCount;
            AppleCount = appleCount;
            SpeedEntities = speedEntities;
            OnGameOver += onGameOver;

            _bullets = new List<Subject>();
            _tanks = new List<Tank>(TanksCount);
            _apples = new List<Subject>(AppleCount);
            _kolobok = new Kolobok(FieldWidth / 2 - ENTITY_WIDTH, FieldHeight - ENTITY_HEIGHT,
                ENTITY_WIDTH, ENTITY_HEIGHT, SpeedEntities);

            for (int i = 0; i < TanksCount; i++)
            {
                _tanks.Add(new Tank(2 * ENTITY_WIDTH, 0, ENTITY_WIDTH, ENTITY_HEIGHT, SpeedEntities));
            }

            InitBarriers(FieldWidth, FieldHeight);

            timer = new System.Timers.Timer(25);
            timer.AutoReset = true;
            timer.Elapsed += Simulation;
            timer.Start();
        }

        void InitBarriers(int fieldWidth, int fieldHeight)
        {
            _walls = new List<Subject>();
            _water = new List<Subject>();

            for (int x = WALL_WIDTH; x < fieldWidth; x *= WALL_WIDTH)
            {
                _walls.Add(new Subject(x, WALL_HEIGHT, WALL_WIDTH, WALL_HEIGHT));
                _walls.Add(new Subject(x, fieldHeight - WALL_HEIGHT, WALL_WIDTH, WALL_HEIGHT));
            }
        }

        void Simulation(object sender, System.Timers.ElapsedEventArgs e)
        {

        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Resources.kolobok_test, _kolobok.X, _kolobok.Y);
            foreach (var item in _tanks)
            {
                g.DrawImage(Resources.tank_test, item.X, item.Y);
            }
            foreach (var item in _walls)
            {
                g.DrawImage(Resources.brick, item.X, item.Y);
            }
            //foreach (var item in _apples)
            //{
            //    flagGraphic.DrawImage(, item.X, item.Y);
            //}
            //foreach (var item in _bullets)
            //{
            //    flagGraphic.DrawImage(, item.X, item.Y);
            //}
        }

        public void KeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.A:
                    _kolobok.Move(Direction.Left, in _walls, FieldWidth, FieldHeight);
                    break;

                case Keys.W:
                    _kolobok.Move(Direction.Up, in _walls, FieldWidth, FieldHeight);
                    break;

                case Keys.D:
                    _kolobok.Move(Direction.Right, in _walls, FieldWidth, FieldHeight);
                    break;

                case Keys.S:
                    _kolobok.Move(Direction.Down, in _walls, FieldWidth, FieldHeight);
                    break;

                case Keys.Space:
                    _bullets.Add(_kolobok.Shoot());
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
