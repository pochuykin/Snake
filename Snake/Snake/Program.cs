using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            new PlayGround().Draw();
            Snake snake = new Snake(new Line(new Point(5,5,'*'), 5 ,Direction.Right), Direction.Right);
            while(true)
            {
                if (Console.KeyAvailable)
                {
                    snake.HandleKey(Console.ReadKey());
                    Thread.Sleep(100);
                    snake.Move();
                }
                else
                {
                    Thread.Sleep(100);
                    snake.Move();
                }
            }
            Console.ReadLine();
        }
    }
}
