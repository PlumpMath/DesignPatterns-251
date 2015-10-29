using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public abstract class ADecorator : AFigure
    {
        protected IFigure decoratedFigure;

        public ADecorator(IFigure figureToDecorate)
        {
            decoratedFigure = figureToDecorate;
        }

        public override double Area() { return decoratedFigure.Area(); }
        public override void MoveOn(Point dx) { decoratedFigure.MoveOn(dx); }
        public override void MoveTo(Point x) { decoratedFigure.MoveTo(x); }
        public override void Show(int lvl = 0) { decoratedFigure.Show(lvl); }
        public override double Perimeter() { return decoratedFigure.Perimeter(); }
        public override void SetShower(IShower shower) { base.SetShower(shower); decoratedFigure.SetShower(shower); }

        public IFigure RemoveLastDecorator()
        {
            if (this is ADecorator)
                return decoratedFigure;
            else
                return this;
        }
    }

    public class RemoveLastPropertyDecorator : ADecorator
    {
        public RemoveLastPropertyDecorator(IFigure figureToDecorate) : base(figureToDecorate)
        {
            IFigure lastDecorator = figureToDecorate;
            while (lastDecorator is RemoveLastPropertyDecorator)
                lastDecorator = ((ADecorator)lastDecorator).RemoveLastDecorator();

            if (lastDecorator is ADecorator)
            {
                decoratedFigure = ((ADecorator)lastDecorator).RemoveLastDecorator();
            }
        }
    }

    public class ShadowDecorator : ADecorator
    {
        private Point dx = new Point(-2.0, -2.0);

        public ShadowDecorator(IFigure figureToDecorate) : base(figureToDecorate) { }

        public override void Show(int lvl = 0)
        {
            SetBrushForShow(System.Drawing.Brushes.Gray);
            decoratedFigure.MoveOn(dx);
            decoratedFigure.Show(lvl);
            decoratedFigure.MoveOn(-1 * dx);

            SetBrushForShow(System.Drawing.Brushes.Black);
            base.Show(lvl);
        }
    }
}
