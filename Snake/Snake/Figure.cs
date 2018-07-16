using System.Collections.Generic;

namespace Snake
{
    abstract class Figure
    {
        protected List<Point> pList;
        protected char sym;
        public System.ConsoleColor color;
        protected Figure()
        {
            pList = new List<Point>();
        }
        public List<Point> getList()
        {
            return pList;
        }
        public virtual void draw()
        {
            foreach (Point p in pList)
                p.draw();
        }
        public virtual void delete()
        {
            foreach (Point p in pList)
                p.delete();
        }
        protected virtual bool hit(Figure f)
        {
            bool result = false;
            foreach (Point p in pList)
                    result |= p.hit(f);
            return result;
        }
    }
}
