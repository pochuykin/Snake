using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Figure
    {
        protected List<Point> pList;
        protected Figure()
        {
            pList = new List<Point>();
        }
        public virtual void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
        public void Delete()
        {
            foreach (Point p in pList)
            {
                p.Delete();
            }
        }
        public List<Point> getList() { return pList; }
    }
}
