using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Point
    {
        int x;
        int y;
        char s;
        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
            this.s = p.s;
        }
        public Point(int x,int y,char s)
        {
            this.x = x;
            this.y = y;
            this.s = s;
        }
        public int getX() { return x; }
        public int getY() { return y; }
        public void Move(int dx,Direction d)
        {
                 if (d == Direction.Left)  { this.x -= dx; }
            else if (d == Direction.Right) { this.x += dx; }
            else if (d == Direction.Up)    { this.y -= dx; }
            else if (d == Direction.Down)  { this.y += dx; }
        }
        public void Draw()
        {
            //Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(x, y);
            Console.Write(s);
            //Console.ForegroundColor = ConsoleColor.Black;
        }
        public void Delete()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }
        public bool Hit(Point p)
        {
            return x == p.x && y == p.y;
        }
        public bool Hit(Figure f)
        {
            bool result = false;
            List<Point> pList = f.getList().ToList();
            foreach (Point p in pList) result |= Hit(p);
            return result;
        }
    }
}
