using System;
using System.Collections.Generic;

namespace Snake
{
    class Point
    {
        private int X { get; set; }
        private int Y { get; set; }
        private char Sym { get; set; }
        private ConsoleColor Color { get; set; }
        public Point(Point p, char s)
        {
            X = p.X;
            Y = p.Y;
            Sym = s;
            Color = p.Color;
        }
        public Point(Point p, char s, ConsoleColor color)
        {
            X = p.X;
            Y = p.Y;
            Sym = s;
            Color = color;
        }
        public Point(int x, int y, char s, ConsoleColor color)
        {
            X = x;
            Y = y;
            Sym = s;
            Color = color;
        }
        public void Move(int dx, Direction d)
        {
            if (d == Direction.Left) { this.X -= dx; }
            else if (d == Direction.Right) { this.X += dx; }
            else if (d == Direction.Up) { this.Y -= dx; }
            else if (d == Direction.Down) { this.Y += dx; }
        }
        public void Draw()
        {
            ConsoleColor tmpColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(Sym);
            Console.ForegroundColor = tmpColor;
        }
        public void Draw(char s, ConsoleColor color = ConsoleColor.White)
        {
            ConsoleColor tmpColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(X, Y);
            Console.Write(s);
            Console.ForegroundColor = tmpColor;
        }
        public void Draw(char s)
        {
            ConsoleColor tmpColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(s);
            Console.ForegroundColor = tmpColor;
        }
        public void Delete()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
        public bool Hit(Point p)
        {
            return this == p;
        }
        public bool Hit(Figure f)
        {
            bool result = false;
            List<Point> pList = f.GetList();
            foreach (Point p in pList) result |= Hit(p);
            return result;
        }
        public static bool operator !=(Point p1, Point p2)
        {
            if (!(p1 is object) || !(p2 is object)) return true;
            return p1.X!=p2.X || p1.Y!=p2.Y;
        }
        public static bool operator ==(Point p1, Point p2)
        {
            return !(p1 != p2);
        }
        public static bool operator >(Point p1, Point p2)
        {
            return p1.X > p2.X;
        }
        public static bool operator <(Point p1, Point p2)
        {
            return p1.X > p2.X;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            Point m = obj as Point;
            if (m as Point == null)
                return false;

            return m == this && m.Sym == this.Sym;
        }
        public override int GetHashCode()
        {
            return X*100+Y*10000+Sym;
        }
    }
}
