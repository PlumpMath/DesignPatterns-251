using System;

namespace Editor
{
    public class BorderDecorator : ADecorator
    {
        public BorderDecorator(IFigure figureToDecorate) : base(figureToDecorate) { }

        public override IFigure Clone()
        {
            return new BorderDecorator(decoratedFigure);
        }

        public override void Show(int lvl = 0)
        {
            Shower.DrawText(new String(' ', lvl * 2) + "BorderDecorator {" + Environment.NewLine);
            Shower.SetBrushForShow(System.Drawing.Brushes.Red);
            decoratedFigure.ShowBorder(lvl, Shower);

            SetBrushForShow(System.Drawing.Brushes.Black);
            base.Show(lvl);

            Shower.DrawText(new String(' ', lvl * 2) + "}" + Environment.NewLine);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            BorderDecorator f = obj as BorderDecorator;
            if (f == null) return false;

            return decoratedFigure.Equals(f.decoratedFigure);
        }
    }
}
