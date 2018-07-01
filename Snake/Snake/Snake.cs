using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    class Snake: Figure
    {
        private Direction direction = Direction.Right;
        private const int beginLength = 5;
        private const int speedBegin = 200;
        private const int speedEnd = 10;
        public float speed = speedBegin;
        public int isTunnel = 0;
        public Snake()
        {
            Sym = 'O';
            Color = System.ConsoleColor.Gray;
            PList.AddRange(new Line(new Point(5, 5, Sym, Color), beginLength, direction, Sym).GetList());
            PrintPoints();
        }
        private void SetDirection(Direction d)
        {
            direction = d;
            Step();
        }
        private Point GetNextPoint()
        {
            Point head = new Point(PList.Last(), Sym);
            if (isTunnel!=1)
                head.Move(1, direction); 
            else
            {
                Point tunnelPart1 = Program.tunnel.GetList()[0];
                Point tunnelPart2 = Program.tunnel.GetList()[1];
                if (head.Hit(tunnelPart1))
                {
                    head = new Point(tunnelPart2, Sym, Color);
                    direction = Program.tunnel.directions[1];
                }
                else if (head.Hit(tunnelPart2))
                {
                    head = new Point(tunnelPart1, Sym, Color);
                    direction = Program.tunnel.directions[0];
                }
                ++isTunnel;
            }
            return head;
        }
        public void HandleKey(System.ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case System.ConsoleKey.RightArrow: if (direction != Direction.Left && direction != Direction.Right) { SetDirection(Direction.Right); } break;
                case System.ConsoleKey.LeftArrow: if (direction != Direction.Left && direction != Direction.Right) { SetDirection(Direction.Left); } break;
                case System.ConsoleKey.UpArrow: if (direction != Direction.Down && direction != Direction.Up) { SetDirection(Direction.Up); } break;
                case System.ConsoleKey.DownArrow: if (direction != Direction.Down && direction != Direction.Up) { SetDirection(Direction.Down); } break;
            }
        }
        public void Move()
        {
            Point tail = PList.First();
            Point head = GetNextPoint();
            PList.Add(head);
            if (head > tail)
            {
                if (!Hit(Program.food))
                {
                    PList.Remove(tail);
                    tail.Delete();
                }
                else Eat();
                if(!Hit(Program.tunnel))
                    head.Draw();
            }
            else
            {
                if (!Hit(Program.tunnel))
                    head.Draw();
                if (!Hit(Program.food))
                {
                    tail.Delete();
                    PList.Remove(tail);
                }
                else Eat();
            }
            Program.timeLastMove = System.DateTime.Now;
        }
        private void CheckTunnel()
        {
            Point head = Program.snake.GetList().Last();
            if (Program.tunnel.GetList().Count!=0)
            {
                Point tun1 = Program.tunnel.GetList().First();
                Point tun2 = Program.tunnel.GetList().Last();
                if (isTunnel == 0 && ((head.Hit(tun1) && !head.Hit(tun2)) || (!head.Hit(tun1) && head.Hit(tun2))))
                {
                    ++isTunnel;
                }
                else if (isTunnel == 2 && !base.Hit(Program.tunnel))
                {
                    isTunnel = 0;
                    Program.tunnel.Delete();
                }
            }
        }
        public void Step()
        {
            Program.snake.Move();
            CheckTunnel();
            if (Program.snake.Hit(Program.playground) || Program.snake.Hit(Program.snake))
                Program.playground.GameOver();
        }
        private void Clash()
        {
            char sym = '@';
            Point p = new Point(PList.Last(), sym, System.ConsoleColor.Red);
            p.Draw();
        }
        protected override bool Hit(Figure f)
        {
            bool result = false;
            List<Point> list = f.GetList().ToList();
            if (f is Snake)
                list.Remove(list.Last());
            if (f is PlayGround && Program.tunnel.GetList().Count!=0)
            {
                List<Point> l = new List<Point>();
                foreach (Point pTunel in Program.tunnel.GetList())
                    foreach (Point p in list)
                        if (p == pTunel)
                            l.Add(p);
                foreach (Point p in l)
                    list.Remove(p);
            }
            foreach (Point p in list)
                result |= Hit(p);
            if (result && !(f is Food) && !(f is Tunnel))
                Clash();
            return result;
        }
        public bool Hit(Point p)
        {
            return p.Hit(PList.Last());
        }
        public void Eat()
        {
            Program.food.Eat();
            speed -= (speedBegin - speedEnd) / (Program.playground.height * Program.playground.width);
            PrintPoints();
        }
        public void PrintPoints()
        {
            System.Console.SetCursorPosition(Program.playground.score.Length, Program.playground.height);
            System.Console.Write((PList.Count() - beginLength) * 10);
        }
    }
}
