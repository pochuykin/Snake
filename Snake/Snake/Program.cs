using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
    class Program
    {
        public static PlayGround playground;
        public static Snake snake;
        public static Food food;
        public static bool gameOver = false;
        public static bool pause = false;
        public static DateTime timeLastMove = new DateTime();
        static void Main(string[] args)
        {
            while (true)
            {
                gameOver = false;
                playground = new PlayGround();
                playground.Draw();
                food = new Food();
                food.Draw();
                snake = new Snake(new Line(new Point(5, 5, '*'), 5, Direction.Right), Direction.Right);
                snake.Draw();
                Game();
                Console.ReadLine();
            }
        }
        private static void Step()
        {
            while (!gameOver)
            {
                while ((DateTime.Now - timeLastMove).Milliseconds < snake.speed){ }
                if (!pause) Program.snake.Step(null);
            }
        }
        private static void Game()
        {
            Thread t = new Thread(Step);
            t.Start();
            while (!gameOver)
            {
                CheckPressKey();
            }
        }
        private static void CheckPressKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Spacebar)
                {
                    pause = true;
                    key = Console.ReadKey(true);
                    pause = false;
                }
                Program.snake.HandleKey(key);
            }
        }
    }
}
