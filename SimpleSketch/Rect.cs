using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleSketch
{
    class Rect
    {
        private int x1, y1, width, height;
        private Color colour;
        public Rect(int _x1, int _y1, int _x2, int _y2, Color _colour)
        {
            if (_x1 > _x2)
            {
                x1 = _x2;
                width = _x1 - _x2;
            }
            else
            {
                x1 = _x1;
                width = _x2 - _x1;
            }
            if (_y1 > _y2)
            {
                y1 = _y2;
                height = _y1 - _y2;
            }
            else
            {
                y1 = _y1;
                height = _y2 - _y1;
            }
            colour = _colour;
        }
        public Rect(Rect r)
        {
            colour = r.getColor();
            x1 = r.getX1();
            y1 = r.getY1();
            width = r.getW();
            height = r.getH();
        }
        public int getX1() { return x1; }
        public int getW() { return width; }
        public int getY1() { return y1; }
        public int getH() { return height; }
        public Color getColor() { return colour; }
        public bool positionCheck(int _x, int _y)
        {
            if ((_x >= x1) && (_y >= y1))
            {
                if (((_x - x1) <= width) && ((_y - y1) <= height)) { return true; }
            }

            return false;
        }
        public void setPos(int _x, int _y)
        {
            x1 -=_x;
            y1 -=_y;
        }
    }
}
