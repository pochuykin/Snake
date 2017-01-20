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
            snake.SetFood(this);
        }
        public override void Draw()
        {
            if (pList.Count() == 0)
            {
                Random r = new Random();
                Point p = new Point(PlayGround.width/2, PlayGround.height/2, sym);
                while (p.Hit(snake)) 
                {
                    p = new Point(r.Next(1,PlayGround.width - 1), r.Next(1,PlayGround.height - 1) + 1, sym);
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
