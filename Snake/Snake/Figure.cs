using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Figure
    {
        protected List<Point> pList;
        public virtual void Draw()
        {
            foreach(Point p in pList)
            {
                p.Draw();
            }
        }
        public List<Point> getList() { return pList; }
    }
}
