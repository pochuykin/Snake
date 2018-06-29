using System.Collections.Generic;

namespace Snake
{
    class Line: Figure
    {
        public Line(Point p, int size, Direction d)
        {
            PList = new List<Point>();
            for(int i = 0; i < size; ++i)
            {
                Point tmpP = new Point(p);
                tmpP.Move(i, d);
                PList.Add(tmpP);
            }
        }
    }
}
