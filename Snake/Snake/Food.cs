using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Food: Figure
    {
        char sym;
        Snake snake;
        public Food(Snake snake,char sym)
        {
            this.sym = sym;
            this.snake = snake;
            Generate();
        }
        public void Generate()
        {
            if (pList.Count() == 0)
            {
                Random r = new Random();
                Point p = new Point(PlayGround.width/2, PlayGround.height/2, sym);
                while (p.Hit(snake)) 
                {
                    p = new Point(r.Next() % (PlayGround.width - 2) + 1, r.Next() % (PlayGround.height - 2) + 1, sym);
                }
                pList.Add(p);
                Draw();
            }
        }
        public void Eat()
        {
            pList.Clear();
            Generate();
        }
    }
}
