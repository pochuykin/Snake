using System.Collections.Generic;

namespace Snake
{
    class Line: Figure
    {
        //линия - из точки выстраивается несколько точек рядом в направлении direction размера size
        public Line(Point point, int size, Direction direction, char sym)
        {
            base.sym = sym;
            pList = new List<Point>();
            for(int i = 0; i < size; ++i)
            {
                Point tmpPoint = new Point(point, base.sym);
                tmpPoint.move(i, direction);
                pList.Add(tmpPoint);
            }
        }
    }
}
