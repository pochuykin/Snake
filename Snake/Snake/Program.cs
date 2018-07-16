using System;
using System.Collections.Generic;
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
        public static object lockDraw = new object();
        public static DateTime timeLastMove = new DateTime();
        private List<Thread> lThreads;
        private const int sleep = 1;
        public Program()
        {
            while (true)
            {
                gameOver = false;
                playground = new PlayGround();
                playground.draw();
                snake = new Snake();
                snake.draw();
                food = new Food();
                food.draw();
                tunnel = new Tunnel();
                startGame();
            }
        }
        private void step()
        {
            while (true)
            {
                while ((DateTime.Now - timeLastMove).Milliseconds < snake.getSpeed()) { Thread.Sleep(sleep); }
                if (!gameOver && (DateTime.Now - timeLastMove).Milliseconds >= snake.getSpeed())
                    snake.step();
            }
        }
        private void checkPressKey()
        {
            while (true)
            {
                Thread.Sleep(sleep);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    //обработка нажатия на пробел - пауза
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        pause = true;
                        //ставим на паузу потоки
                        foreach (Thread th in lThreads) if (th.Name != "ReadPressKeyThread") th.Suspend();
                        key = Console.ReadKey(true);
                        //чтобы после паузы не было два шага, нужно обновить время последнего хода
                        Program.timeLastMove = System.DateTime.Now;
                        //возобновляем потоки
                        foreach (Thread th in lThreads) if (th.Name != "ReadPressKeyThread") th.Resume();
                        pause = false;
                    }
                    //передаем нажатую клавишу
                    snake.HandleKey(key);
                }
            }
        }
        private void checkGameOver()
        {
            while (!gameOver) { Thread.Sleep(sleep); }
            //завершаем все потоки
            foreach (Thread th in lThreads)
                th.Abort();
            lThreads.Clear();
            playground.gameOver();
            Console.ReadLine();
        }
        private void startGame()
        {
            //создаем потоки, отвечающие за ШагЗмейки,СоданиеТуннелей,НажатиеКлавиш
            Thread thStep = new Thread(step);
            thStep.Name = "StepThread";
            thStep.Priority = ThreadPriority.AboveNormal;
            Thread thTunnel = new Thread(tunnel.create);
            thTunnel.Name = "TunnelThread";
            thTunnel.Priority = ThreadPriority.Lowest;
            Thread thReadPressKey = new Thread(checkPressKey);
            thReadPressKey.Name = "ReadPressKeyThread";
            thReadPressKey.Priority = ThreadPriority.Highest;
            lThreads = new List<Thread>() { thStep, thTunnel, thReadPressKey };
            //поток, обрабатывающий конец игры
            Thread thCheckGameOver = new Thread(checkGameOver);
            thCheckGameOver.Name = "CheckGameOverThread";
            thCheckGameOver.Priority = ThreadPriority.AboveNormal;
            thCheckGameOver.Start();
            //запускаем потоки
            foreach (Thread th in lThreads)
                th.Start();
            //ожидаем завершения потока проверки конца игры
            thCheckGameOver.Join();
        }
        static void Main(string[] args)
        {
            new Program();
        }


    }
}
