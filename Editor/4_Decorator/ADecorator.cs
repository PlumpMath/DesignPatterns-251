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
        protected IShower Shower;

        public ADecorator(IFigure figureToDecorate)
        {
            decoratedFigure = figureToDecorate;
        }

        public override double Area() { return decoratedFigure.Area(); }
        public override void MoveOn(Point dx) { decoratedFigure.MoveOn(dx); }
        public override void MoveTo(Point x) { decoratedFigure.MoveTo(x); }
        public override void Show(int lvl = 0) { decoratedFigure.Show(lvl); }
        public override double Perimeter() { return decoratedFigure.Perimeter(); }
        public override void SetShower(IShower shower)
        {
            this.Shower = shower;
            base.SetShower(shower);
            decoratedFigure.SetShower(shower);
        }

        public override Point[] GetBorder() { return decoratedFigure.GetBorder(); }
        public override void ShowShadow(IShower shower, Point dx) { decoratedFigure.ShowShadow(shower, dx); }
        public override void ShowBorder(IShower shower) { decoratedFigure.ShowBorder(shower); }

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
            Console.WriteLine("RemoveLastPropertyDecorator");

            IFigure lastDecorator = figureToDecorate;
            while (lastDecorator is RemoveLastPropertyDecorator)
                lastDecorator = ((ADecorator)lastDecorator).RemoveLastDecorator();

            if (lastDecorator is ADecorator)
            {
                decoratedFigure = ((ADecorator)lastDecorator).RemoveLastDecorator();

                while (decoratedFigure is RemoveLastPropertyDecorator)
                    decoratedFigure = ((ADecorator)decoratedFigure).RemoveLastDecorator();
            }
        }
    }

    public class ShadowDecorator : ADecorator
    {
        private Point dx = new Point(-5.0, -5.0);

        public ShadowDecorator(IFigure figureToDecorate) : base(figureToDecorate) { }

        public override void Show(int lvl = 0)
        {
            Console.WriteLine("ShadowDecorator");

            Shower.SetBrushForShow(System.Drawing.Brushes.Gray);
            decoratedFigure.ShowShadow(Shower, dx);

            Shower.SetBrushForShow(System.Drawing.Brushes.Black);
            base.Show(lvl);
        }
    }

    public class BorderDecorator : ADecorator
    {
        public BorderDecorator(IFigure figureToDecorate) : base(figureToDecorate) { }

        public override void Show(int lvl = 0)
        {
            Console.WriteLine("BorderDecorator");

            Shower.SetBrushForShow(System.Drawing.Brushes.Red);
            decoratedFigure.ShowBorder(Shower);

            SetBrushForShow(System.Drawing.Brushes.Black);
            base.Show(lvl);
        }
    }
}
