using System.Drawing;

namespace Editor
{
    class AdditionalShowerDecorator : IShower
    {
        protected IFigure figureThatItWillShow;
        protected IShower decoratedShower;

        public AdditionalShowerDecorator(IShower decoratedShower, IFigure figureThatItWillShow)
        {
            this.decoratedShower = decoratedShower;
            this.figureThatItWillShow = figureThatItWillShow;
        }

        #region IShower
        public void SetBrushForShow(Brush brush)
        {
            decoratedShower.SetBrushForShow(brush);
        }
        public void DrawEllipse(Point Center, double R)
        {
            decoratedShower.DrawEllipse(Center, R);
        }
        public void DrawPoligon(params Point[] Points)
        {
            decoratedShower.DrawPoligon(Points);
        }
        public void FillEllipse(Point Center, double R)
        {
            decoratedShower.FillEllipse(Center, R);
            decoratedShower.DrawEllipse(Center, R);
        }
        public void FillPoligon(params Point[] Points)
        {
            decoratedShower.FillPoligon(Points);
        }
        public void DrawText(string text) { decoratedShower.DrawText(text); }
        public void EndShow()
        {
            decoratedShower.EndShow();
        }

        public void Clean()
        {
            decoratedShower.Clean();
        }
        #endregion
    }
}
