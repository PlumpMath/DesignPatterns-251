using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public interface IFigure
    {
        IFigure Clone();

        String GetName();
        Double Area();
        Double Perimeter();

        void MoveTo(Point x);
        void MoveOn(Point dx);

        // Shower
        void SetShower(IShower shower);
        void Show(int lvl = 0);
        void EndShow();

        // Decorator
        Point[] GetBorder();
        void ShowShadow(IShower shower, Point dx);
        void ShowBorder(IShower shower);
    }
}
