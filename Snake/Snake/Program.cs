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
            PlayGround playground;
            Snake snake;
            Food food;
            while (true)
            {
                playground = new PlayGround('+');
                snake = new Snake(new Line(new Point(5, 5, '*'), 5, Direction.Right), Direction.Right);
                food = new Food(snake, '$');
                playground.Draw();
                food.Draw();
                snake.Draw();
                while (true)
                {
                    snake.PrintPoints();
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Spacebar)
                        {
                            key = Console.ReadKey(true);
                        }
                        else snake.HandleKey(key);
                    }
                    Thread.Sleep(200 - snake.getList().Count() * (150 / (PlayGround.width * PlayGround.height)));
                    snake.Move();
                    if (snake.Hit(playground) || snake.Hit(snake))
                    {
                        playground.GameOver();
                        break;
                    }
                    else if (snake.Hit(food)) food.Eat();
                }
                Console.ReadLine();
            }
        }
    }
}
