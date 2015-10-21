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
            children.Add((AFigure)component.Clone());
        }

        public List<IFigure> GetChildren()
        {
            return children;
        }

        public void Remove(IFigure component)
        {
            children.Remove(component);
        }

        public override void Show(int lvl = 0)
        {
            //SetDecoratorParams(DPs);

            DrawText(new String('-', lvl * 2) + GetName() + " : P=,S=" + Environment.NewLine);

            foreach (IFigure pf in children)
            {
                pf.Show(lvl + 1);
            }

            if (lvl == 0)
                EndShow();
        }

        public override void SetShower(AShower shower)
        {
            base.SetShower(shower);

            foreach (IFigure pf in children)
            {
                pf.SetShower(shower);
            }
        }
    }
}
