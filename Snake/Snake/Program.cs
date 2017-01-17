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
            PlayGround playground = new PlayGround();
            playground.Draw();
            Snake snake = new Snake(new Line(new Point(5,5,'*'), 5 ,Direction.Right), Direction.Right);
            while(true)
            {
                if (Console.KeyAvailable)
                {
                    snake.HandleKey(Console.ReadKey());
                }
                Thread.Sleep(200);
                snake.Move();
                if (snake.Hit(playground) || snake.Hit(snake)) { break; }
            }
            Console.ReadLine();
        }
    }
}
