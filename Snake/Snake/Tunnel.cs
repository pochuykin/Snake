using System;
using System.Linq;

namespace Snake
{
    class Tunnel : Figure
    {
        private int nextTunel;
        private const int speed = 1;
        public void Create()
        {
            Sym = '0';
            Color = System.ConsoleColor.Red;
            nextTunel = Program.snake.GetList().Count + speed;
            while (!Program.gameOver)
            {
                if (Program.snake.GetList().Count == nextTunel)
                {
                    if (PList.Count == 0)
                    {
                        Random r = new Random();
                        Point partTunnel1, partTunnel2;
                        switch (r.Next(0, 32) % 2)
                        {
                            case (0):
                                partTunnel1 = new Point(r.Next(1, Program.playground.width - 2), 0, Sym, Color);
                                partTunnel2 = new Point(r.Next(1, Program.playground.width - 2), Program.playground.height - 1, Sym, Color);
                                PList.Add(partTunnel1);
                                PList.Add(partTunnel2);
                                break;
                            case (1):
                                partTunnel1 = new Point(0, r.Next(1, Program.playground.height - 2), Sym, Color);
                                partTunnel2 = new Point(Program.playground.width, r.Next(1, Program.playground.height - 2), Sym, Color);
                                PList.Add(partTunnel1);
                                PList.Add(partTunnel2);
                                break;
                        }
                        Draw();
                    }
                }
            }
        }
        public override void Delete()
        {
            foreach (Point pPlayground in Program.playground.GetList())
                foreach (Point pTunnel in PList)
                    if (pTunnel == pPlayground)
                        pPlayground.Draw();
            PList.Clear();
            nextTunel = Program.snake.GetList().Count + speed;
        }

    }
}
