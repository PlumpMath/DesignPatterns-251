using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class AdditionalFigureDecorator : IFigure
    {
        protected IFigure decoratedFigure;
        protected IShower Shower;

        public AdditionalFigureDecorator(IFigure figureToDecorate)
        {
            decoratedFigure = figureToDecorate;
        }

        #region IFigure
        public double Area() { return decoratedFigure.Area(); }
        public IFigure Clone() { return decoratedFigure.Clone(); }
        public void EndShow() { decoratedFigure.EndShow(); }
        public Point[] GetBorder() { return decoratedFigure.GetBorder(); }
        public string GetName() { return decoratedFigure.GetName(); }
        public void MoveOn(Point dx) { decoratedFigure.MoveOn(dx); }
        public void MoveTo(Point x) { decoratedFigure.MoveTo(x); }
        public double Perimeter() { return decoratedFigure.Perimeter(); }
        public void SetShower(IShower shower)
        {
            this.Shower = shower;

            //if (!(shower is AdditionalShowerDecorator))
            shower = new AdditionalShowerDecorator(shower, decoratedFigure);

            decoratedFigure.SetShower(shower);
        }
        public void Show(int lvl = 0) { decoratedFigure.Show(lvl); }
        public void ShowBorder(int lvl, IShower shower) { decoratedFigure.ShowBorder(lvl, shower); }
        public void ShowShadow(int lvl, IShower shower, Point dx) { decoratedFigure.ShowShadow(lvl, shower, dx); }
        #endregion
    }
}
