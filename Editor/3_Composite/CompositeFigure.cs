using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class CompositeFigure : AFigure
    {
        private List<AFigure> children = new List<AFigure>();

        // Constructor
        public CompositeFigure()
        {
            this.Name = "CompositeFigure";
        }

        public override double Area()
        {
            Double res = 0.0;
            foreach (AFigure pf in children)
            {
                res += pf.Area();
            }
            return res;
        }
        public override double Perimeter()
        {
            Double res = 0.0;
            foreach (AFigure pf in children)
            {
                res += pf.Perimeter();
            }
            return res;
        }


        public void Add(AFigure component)
        {
            children.Add((AFigure)component.Clone());
        }

        public List<AFigure> GetChildren()
        {
            return children;
        }

        public void Remove(AFigure component)
        {
            children.Remove(component);
        }

        public override void Show(int lvl = 0)
        {
            DrawText(new String('-', lvl * 2) + Name + " : P=,S=");

            foreach (AFigure pf in children)
            {
                pf.Show(lvl + 1);
            }

            if (lvl == 0)
                EndShow();
        }

        public override void SetShower(AShower shower)
        {
            base.SetShower(shower);

            foreach (AFigure pf in children)
            {
                pf.SetShower(shower);
            }
        }
    }
}
