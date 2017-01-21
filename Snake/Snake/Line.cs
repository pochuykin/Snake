﻿using System;
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
                Point tmpP = new Point(p);
                tmpP.Move(i, d);
                pList.Add(tmpP);
            }
        }
    }
}
