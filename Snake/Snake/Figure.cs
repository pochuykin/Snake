using System.Collections.Generic;

namespace Snake
{
    abstract class Figure
    {
        protected List<Point> PList;
        protected Figure()
        {
            PList = new List<Point>();
        }
        public List<Point> GetList()
        {
            return PList;
        }
        public virtual void Draw()
        {
            foreach (Point p in PList)
                p.Draw();
        }
        public virtual void Delete()
        {
            foreach (Point p in PList)
                p.Delete();
        }
        protected virtual bool Hit(Figure f)
        {
            bool result = false;
            foreach (Point p in PList)
                    result |= p.Hit(f);
            return result;
        }
    }
}
