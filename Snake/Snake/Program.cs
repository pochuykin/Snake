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
            PlayGround playground = new PlayGround('#');
            Snake snake = new Snake(new Line(new Point(5,5,'*'), 5 ,Direction.Right), Direction.Right);
            Food food = new Food(snake,'@');
            snake.SetFood(food);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    snake.HandleKey(Console.ReadKey());
                }
                Thread.Sleep(200);
                snake.Move();
                if (snake.Hit(playground) || snake.Hit(snake)) break;
                else if (snake.Hit(food)) food.Eat();
            }
            Console.ReadLine();
        }
    }
}
