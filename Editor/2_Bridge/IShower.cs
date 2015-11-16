using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public interface IShower
    {
        void DrawText(String text);

        void DrawPoligon(params Point[] Points);
        void DrawEllipse(Point Center, Double R);

        void FillPoligon(params Point[] Points);
        void FillEllipse(Point Center, Double R);

        void EndShow();

        // Set params for show()
        void SetBrushForShow(System.Drawing.Brush brush);
    }
}
