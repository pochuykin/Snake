using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class PlayGround: Figure
    {
        public static int width = 60;
        public static int height = 25;
        public void Draw()
        {
            char s = '%';
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(width + 1, height + 1);
            Console.SetBufferSize(width + 1, height + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            pList = new List<Point>();
            Line leftLine = new Line(new Point(0, 0, s), height, Direction.Down);
            pList.AddRange(leftLine.getList()); leftLine.Draw();
            Line downLine = new Line(new Point(0, height, s), width, Direction.Right);
            pList.AddRange(downLine.getList()); downLine.Draw();
            Line rightLine = new Line(new Point(width, height, s), height, Direction.Up);
            pList.AddRange(rightLine.getList()); rightLine.Draw();
            Line upLine = new Line(new Point(width, 0, s), width, Direction.Left);
            pList.AddRange(upLine.getList()); upLine.Draw();
        }
    }
}
