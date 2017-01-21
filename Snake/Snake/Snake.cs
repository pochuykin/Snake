using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Snake: Figure
    {
        private Direction direction;
        public Snake(Line l, Direction d)
        {
            pList.AddRange(l.getList());
            direction = d;
        }
        private void SetDirection(Direction d)
        {
            direction = d;
            Move();
        }
        private Point GetNextPoint()
        {
            Point head = new Point(pList.Last());
            head.Move(1, direction);
            return head;
        }
        public void HandleKey(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.RightArrow: if (direction != Direction.Left && direction != Direction.Right) { SetDirection(Direction.Right); } break;
                case ConsoleKey.LeftArrow: if (direction != Direction.Left && direction != Direction.Right) { SetDirection(Direction.Left); } break;
                case ConsoleKey.UpArrow: if (direction != Direction.Down && direction != Direction.Up) { SetDirection(Direction.Up); } break;
                case ConsoleKey.DownArrow: if (direction != Direction.Down && direction != Direction.Up) { SetDirection(Direction.Down); } break;
            }
        }
        public void Move()
        {
            Point tail = new Point(pList.First());
            Point head = GetNextPoint();
            pList.Add(head);
            if (head.getX() > tail.getX())
            {
                if (!Hit(Program.food))
                {
                    pList.RemoveAt(0);
                    tail.Delete();
                }
                else Eat();
                head.Draw();
            }
            else
            {
                head.Draw();
                if (!Hit(Program.food))
                {
                    tail.Delete();
                    pList.RemoveAt(0);
                }
                else Eat();
            }
        }
        private void Clash()
        {
            char sym = '@';
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Point p = new Point(pList.Last().getX(), pList.Last().getY(), sym);
            p.Draw();
            Console.ForegroundColor = c;
        }
        public bool Hit(Figure f)
        {
            bool result = false;
            List<Point> list = f.getList().ToList();
            if (f is Snake) list.RemoveAt(list.Count()-1);
            foreach (Point p in list) result |= Hit(p);
            if (result && !(f is Food)) Clash();
            return result;
        }
        public bool Hit(Point p)
        {
            return p.Hit(pList.Last());
        }
        public void Eat()
        {
            Program.food.Eat();
            PrintPoints();
        }
        public void PrintPoints()
        {
            Console.SetCursorPosition(0, Program.playground.height);
            Console.Write((pList.Count() - 5) * 10);
        }
    }
}
