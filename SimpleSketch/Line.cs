using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleSketch
{
    class Line
    {
        private int x1, y1, x2, y2;
        private Color colour;
        public Line(int _x1, int _y1, int _x2, int _y2, Color _colour)
        {
            x1 = _x1;
            y1 = _y1;
            x2 = _x2;
            y2 = _y2;
            colour = _colour;
        }
        public Line(Line l)
        {
            x1 = l.getX1();
            y1 = l.getY1();
            x2 = l.getX2();
            y2 = l.getY2();
            colour = l.getColor();
        }
        public int getX1() { return x1; }
        public int getX2() { return x2; }
        public int getY1() { return y1; }
        public int getY2() { return y2; }
        public Color getColor() { return colour; }
        public bool positionCheck(int _x, int _y)
        {
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
            return false;
        }
        public void setPos(int _x, int _y)
        {
            x1 -= _x;
            y1 -= _y;
            x2 -= _x;
            y2 -= _y;
        }
    }
}
