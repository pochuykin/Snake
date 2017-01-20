using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Snake: Figure
    {
        Direction direction;
        Food food;
        public Snake(Line l, Direction d)
        {
            pList.AddRange(l.getList());
            direction = d;
        }
        public void SetFood(Food food)
        {
            this.food = food;
        }
        void SetDirection(Direction d)
        {
            direction = d;
        }
        Point GetNextPoint()
        {
            Point head = new Point(pList.Last());
            head.Move(1, direction);
            return head;
        }
        public void HandleKey(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.RightArrow && direction != Direction.Left && direction != Direction.Right) { SetDirection(Direction.Right); }
            else if (key.Key == ConsoleKey.LeftArrow && direction != Direction.Left && direction != Direction.Right) { SetDirection(Direction.Left); }
            else if (key.Key == ConsoleKey.UpArrow && direction != Direction.Down && direction != Direction.Up) { SetDirection(Direction.Up); }
            else if (key.Key == ConsoleKey.DownArrow && direction != Direction.Down && direction != Direction.Up) { SetDirection(Direction.Down); }
        }
        public void Move()
        {
            Point tail = new Point(pList.First());
            Point head = GetNextPoint();
            pList.Add(head);
            if (head.getX() > tail.getX())
            {
                if (!Hit(food))
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
                if (!Hit(food))
                {
                    tail.Delete();
                    pList.RemoveAt(0);
                }
                else Eat();
            }
        }
        public bool Hit(Figure f)
        {
            bool result = false;
            List<Point> list = f.getList().ToList();
            if (f is Snake) list.RemoveAt(list.Count()-1);
            foreach (Point p in list) result |= Hit(p);
            if (result && !(f is Food))
            {
                ConsoleColor c = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Point p = new Point(pList.Last().getX(), pList.Last().getY(), '@');
                p.Draw();
                Console.ForegroundColor = c;
            }
            return result;
        }
        public bool Hit(Point p)
        {
            return p.Hit(pList.Last());
        }
        public void Eat()
        {
            food.Eat();
            PrintPoints();
        }
        public void PrintPoints()
        {
            Console.SetCursorPosition(0, PlayGround.height);
            Console.Write((pList.Count() - 5) * 10);
        }
    }
}
