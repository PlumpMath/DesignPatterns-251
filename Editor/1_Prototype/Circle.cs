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
            SetName("Circle");
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

        public override void myShow(int lvl)
        {
            DrawText(new String('-', lvl * 2) + GetName() + " : P=,S=");
            DrawEllipse(Center, R);
        }

        public override void MoveTo(Point x) { Center.MoveTo(x); }
        public override void MoveOn(Point dx) { Center.MoveOn(dx); }
    }
}
