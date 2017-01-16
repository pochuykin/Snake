using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Line: Figure
    {
        public Line(Point p, int size, Direction d)
        {
            pList = new List<Point>();
            for(int i = 0; i < size; ++i)
            {
                Point tmp_p = new Point(p);
                tmp_p.Move(i, d);
                pList.Add(tmp_p);
            }
        }
    }
}
