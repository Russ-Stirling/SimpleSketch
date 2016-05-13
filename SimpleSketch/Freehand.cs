using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleSketch
{
    class Freehand
    {
        List<Point> points;
        Point start;
        Color colour;
        public Freehand(Point _points, Color c)
        {
            colour = c;
            start = _points;
            points = new List<Point>();
            points.Add(_points);
        }
        public Freehand(Freehand f)
        {
            colour = f.getColor();
            start = f.getStart();
            points = new List<Point>(f.getP());
        }
        public void addPoint(Point _points)
        {
            points.Add(_points);
        }
        public List<Point> getP()
        {
            return points;
        }
        public Point getStart()
        {
            return start;
        }
        public Color getColor()
        {
            return colour;
        }
        public bool positionCheck(int _x, int _y)
        {
            foreach (Point p in points)
            {
                if ((_x >= (p.X - 15)) && (_x <= p.X + 15))
                {
                    if ((_y >= (p.Y - 15)) && (_y <= p.Y + 15)) { return true; }
                }
            }
            return false;
        }
        public void setPos(int _x, int _y)
        {
            start.X -= _x;
            start.Y -= _y;
            Point p;
            int j = points.Count;
            for(int i=0; i<j; i++)
            {
                p = points[0];
                p.X -= _x;
                p.Y -= _y;
                points.RemoveAt(0);
                points.Add(p);
                
            }
        }
    }
}
