﻿using System;

namespace Snake
{
    class PlayGround: Figure
    {
        public int width = 42;
        public int height = 22;
        public char sym = '+';
        public String score = "Score: ";
        public override void Draw()
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(width + 1, height + 1);
            Console.SetBufferSize(width + 1, height + 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;
            Console.Title = "Snake";
            Console.SetCursorPosition(0, height);
            Console.Write(score);
            Line leftLine = new Line(new Point(0, 0, sym), height-1, Direction.Down);
            PList.AddRange(leftLine.GetList());
            Line downLine = new Line(new Point(0, height-1, sym), width, Direction.Right);
            PList.AddRange(downLine.GetList());
            Line rightLine = new Line(new Point(width, height-1, sym), height-1, Direction.Up);
            PList.AddRange(rightLine.GetList());
            Line upLine = new Line(new Point(width, 0, sym), width, Direction.Left);
            PList.AddRange(upLine.GetList());
            base.Draw();
        }
        public void GameOver()
        {
            Program.gameOver = true;

            char c = '#';
            Console.SetCursorPosition(width / 3, height / 3);
            for (int i = 0; i < width / 3; ++i) Console.Write(c);

            Console.SetCursorPosition(width / 3, height / 3 + 1);
            Console.Write(c);
            for (int i = 0; i < width / 3 - 2; ++i) Console.Write(" ");
            Console.Write(c);

            Console.SetCursorPosition(width / 3, height / 3 + 2);
            Console.Write(c);
            for (int i = 0; i < width / 3 / 2 - 5 - 1; ++i) Console.Write(" ");
            Console.Write("GAME OVER!");
            for (int i = 0; i < width / 3 / 2 - 5 - 1; ++i) Console.Write(" ");
            Console.Write(c);

            Console.SetCursorPosition(width / 3, height / 3 + 3);
            Console.Write(c);
            for (int i = 0; i < width / 3 - 2; ++i) Console.Write(" ");
            Console.Write(c);

            Console.SetCursorPosition(width / 3, height / 3 + 4);
            for (int i = 0; i < width / 3; ++i) Console.Write(c);
        }
    }
}
