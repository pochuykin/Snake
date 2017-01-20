using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class PlayGround: Figure
    {
        public static int width = 42;
        public static int height = 22;
        private char sym;
        public PlayGround(char s)
        {
            sym = s;
        }
        public override void Draw()
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(width + 1, height + 1);
            Console.SetBufferSize(width + 1, height + 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;
            Console.Title = "Snake";
            Line leftLine = new Line(new Point(0, 0, sym), height-1, Direction.Down);
            pList.AddRange(leftLine.getList());
            Line downLine = new Line(new Point(0, height-1, sym), width, Direction.Right);
            pList.AddRange(downLine.getList());
            Line rightLine = new Line(new Point(width, height-1, sym), height-1, Direction.Up);
            pList.AddRange(rightLine.getList());
            Line upLine = new Line(new Point(width, 0, sym), width, Direction.Left);
            pList.AddRange(upLine.getList());
            base.Draw();
        }
        public void GameOver()
        {
            Console.SetCursorPosition(width / 3, height / 3);
            for (int i = 0; i < width / 3; ++i) Console.Write("#");

            Console.SetCursorPosition(width / 3, height / 3 + 1);
            Console.Write("#");
            for (int i = 0; i < width / 3 - 2; ++i) Console.Write(" ");
            Console.Write("#");

            Console.SetCursorPosition(width / 3, height / 3 + 2);
            Console.Write("#");
            for (int i = 0; i < width / 3 / 2 - 5 - 1; ++i) Console.Write(" ");
            Console.Write("GAME OVER!");
            for (int i = 0; i < width / 3 / 2 - 5 - 1; ++i) Console.Write(" ");
            Console.Write("#");

            Console.SetCursorPosition(width / 3, height / 3 + 3);
            Console.Write("#");
            for (int i = 0; i < width / 3 - 2; ++i) Console.Write(" ");
            Console.Write("#");

            Console.SetCursorPosition(width / 3, height / 3 + 4);
            for (int i = 0; i < width / 3; ++i) Console.Write("#");
        }
    }
}
