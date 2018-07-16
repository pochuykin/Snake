using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    class Snake: Figure
    {
        private Direction direction = Direction.Right;
        public const int beginLength = 5;
        private const float speedBegin = 500;
        private const float speedEnd = 10;
        private float speed = speedBegin;
        private object lockStep = new object();
        private int isTunnel = 0;
        public float getScore() { return pList.Count - beginLength; }
        public float getSpeed() { return speed; }
        public Snake()
        {
            sym = 'O';
            color = System.ConsoleColor.Gray;
            pList.AddRange(new Line(new Point(5, 5, sym, color), beginLength, direction, sym).getList());
        }
        private void setDirection(Direction d)
        {
            direction = d;
            //и сразу ходим, в случае, когда игрок хочет быстрого передвижения змейки
            if (!Program.gameOver) step();
        }
        public void HandleKey(System.ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                //если нажали стрелку вправо, и при этом змейка не движется влево, устанавливаем новое направление
                case System.ConsoleKey.RightArrow: if (direction != Direction.Left) { setDirection(Direction.Right); } break;
                case System.ConsoleKey.LeftArrow: if (direction != Direction.Right) { setDirection(Direction.Left); } break;
                case System.ConsoleKey.UpArrow: if (direction != Direction.Down) { setDirection(Direction.Up); } break;
                case System.ConsoleKey.DownArrow: if (direction != Direction.Up) { setDirection(Direction.Down); } break;
            }
        }
        private Point getNextPoint()
        {
            //определяем голову змейки
            Point head = new Point(pList.Last(), sym);
            //если змейка не в тунелле
            if (isTunnel!=1)
                head.move(1, direction);
            //если змейка в туннеле
            else
            {
                Point tunnelPart1 = Program.tunnel.getList()[0];
                Point tunnelPart2 = Program.tunnel.getList()[1];
                //определяем в какую часть туннеля вошла змейка
                if (head.hit(tunnelPart1))
                    //выводим голову из другой части туннеля
                    head = new Point(tunnelPart2, sym, color);
                else
                    head = new Point(tunnelPart1, sym, color);
                //и ставим соответствующее направление
                direction = (head.getY() == 0 ? Direction.Down :
                             head.getX() == 0 ? Direction.Right :
                             head.getY() == Program.playground.getHeight() - 1 ? Direction.Up : 
                             head.getX() == Program.playground.getWidth() ?      Direction.Left : direction);
                //сразу выходим из туннеля, иначе если не выйти и нажать на стрелку в сторону PlayGround, будет конец игры
                head.move(1, direction);
                ++isTunnel;
            }
            return head;
        }
        //метод, описывающий движение змейки
        public void Move()
        {
            Point tail = pList.First();
            //определяем где будет голова змейки
            Point head = getNextPoint();
            pList.Add(head);

            //если еда не встретилась
            if (!hit(Program.food))
            {
                //удаляем хвост
                pList.Remove(tail);
                tail.delete();
            }
            else eat();
            //рисуем голову, если не туннель
            if (!hit(Program.tunnel))
                head.draw();

            //обновляем дату последнего хода
            Program.timeLastMove = System.DateTime.Now;
        }
        private void CheckTunnel()
        {
            Point head = Program.snake.getList().Last();
            //если есть туннель
            if (Program.tunnel.getList().Count!=0)
            {
                Point tun1 = Program.tunnel.getList().First();
                Point tun2 = Program.tunnel.getList().Last();
                //если в туннеле еще не было
                if (isTunnel == 0 && (head.hit(tun1) || head.hit(tun2)))
                {
                    ++isTunnel;
                }
                //если вышли из туннеля
                else if (isTunnel == 2 && !base.hit(Program.tunnel))
                {
                    isTunnel = 0;
                    Program.tunnel.delete();
                }
            }
        }
        public void step()
        {
            //блокировка нужна, т.к. ход змейки может выполняться одновременно из Program.thStep и из setDirection 
            lock (lockStep)
            {
                Program.snake.Move();
                CheckTunnel();
                if (Program.snake.hit(Program.playground) || Program.snake.hit(Program.snake))
                    Program.gameOver = true;
            }
        }
        //рисуем место столкновение
        private void clash()
        {
            char sym = '@';
            Point p = new Point(pList.Last(), sym, System.ConsoleColor.Red);
            p.draw();
        }
        protected override bool hit(Figure f)
        {
            bool result = false;
            //список точек для будущего сравнения
            List<Point> list = f.getList().ToList();
            //если фигура - змейка, рассматриваем всю змейку кроме головы
            if (f is Snake)
                list.Remove(list.Last());
            //если есть туннели, удаляем туннели из списка точек игрового поля
            if (f is PlayGround && Program.tunnel.getList().Count != 0)
            {
                List<Point> l = new List<Point>();
                foreach (Point pTunel in Program.tunnel.getList())
                    foreach (Point p in list)
                        if (p == pTunel)
                            l.Add(p);
                foreach (Point p in l)
                    list.Remove(p);
            }
            foreach (Point p in list)
                result |= hit(p);
            //если есть совпадение и это не еда и не туннель
            if (result && !(f is Food) && !(f is Tunnel))
                //то это столкновение
                clash();
            return result;
        }
        public bool hit(Point p)
        {
            //для змейки, точка сравнивается только с головой змейки
            return p.hit(pList.Last());
        }
        public void eat()
        {
            Program.food.Eat();
            speed -= (speedBegin - speedEnd) / (Program.playground.getHeight() * Program.playground.getWidth());
            Program.playground.printScore();
        }
    }
}
