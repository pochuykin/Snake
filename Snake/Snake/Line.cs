using System.Collections.Generic;

namespace Snake
{
    class Line: Figure
    {
        public Line(Point point, int size, Direction direction, char sym)
        {
            Sym = sym;
            PList = new List<Point>();
            for(int i = 0; i < size; ++i)
            {
                Point tmpPoint = new Point(point, Sym);
                tmpPoint.Move(i, direction);
                PList.Add(tmpPoint);
            }
        }
    }
}
