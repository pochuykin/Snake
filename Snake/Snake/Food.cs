using System;
using System.Linq;

namespace Snake
{
    class Food: Figure
    {
        private char sym = '$';
        private System.ConsoleColor Color = System.ConsoleColor.Blue;
        public override void Draw()
        {
            if (!PList.Any())
            {
                Random r = new Random();
                Point p = new Point(Program.playground.width/2, Program.playground.height /2, sym);
                while (Program.snake != null && p.Hit(Program.snake)) 
                {
                    p = new Point(r.Next(1, Program.playground.width - 1), r.Next(1, Program.playground.height - 1), sym);
                }
                PList.Add(p);
                base.Draw(Color);
            }
        }
        public void Eat()
        {
            PList.Clear();
            Draw();
        }
    }
}
