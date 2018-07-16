using System;

namespace Snake
{
    class PlayGround: Figure
    {
        private int width = 42;
        private int height = 22;
        private string titleScore = "Score: ";
        public int getWidth() { return width; }
        public int getHeight() { return height; }
        public string getTitleScore() { return titleScore; }
        public PlayGround()
        {
            sym = '+';
            color = ConsoleColor.White;
        }
        public override void draw()
        {
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(width + 1, height + 1);
            Console.SetBufferSize(width + 1, height + 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;
            Console.Title = "Snake";
            lock (Program.lockDraw)
            {
                Console.SetCursorPosition(0, height);
                Console.Write(titleScore + "0");
            }
            Line leftLine = new Line(new Point(0, 0, sym, color), height - 1, Direction.Down, sym);
            pList.AddRange(leftLine.getList());
            Line downLine = new Line(new Point(0, height - 1, sym, color), width, Direction.Right, sym);
            pList.AddRange(downLine.getList());
            Line rightLine = new Line(new Point(width, height - 1, sym, color), height - 1, Direction.Up, sym);
            pList.AddRange(rightLine.getList());
            Line upLine = new Line(new Point(width, 0, sym, color), width, Direction.Left, sym);
            pList.AddRange(upLine.getList());
            base.draw();
        }
        public void printScore()
        {
            lock (Program.lockDraw)
            {
                Console.SetCursorPosition(getTitleScore().Length, getHeight());
                Console.Write(Program.snake.getScore() * 10);
            }
        }
        public void gameOver()
        {
            lock (Program.lockDraw)
            {
                char c = '#';
                Console.SetCursorPosition(width / 3, height / 3);
                for (int i = 0; i <= width / 3 + 2; ++i) Console.Write(c);

                Console.SetCursorPosition(width / 3, height / 3 + 1);
                Console.Write(c);
                for (int i = 0; i <= width / 3; ++i) Console.Write(" ");
                Console.Write(c);

                Console.SetCursorPosition(width / 3, height / 3 + 2);
                Console.Write(c);
                for (int i = 0; i <= width / 3 / 2 - 5; ++i) Console.Write(" ");
                Console.Write("GAME OVER");
                for (int i = 0; i <= width / 3 / 2 - 5; ++i) Console.Write(" ");
                Console.Write(c);

                Console.SetCursorPosition(width / 3, height / 3 + 3);
                Console.Write(c);
                for (int i = 0; i <= width / 3; ++i) Console.Write(" ");
                Console.Write(c);

                Console.SetCursorPosition(width / 3, height / 3 + 4);
                for (int i = 0; i <= width / 3 + 2; ++i) Console.Write(c);
            }
        }
    }
}
