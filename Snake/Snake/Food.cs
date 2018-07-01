using System;
using System.Linq;

namespace Snake
{
    class Food : Figure
    {
        public Food()
        {
            Sym = '$';
            Color = ConsoleColor.Blue;
        }
        public override void Draw()
        {
            if (!PList.Any())
            {
                Random r = new Random();
                Point p = new Point(Program.playground.width/2, Program.playground.height /2, Sym, Color);
                while (Program.snake != null && p.Hit(Program.snake)) 
                {
                    p = new Point(r.Next(1, Program.playground.width - 1), r.Next(1, Program.playground.height - 1), Sym, Color);
                }
                PList.Add(p);
                base.Draw();
            }
        }
        public void Eat()
        {
            PList.Clear();
            Draw();
        }
    }
}
