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
    }
}
