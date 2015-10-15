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
    }
    public interface IShower
    {
        void DrawPoligon(params Point[] Points);
        void DrawEllipse(Point Center, Double R);

        void EndShow();
    }
}
