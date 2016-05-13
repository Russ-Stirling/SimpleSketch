using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleSketch
{
    class Polygon
    {
        List<Point> points;
        Point start;
        Color colour;
        public Polygon(Point _points, Color c)
        {
            colour = c;
            start = _points;
            points = new List<Point>();
            points.Add(_points);
        }
        public Polygon(Polygon f)
        {
            colour = f.getColor();
            start = f.getStart();
            points = new List<Point>(f.getPo());
        }
        public void addPoint(Point _points)
        {
            points.Add(_points);
        }
        public Point[] getP()
        {
            Point[] p = new Point[points.Count];
            int i = 0;
            foreach (var x in points)
            {
                p[i] = x;
                i++;
            }
            return p;
        }
        public List<Point> getPo()
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
            int x1, x2, y1, y2;
            x1 = getStart().X;
            y1 = getStart().Y;
            foreach (Point p in points)
            {
                x2 = p.X;
                y2 = p.Y;
                if (_x >= x1 && _x <= x2)
                {
                    if (_y >= y1 && _y <= y2) { return true; }
                    else if (_y <= y1 && _y >= y2) { return true; }
                }
                else if (_x <= x1 && _x >= x2)
                {
                    if (_y <= y1 && _y >= y2) { return true; }
                    else if (_y >= y1 && _y <= y2) { return true; }
                }
                x1 = x2;
                y1 = y2;
            }
            return false;
        }
        public void setPos(int _x, int _y)
        {
            start.X -= _x;
            start.Y -= _y;
            Point p;
            int j = points.Count;
            for (int i = 0; i < j; i++)
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
