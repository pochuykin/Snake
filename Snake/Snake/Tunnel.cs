using System.Collections.Generic;

namespace Snake
{
    class Tunnel : Figure
    {
        private int nextTunel;
        private const int speed = 1;
        public List<Direction> directions = new List<Direction>();
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
                        int tmpR1, tmpR2, tmpR3, tmpR4;
                        double cornerK = 0.7;
                        System.Random r = new System.Random();
                        tmpR1 = r.Next(1, Program.playground.width - 2);
                        //исключение случаев, когда тунели близко друг к другу в одном углу
                        if (tmpR1 > Program.playground.width * cornerK)
                        {
                            tmpR2 = r.Next(1 + (int)(Program.playground.height * (1 - cornerK)), Program.playground.height - 2);
                            tmpR4 = r.Next(1, Program.playground.height - 2);
                        }
                        else if (tmpR1 < Program.playground.width * (1 - cornerK))
                        {
                            tmpR2 = r.Next(1, Program.playground.height - 2);
                            tmpR4 = r.Next(1 + (int)(Program.playground.height * (1 - cornerK)), Program.playground.height - 2);
                        }
                        else
                        {
                            tmpR2 = r.Next(1, Program.playground.height - 2);
                            tmpR4 = r.Next(1, Program.playground.height - 2);
                        }
                        if (tmpR2 > Program.playground.height * cornerK && tmpR4 > Program.playground.height * cornerK)
                            tmpR3 = r.Next(1 + (int)(Program.playground.width * (1 - cornerK)), Program.playground.width - (int)(Program.playground.width * (1 - cornerK)) - 2);
                        else if (tmpR2 > Program.playground.height * cornerK)
                            tmpR3 = r.Next(1, Program.playground.width - (int)(Program.playground.width * (1 - cornerK)) - 2);
                        else if (tmpR4 > Program.playground.height * cornerK)
                            tmpR3 = r.Next(1 + (int)(Program.playground.width * (1 - cornerK)), Program.playground.width - 2);
                        else
                            tmpR3 = r.Next(1, Program.playground.width - 2);
                        
                        PList.Add(new Point(tmpR1, 0, Sym, Color)); directions.Add(Direction.Down);
                        PList.Add(new Point(tmpR3, Program.playground.height - 1, Sym, Color)); directions.Add(Direction.Up);
                        PList.Add(new Point(0, tmpR4, Sym, Color)); directions.Add(Direction.Right);
                        PList.Add(new Point(Program.playground.width, tmpR2, Sym, Color)); directions.Add(Direction.Left);
                        tmpR1 = r.Next(4) % 4;
                        PList.RemoveAt(tmpR1);
                        directions.RemoveAt(tmpR1);
                        tmpR2 = r.Next(3) % 3;
                        PList.RemoveAt(tmpR2);
                        directions.RemoveAt(tmpR2);
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
            directions.Clear();
            nextTunel = Program.snake.GetList().Count + speed;
        }

    }
}
