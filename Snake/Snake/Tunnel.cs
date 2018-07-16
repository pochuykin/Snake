using System.Collections.Generic;

namespace Snake
{
    class Tunnel : Figure
    {
        private int nextTunel;
        //скорость появления тунеля в количестве съеденной еды
        private const int speed = 3;
        public void create()
        {
            sym = '0';
            color = System.ConsoleColor.Magenta;
            nextTunel = Program.snake.getList().Count + speed;
            while (true)
            {
                System.Threading.Thread.Sleep(1);
                if (Program.snake.getList().Count > nextTunel)
                {
                    if (pList.Count == 0)
                    {
                        int tmpR1, tmpR2, tmpR3, tmpR4;
                        double cornerK = 0.85;
                        System.Random r = new System.Random();
                        tmpR1 = r.Next(1, Program.playground.getWidth() - 2);
                        //исключение случаев, когда тунели близко друг к другу в одном углу
                        if (tmpR1 > Program.playground.getWidth() * cornerK)
                        {
                            tmpR2 = r.Next(1 + (int)(Program.playground.getHeight() * (1 - cornerK)), Program.playground.getHeight() - 2);
                            tmpR4 = r.Next(1, Program.playground.getHeight() - 2);
                        }
                        else if (tmpR1 < Program.playground.getWidth() * (1 - cornerK))
                        {
                            tmpR2 = r.Next(1, Program.playground.getHeight() - 2);
                            tmpR4 = r.Next(1 + (int)(Program.playground.getHeight() * (1 - cornerK)), Program.playground.getHeight() - 2);
                        }
                        else
                        {
                            tmpR2 = r.Next(1, Program.playground.getHeight() - 2);
                            tmpR4 = r.Next(1, Program.playground.getHeight() - 2);
                        }
                        if (tmpR2 > Program.playground.getHeight() * cornerK && tmpR4 > Program.playground.getHeight() * cornerK)
                            tmpR3 = r.Next(1 + (int)(Program.playground.getWidth() * (1 - cornerK)), Program.playground.getWidth() - (int)(Program.playground.getWidth() * (1 - cornerK)) - 2);
                        else if (tmpR2 > Program.playground.getHeight() * cornerK)
                            tmpR3 = r.Next(1, Program.playground.getWidth() - (int)(Program.playground.getWidth() * (1 - cornerK)) - 2);
                        else if (tmpR4 > Program.playground.getHeight() * cornerK)
                            tmpR3 = r.Next(1 + (int)(Program.playground.getWidth() * (1 - cornerK)), Program.playground.getWidth() - 2);
                        else
                            tmpR3 = r.Next(1, Program.playground.getWidth() - 2);
                        
                        pList.Add(new Point(tmpR1, 0, sym, color)); 
                        pList.Add(new Point(tmpR3, Program.playground.getHeight() - 1, sym, color));
                        pList.Add(new Point(0, tmpR4, sym, color)); 
                        pList.Add(new Point(Program.playground.getWidth(), tmpR2, sym, color));
                        tmpR1 = r.Next(4) % 4;
                        pList.RemoveAt(tmpR1);
                        tmpR2 = r.Next(3) % 3;
                        pList.RemoveAt(tmpR2);
                        draw();
                    }
                }
            }
        }
        public override void delete()
        {
            foreach (Point pPlayground in Program.playground.getList())
                foreach (Point pTunnel in pList)
                    if (pTunnel == pPlayground)
                        pPlayground.draw();
            pList.Clear();
            nextTunel = Program.snake.getList().Count + speed;
        }

    }
}
