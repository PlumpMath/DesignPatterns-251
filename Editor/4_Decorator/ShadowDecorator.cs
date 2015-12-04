using System;

namespace Editor
{
    public class ShadowDecorator : ADecorator
    {
        private Point dx = new Point(-5.0, -5.0);

        public ShadowDecorator(IFigure figureToDecorate) : base(figureToDecorate) { }

        public override IFigure Clone()
        {
            return new ShadowDecorator(decoratedFigure);
        }

        public override void Show(int lvl = 0)
        {
            Shower.DrawText(new String(' ', lvl * 2) + "ShadowDecorator {" + Environment.NewLine);
            Shower.SetBrushForShow(System.Drawing.Brushes.Gray);
            decoratedFigure.ShowShadow(lvl, Shower, dx);

            Shower.SetBrushForShow(System.Drawing.Brushes.Black);
            base.Show(lvl);

            Shower.DrawText(new String(' ', lvl * 2) + "}" + Environment.NewLine);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ShadowDecorator f = obj as ShadowDecorator;
            if (f == null) return false;

            return decoratedFigure.Equals(f.decoratedFigure);
        }
    }
}
