using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class Circle : AFigure
    {
        public Point Center { get; private set; }
        public Double R { get; private set; }

        public Circle(Point center, Double r)
        {
            this.Name = "Circle";
            this.Center = center;
            this.R = r;
        }

        public override Double Area()
        {
            return Math.PI * R * R;
        }
        public override Double Perimeter()
        {
            return 2 * Math.PI * R;
        }

        public override void Show()
        {
            Shower.SetMsg();
            DrawEllipse(Center, R);
        }
    }
}
