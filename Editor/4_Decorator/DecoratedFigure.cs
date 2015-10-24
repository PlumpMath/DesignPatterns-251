using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class DecoratedFigure : IFigureIShower
    {
        protected IFigure figure;
        protected IShower shower;

        public DecoratedFigure(IFigure f)
        {
            this.figure = f;
        }

        public double Area()
        {
            return figure.Area();
        }
        public IFigure Clone()
        {
            return figure.Clone();
        }

        public virtual void DrawEllipse(Point Center, double R)
        {
            shower.DrawEllipse(Center, R);
        }

        public virtual void DrawPoligon(params Point[] Points)
        {
            shower.DrawPoligon(Points);
        }

        public virtual void DrawText(string text)
        {
            shower.DrawText(text);
        }

        public void EndShow()
        {
            shower.EndShow();
        }

        public string GetName()
        {
            return figure.GetName();
        }
        public double Perimeter()
        {
            return figure.Perimeter();
        }
        public void SetShower(IShower shower)
        {
            this.shower = shower;
            figure.SetShower(shower);
        }
        public void Show(int lvl = 0)
        {
            figure.Show(lvl);
        }
    }
}
