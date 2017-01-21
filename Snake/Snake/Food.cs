using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Food: Figure
    {
        private char sym = '$';
        public override void Draw()
        {
            if (!pList.Any())
            {
                Random r = new Random();
                Point p = new Point(Program.playground.width/2, Program.playground.height /2, sym);
                while (Program.snake != null && p.Hit(Program.snake)) 
                {
                    p = new Point(r.Next(1, Program.playground.width - 1), r.Next(1, Program.playground.height - 1), sym);
                }
                pList.Add(p);
                base.Draw();
            }
        }
        public void Eat()
        {
            pList.Clear();
            Draw();
        }
    }
}
