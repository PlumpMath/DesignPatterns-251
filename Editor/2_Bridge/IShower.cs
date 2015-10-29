using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public interface IShower
    {
        void DrawPoligon(params Point[] Points);
        void DrawEllipse(Point Center, Double R);
        void DrawText(String text);

        void EndShow();

        // Set params for show()
        void SetBrushForShow(System.Drawing.Brush brush);
    }
}
