using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        public static PlayGround playground;
        public static Snake snake;
        public static Food food;
        public static Tunnel tunnel;
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
                snake = new Snake();
                snake.Draw();
                tunnel = new Tunnel();
                Game();
                Console.ReadLine();
            }
        }
        private static void Step()
        {
            while (!gameOver)
            {
                while ((DateTime.Now - timeLastMove).Milliseconds < snake.speed){ }
                if (!pause && (DateTime.Now - timeLastMove).Milliseconds >= snake.speed)
                    Program.snake.Step();
            }
        }
        private static void Game()
        {
            Thread thStep = new Thread(Step);
            thStep.Start();
            Thread thTunnel = new Thread(tunnel.Create);
            thTunnel.Start();
            while (!gameOver) CheckPressKey();
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
