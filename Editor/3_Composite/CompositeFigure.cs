using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class CompositeFigure : PrototypeFigure
    {
        private List<PrototypeFigure> children = new List<PrototypeFigure>();

        // Constructor
        public CompositeFigure()
        {
            this.Name = "CompositeFigure";
        }

        public override double Area()
        {
            Double res = 0.0;
            foreach (PrototypeFigure pf in children)
            {
                res += pf.Area();
            }
            return res;
        }
        public override double Perimeter()
        {
            Double res = 0.0;
            foreach (PrototypeFigure pf in children)
            {
                res += pf.Perimeter();
            }
            return res;
        }


        public void Add(PrototypeFigure component)
        {
            children.Add(component.Clone());
        }

        public List<PrototypeFigure> GetChildren()
        {
            return children;
        }

        public void Remove(PrototypeFigure component)
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
    }
}
