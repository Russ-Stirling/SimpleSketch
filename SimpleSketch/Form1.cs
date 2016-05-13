using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows;

namespace SimpleSketch
{
    public partial class Form1 : Form
    {
        Pen myPen = new Pen(Color.Black, 5);
        List<Line> lines = new List<Line>();
        List<Rect> rects = new List<Rect>();
        List<Freehand> free = new List<Freehand>();
        List<Circle> circles = new List<Circle>();
        List<Polygon> polys = new List<Polygon>();
        List<FreePolygon> fpolys = new List<FreePolygon>();
        String chosen = null;
        Object choice;
        int fpi=0;
        int fi = 0;
        int pi = 0;
        bool checkP = true;
        bool justDouble = false;
        SolidBrush myBrush;
        Boolean down = false;
        Color colour = Color.Black;
        String mode = "Freehand";
        int prevX = 0;
        int prevY = 0;
        int x = 0;
        int y = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void blackBut_Click(object sender, EventArgs e)
        {
            colour = Color.Black;
        }

        private void redBut_Click(object sender, EventArgs e)
        {
            colour = Color.OrangeRed;
        }

        private void yellowBut_Click(object sender, EventArgs e)
        {
            colour = Color.Yellow;
        }

        private void blueBut_Click(object sender, EventArgs e)
        {
            colour = Color.DeepSkyBlue;
        }

        private void greenBut_Click(object sender, EventArgs e)
        {
            colour = Color.ForestGreen;
        }

        private void shapeSelection_SelectedValueChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(shapeSelection.Text);
            mode = shapeSelection.Text;
            if (mode == "Line")
            {
                toolTip.Text="Click, drag, and release to create a straight line.";
            }
            else if (mode == "Rectangle")
            {
                toolTip.Text = "Click, drag, and release to create a rectangle. Hold shift for a square";
            }
            else if (mode == "Freehand")
            {
                toolTip.Text = "Click and drag to draw a line that will follow your cursor.";
            }
            else if (mode == "Ellipse")
            {
                toolTip.Text = "Click, drag, and release to create an ellipse. Hold shift for a circle";
            }
            else if ((mode == "Polygon") && (checkP))
            {
                toolTip.Text = "Click and drag to create the first line of the polygon. Click again to app verticies. Double click to end.";
            }
            else if (mode == "Free Polygon")
            {
                toolTip.Text = "Click and drag to create the first line of the polygon. Click again to app verticies. Double click to end.";
            }
            else if (mode == "Copy Object")
            {
                toolTip.Text = "Click and drag an object to create a copy of it where you release the mouse. Note lines and polygons will be selected if it is within a box enclosing the object.";
            }
            else if (mode == "Move Object")
            {
                toolTip.Text = "Click and drag an object to move it. Note lines and polygons will be selected if it is within a box enclosing the object.";
            }
            else if (mode == "Erase Object")
            {
                toolTip.Text = "Click an object to erase it. Note lines and polygons will be selected if it is within a box enclosing the object.";
            }
        }

        private void sketchPad_MouseDown(object sender, MouseEventArgs e)
        {
            justDouble = false;
            Console.WriteLine("mouse down");
            prevX = e.X;
            prevY = e.Y;
            if (mode == "Freehand")
            {
                free.Add(new Freehand(new Point(prevX, prevY), colour));
                down = true;
            }
            else if (mode == "Polygon")
            {
                if (checkP)
                {
                    polys.Add(new Polygon(new Point(prevX, prevY), colour));
                    shapeSelection.Enabled = false;
                }
                else
                {
                    polys[pi].addPoint(new Point(e.X, e.Y));
                }
            }
            else if (mode == "Free Polygon")
            {
                //Console.WriteLine("mouse down");
                if (checkP)
                {
                    fpolys.Add(new FreePolygon(new Point(prevX, prevY), colour));
                    shapeSelection.Enabled = false;
                }
                else
                {
                    fpolys[fpi].addPoint(new Point(e.X, e.Y));
                }
            }
            else if ((mode == "Move Object")||(mode == "Copy Object"))
            {
                bool found = false;
                if (!found)
                {
                    foreach (var r in rects)
                    {
                        if (r.positionCheck(e.X, e.Y))
                        {
                            chosen = "rectangle";
                            choice = r;
                            found = true;
                            break;
                        }

                    }
                }
                if (!found)
                {
                    foreach (var c in circles)
                    {
                        if (c.positionCheck(e.X, e.Y))
                        {
                            chosen = "circle";
                            choice = c;
                            found = true;
                            break;
                        }

                    }
                }
                if (!found)
                {
                    foreach (var f in free)
                    {
                        if (f.positionCheck(e.X, e.Y))
                        {
                            chosen = "freehand";
                            choice = f;
                            found = true;
                            break;
                        }

                    }
                }
                if (!found)
                {
                    foreach (var l in lines)
                    {
                        if (l.positionCheck(e.X, e.Y))
                        {
                            chosen = "line";
                            choice = l;
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    foreach (var p in polys)
                    {
                        if (p.positionCheck(e.X, e.Y))
                        {
                            chosen = "polygon";
                            choice = p;
                            found = true;
                            break;
                        }

                    }
                }
                if (!found)
                {
                    foreach (var fp in fpolys)
                    {
                        if (fp.positionCheck(e.X, e.Y))
                        {
                            chosen = "freepolygon";
                            choice = fp;
                            found = true;
                            break;
                        }
                    }
                }

            }
        }

        private void sketchPad_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("mouse up");
            x = e.X;
            y = e.Y;
            //System.Drawing.Graphics graphicsObj;
            Console.WriteLine(prevX+" "+prevY+" "+x+" "+y);
            //graphicsObj = this.CreateGraphics();

            if (mode == "Line")
            {
                lines.Add(new Line(prevX, prevY, x, y, colour));
            }
            else if (mode == "Rectangle")
            {
                if (Control.ModifierKeys == Keys.Shift )
                {
                    if (x > prevX) 
                    {
                        if (y > prevY) { y = prevY + x - prevX; }
                        else { y = prevY - (x - prevX); }
                    }
                    else 
                    {
                        if (y > prevY) { y = prevY + prevX - x; }
                        else { y = prevY - (prevX - x); }
                    }
                }
                rects.Add(new Rect(prevX, prevY, x, y, colour));
            }
            else if (mode == "Freehand")
            {
                down = false;
                fi++;
            }
            else if (mode == "Ellipse")
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    if (x > prevX)
                    {
                        if (y > prevY) { y = prevY + x - prevX; }
                        else { y = prevY - (x - prevX); }
                    }
                    else
                    {
                        if (y > prevY) { y = prevY + prevX - x; }
                        else { y = prevY - (prevX - x); }
                    }
                }
                circles.Add(new Circle(prevX, prevY, x, y, colour));
            }
            else if ((mode == "Polygon")&&(checkP))
            {
                if (!justDouble)
                {
                    polys[pi].addPoint(new Point(e.X, e.Y));
                    checkP = false;
                }
            }
            else if ((mode == "Free Polygon") && (checkP))
            {
                if (!justDouble)
                {
                    fpolys[fpi].addPoint(new Point(e.X, e.Y));
                    checkP = false;
                }
            }
            else if (mode == "Copy Object")
            {
                if (chosen != null)
                {
                    if (chosen == "freehand") {
                        Freehand temp = new Freehand((Freehand)choice);
                        temp.setPos(prevX - x, prevY - y);
                        free.Add(temp);
                        fi++;
                    }
                    else if (chosen == "rectangle")
                    {
                        Rect temp = new Rect((Rect)choice);
                        temp.setPos(prevX - x, prevY - y);
                        rects.Add(temp);
                    }
                    else if (chosen == "circle")
                    {
                        Circle temp = new Circle((Circle)choice);
                        temp.setPos(prevX - x, prevY - y);
                        circles.Add(temp);
                    }
                    else if (chosen == "line")
                    {
                        Line temp = new Line((Line)choice);
                        temp.setPos(prevX - x, prevY - y);
                        lines.Add(temp);
                    }
                    else if (chosen == "freepolygon")
                    {
                        FreePolygon temp = new FreePolygon((FreePolygon)choice);
                        temp.setPos(prevX - x, prevY - y);
                        fpolys.Add(temp);
                        fpi++;
                    }
                    else if (chosen == "polygon")
                    {
                        Polygon temp = new Polygon((Polygon)choice);
                        temp.setPos(prevX - x, prevY - y);
                        polys.Add(temp);
                        pi++;
                    }
                    chosen = null;
                    choice = null;
                }
            }
            else if (mode == "Move Object")
            {
                if (chosen != null)
                {
                    if (chosen == "rectangle") { ((Rect)choice).setPos(prevX-x, prevY-y); }
                    else if (chosen == "circle") { ((Circle)choice).setPos(prevX - x, prevY - y); }
                    else if (chosen == "freehand") { ((Freehand)choice).setPos(prevX - x, prevY - y); }
                    if (chosen == "freepolygon") { ((FreePolygon)choice).setPos(prevX - x, prevY - y); }
                    if (chosen == "polygon") { ((Polygon)choice).setPos(prevX - x, prevY - y); }
                    if (chosen == "line") { ((Line)choice).setPos(prevX - x, prevY - y); }
                    chosen = null;
                    choice = null;
                }
            }
            else if (mode == "Erase Object")
            {
                bool found = false;
                if (!found)
                {
                    foreach (var r in rects)
                    {
                        if (r.positionCheck(e.X, e.Y))
                        {
                            rects.Remove(r);
                            found = true;
                            break;
                        }

                    }
                }
                if (!found)
                {
                    foreach (var c in circles)
                    {
                        if (c.positionCheck(e.X, e.Y))
                        {
                            circles.Remove(c);
                            found = true;
                            break;
                        }

                    }
                }
                if (!found)
                {
                    foreach (var f in free)
                    {
                        if (f.positionCheck(e.X, e.Y))
                        {
                            free.Remove(f);
                            fi--;
                            found = true;
                            break;
                        }

                    }
                }
                if (!found)
                {
                    foreach (var l in lines)
                    {
                        if (l.positionCheck(e.X, e.Y))
                        {
                            lines.Remove(l);
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    foreach (var p in polys)
                    {
                        if (p.positionCheck(e.X, e.Y))
                        {
                            polys.Remove(p);
                            pi--;
                            found = true;
                            break;
                        }

                    }
                }
                if (!found)
                {
                    foreach (var fp in fpolys)
                    {
                        if (fp.positionCheck(e.X, e.Y))
                        {
                            fpolys.Remove(fp);
                            fpi--;
                            found = true;
                            break;
                        }
                    }
                }
                
            }
            sketchPad.Invalidate();
            
        }

        private void sketchPad_MouseMove(object sender, MouseEventArgs e)
        {
            if ((mode == "Freehand") && (down))
            {
                free[fi].addPoint(new Point(e.X, e.Y));
                sketchPad.Invalidate();
            }
        }

        private void sketchPad_Paint(object sender, PaintEventArgs e)
        {
            foreach(var l in lines)
            {
                myPen = new Pen(l.getColor(), 5);
                e.Graphics.DrawLine(myPen, l.getX1(), l.getY1(), l.getX2(), l.getY2());
            }
            foreach (var r in rects)
            {
                myBrush = new SolidBrush(r.getColor());
                Rectangle re = new Rectangle(r.getX1(), r.getY1(), r.getW(), r.getH()); ;                
                e.Graphics.FillRectangle(myBrush, re);
            }
            foreach (var c in circles)
            {
                myBrush = new SolidBrush(c.getColor());
                e.Graphics.FillEllipse(myBrush, c.getX1(), c.getY1(), c.getW(), c.getH());
            }
            foreach (var p in polys)
            {
                myPen = new Pen(p.getColor(), 5);
                e.Graphics.DrawPolygon(myPen, p.getP());
                //myPen = new Pen(l.getColor(), 5);
                //e.Graphics.DrawLine(myPen, l.getX1(), l.getY1(), l.getX2(), l.getY2());
            }
            foreach (var f in free)
            {
                myPen = new Pen(f.getColor(), 5);
                Point px = f.getStart();
                foreach (var p in f.getP())
                {
                    e.Graphics.DrawLine(myPen, px, p);
                    px = p;
                }
            }
            foreach (var fp in fpolys)
            {
                myPen = new Pen(fp.getColor(), 5);
                Point px = fp.getStart();
                foreach (var p in fp.getP())
                {
                    e.Graphics.DrawLine(myPen, px, p);
                    px = p;
                }
            }
            
        }

        private void sketchPad_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (mode == "Polygon")
            {
                pi++;
            }
            else if (mode == "Free Polygon")
            {
                fpi++;
            }
            checkP = true;
            justDouble = true;
            Console.WriteLine("double click");
            shapeSelection.Enabled = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
