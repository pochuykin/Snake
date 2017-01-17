using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Snake: Figure
    {
        Direction direction;
        public Snake(Line l, Direction d)
        {
            pList = new List<Point>();
            pList.AddRange(l.getList());
            direction = d;
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
            else if (key.Key == ConsoleKey.DownArrow && direction != Direction.Down && direction != Direction.Up) { SetDirection(Direction.Down); };
        }
        public void Move()
        {
            Point tail = new Point(pList.First(),' ');
            Point head = GetNextPoint();
            pList.Add(head);
            pList.RemoveAt(0);
            if (tail.x < head.x)
            {
                tail.Draw();
                head.Draw();
            }
            else
            {
                head.Draw();
                tail.Draw();
            }
        }
        public bool Hit(Figure f)
        {
            bool result = false;
            List<Point> pList = f.getList().ToList();
            if (f is Snake) pList.RemoveAt(pList.Count()-1);
                    
            foreach (Point p in pList) result |= Hit(p);
            return result;
        }
        public bool Hit(Point p)
        {
            return p.Hit(pList.Last());
        }
    }
}
