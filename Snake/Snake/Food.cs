using System;
using System.Linq;

namespace Snake
{
    class Food : Figure
    {
        public Food()
        {
            sym = '$';
            color = ConsoleColor.Green;
        }
        public override void draw()
        {
            //если еды еще нет
            if (!pList.Any())
            {
                Random r = new Random();
                Point p = new Point(r.Next(1, Program.playground.getWidth() - 1), r.Next(1, Program.playground.getHeight() - 1), sym, color);
                //если появившаяся еда попала на змейку
                while (p.hit(Program.snake)) 
                {
                    p = new Point(r.Next(1, Program.playground.getWidth() - 1), r.Next(1, Program.playground.getHeight() - 1), sym, color);
                }
                pList.Add(p);
                base.draw();
            }
        }
        public void Eat()
        {
            pList.Clear();
            draw();
        }
    }
}
