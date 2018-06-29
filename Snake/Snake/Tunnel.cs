using System;
using System.Linq;

namespace Snake
{
    class Tunnel : Figure
    {
        private int nextTunel;
        private const int speed = 5;
        private const System.ConsoleColor c = System.ConsoleColor.Red;
        public char sym = '0';
        public void Create()
        {
            nextTunel = Program.snake.GetList().Count + speed;
            while (!Program.gameOver)
            {
                if (Program.snake.GetList().Count == nextTunel)
                {
                    if (!PList.Any())
                    {
                        Random r = new Random();
                        Point partTunnel1, partTunnel2;
                        switch (r.Next(0, 32) % 2)
                        {
                            case (0):
                                partTunnel1 = new Point(r.Next(1, Program.playground.width - 2), 0, sym);
                                partTunnel2 = new Point(r.Next(1, Program.playground.width - 2), Program.playground.height - 1, sym);
                                PList.Add(partTunnel1);
                                PList.Add(partTunnel2);
                                break;
                            case (1):
                                partTunnel1 = new Point(0, r.Next(1, Program.playground.height - 2), sym);
                                partTunnel2 = new Point(Program.playground.width, r.Next(1, Program.playground.height - 2), sym);
                                PList.Add(partTunnel1);
                                PList.Add(partTunnel2);
                                break;
                        }
                        Draw(c);
                    }
                }
            }
        }
        public override void Delete()
        {
            foreach (Point p in PList)
                p.Draw(Program.playground.sym);
            PList.Clear();
            nextTunel = Program.snake.GetList().Count + speed;
        }

    }
}
