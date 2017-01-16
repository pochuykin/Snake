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
        public Point() { }
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
        public Point(Point p, char s)
        {
            this.x = p.x;
            this.y = p.y;
            this.s = s;
        }
        public void Move(int dx,Direction d)
        {
                 if (d == Direction.Left)  { this.x -= dx; }
            else if (d == Direction.Right) { this.x += dx; }
            else if (d == Direction.Up)    { this.y -= dx; }
            else if (d == Direction.Down)  { this.y += dx; }
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
    }
}
