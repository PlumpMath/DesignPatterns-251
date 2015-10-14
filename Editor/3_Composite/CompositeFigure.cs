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

        // 2
        // Property
        public Implementor Outputter { get; set; }
        public void Output()
        {
            Outputter.Output(this);
        }

        public override void Show()
        {
            foreach (AFigure pf in children)
            {
                pf.Show();
            }
        }
    }
}
