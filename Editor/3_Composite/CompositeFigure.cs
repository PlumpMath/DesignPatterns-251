using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class CompositeFigure : AFigure
    {
        private List<IFigure> children = new List<IFigure>();

        // Constructor
        public CompositeFigure()
        {
            SetName("CompositeFigure");
        }

        public override IFigure Clone()
        {
            CompositeFigure res = new CompositeFigure();
            foreach (IFigure f in children)
            {
                res.Add(f.Clone());
            }
            return res;
        }

        public override double Area()
        {
            Double res = 0.0;
            foreach (IFigure pf in children)
            {
                res += pf.Area();
            }
            return res;
        }
        public override double Perimeter()
        {
            Double res = 0.0;
            foreach (IFigure pf in children)
            {
                res += pf.Perimeter();
            }
            return res;
        }


        public void Add(IFigure component)
        {
            children.Add(component.Clone());
        }
        public void Remove(IFigure component)
        {
            children.Remove(component);
        }

        public override void Show(int lvl = 0)
        {
            DrawText(new String('-', lvl * 2) + GetName() + " : P=,S=" + Environment.NewLine);

            foreach (IFigure pf in children)
            {
                pf.Show(lvl + 1);
            }
        }

        public override void SetShower(IShower shower)
        {
            base.SetShower(shower);

            foreach (IFigure pf in children)
            {
                pf.SetShower(shower);
            }
        }

        public override void MoveTo(Point x)
        {
            foreach (IFigure pf in children)
            {
                pf.MoveTo(x);
            }
        }
        public override void MoveOn(Point dx)
        {
            foreach (IFigure pf in children)
            {
                pf.MoveOn(dx);
            }
        }
        public override Point[] GetBorder()
        {
            Double minX = Double.PositiveInfinity, maxX = Double.NegativeInfinity;
            Double minY = Double.PositiveInfinity, maxY = Double.NegativeInfinity;

            Point[] arrP;

            foreach (IFigure pf in children)
            {
                arrP = pf.GetBorder();
                if (arrP.Length != 2)
                    throw new Exception("CompositeFigure : GetBorder : arrP.Length != 2");

                if (arrP[0].X < minX) minX = arrP[0].X;
                if (arrP[1].X > maxX) maxX = arrP[1].X;
                if (arrP[0].Y < minY) minY = arrP[0].Y;
                if (arrP[1].Y > maxY) maxY = arrP[1].Y;
            }

            return new Point[2] { new Point(minX, minY), new Point(maxX, maxY) };
        }
        public override void ShowShadow(int lvl, IShower shower, Point dx)
        {
            DrawText(new String('+', lvl * 2) + "shadow CompositeFigure" + Environment.NewLine);

            foreach (IFigure f in children)
                f.ShowShadow(lvl, shower, dx);
        }
        public override void ShowBorder(int lvl, IShower shower)
        {
            DrawText(new String('+', lvl * 2) + "border CompositeFigure" + Environment.NewLine);

            Point[] border = GetBorder();
            Point[] poligon = new Point[4];
            poligon[0] = new Point(border[0].X, border[0].Y);
            poligon[1] = new Point(border[0].X, border[1].Y);
            poligon[2] = new Point(border[1].X, border[1].Y);
            poligon[3] = new Point(border[1].X, border[0].Y);
            FillPoligon(shower, poligon);
        }
    }
}
