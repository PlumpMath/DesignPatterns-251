using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class ADecorator : AFigure
    {
        AFigure decoratedFigure;

        public override double Area() { return decoratedFigure.Area(); }
        public override void MoveOn(Point dx) { decoratedFigure.MoveOn(dx); }
        public override void MoveTo(Point x) { decoratedFigure.MoveTo(x); }
        public override void Show(int lvl) { decoratedFigure.Show(lvl); }
        public override double Perimeter() { return decoratedFigure.Perimeter(); }
    }
}
