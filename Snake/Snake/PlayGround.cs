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
        public static char sym = '%';
        public override void Draw()
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(width + 1, height + 1);
            Console.SetBufferSize(width + 1, height + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            pList = new List<Point>();
            Line leftLine = new Line(new Point(0, 0, sym), height, Direction.Down);
            pList.AddRange(leftLine.getList());
            Line downLine = new Line(new Point(0, height, sym), width, Direction.Right);
            pList.AddRange(downLine.getList());
            Line rightLine = new Line(new Point(width, height, sym), height, Direction.Up);
            pList.AddRange(rightLine.getList());
            Line upLine = new Line(new Point(width, 0, sym), width, Direction.Left);
            pList.AddRange(upLine.getList());
            base.Draw();
        }
    }
}
