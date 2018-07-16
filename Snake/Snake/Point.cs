using System;
using System.Collections.Generic;

namespace Snake
{
    class Point
    {
        private int x;
        private int y;
        private char sym;
        private ConsoleColor color;
        public int getX() { return x; }
        public int getY() { return y; }
        public int getSym() { return sym; }
        public ConsoleColor getColor() { return color; }
        public Point(Point p, char s)
        {
            this.x = p.x;
            this.y = p.y;
            this.sym = s;
            this.color = p.getColor();
        }
        public Point(Point p, char s, ConsoleColor color)
        {
            this.x = p.x;
            this.y = p.y;
            this.sym = s;
            this.color = color;
        }
        public Point(int x, int y, char s, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.sym = s;
            this.color = color;
        }
        //перемещение точки на dx в направлении direction
        public void move(int dx, Direction d)
        {
            if (d == Direction.Left) { this.x -= dx; }
            else if (d == Direction.Right) { this.x += dx; }
            else if (d == Direction.Up) { this.y -= dx; }
            else if (d == Direction.Down) { this.y += dx; }
        }
        //выводим точку в консоли
        public void draw()
        {
            //блокируем объект lockDraw, чтобы в этот же момент не рисовалась другая точка - не менялся цвет и не менялись коррдинаты
            lock (Program.lockDraw)
            {
                ConsoleColor tmpColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x, y);
                Console.Write(sym);
                Console.ForegroundColor = tmpColor;
            }
        }
        public void draw(char s, ConsoleColor color = ConsoleColor.White)
        {
            lock (Program.lockDraw)
            {
                ConsoleColor tmpColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x, y);
                Console.Write(s);
                Console.ForegroundColor = tmpColor;
            }
        }
        public void Draw(char s)
        {
            lock (Program.lockDraw)
            {
                ConsoleColor tmpColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x, y);
                Console.Write(s);
                Console.ForegroundColor = tmpColor;
            }
        }
        public void delete()
        {
            lock (Program.lockDraw)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
            }
        }
        //совпадение с другой точкой
        public bool hit(Point p)
        {
            return this == p;
        }
        //совпадение с какой-либо точкой из фигуры
        public bool hit(Figure f)
        {
            bool result = false;
            List<Point> pList = f.getList();
            foreach (Point p in pList) result |= hit(p);
            return result;
        }
        public static bool operator !=(Point p1, Point p2)
        {
            if (!(p1 is object) || !(p2 is object)) return true;
            return p1.x!=p2.x || p1.y!=p2.y;
        }
        public static bool operator ==(Point p1, Point p2)
        {
            return !(p1 != p2);
        }
        public static bool operator >(Point p1, Point p2)
        {
            return p1.x > p2.x;
        }
        public static bool operator <(Point p1, Point p2)
        {
            return p1.x < p2.x;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            Point m = obj as Point;
            if (m as Point == null)
                return false;

            return m == this && m.sym == this.sym;
        }
        public override int GetHashCode()
        {
            return x*100+y*10000+sym;
        }
    }
}
