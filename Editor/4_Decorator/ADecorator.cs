using System;

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

        public override IFigure Clone()
        {
            throw new Exception("Override ADecorator.Clone() first!");
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
        public override void ShowShadow(int lvl, IShower shower, Point dx) { decoratedFigure.ShowShadow(lvl, shower, dx); }
        public override void ShowBorder(int lvl, IShower shower) { decoratedFigure.ShowBorder(lvl, shower); }


        public IFigure RemoveLastDecorator()
        {
            if (this is ADecorator)
                return decoratedFigure;
            else
                return this;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return decoratedFigure.Equals(obj);
        }
    }
}