using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class CleverWindowShower : WindowShower
    {
        public CleverWindowShower(double transparency, double scale) : base(transparency, scale)
        {

        }

        public override void DrawPoligon(params Point[] Points)
        {
            PointF[] arr = new PointF[Points.Length];
            for (int i = 0; i < Points.Length; i++) arr[i] = getCoords(Points[i]);

            //g.DrawPolygon(pen, arr);
            if (brush.Equals(System.Drawing.Brushes.Red))   // рамка
                g.DrawPolygon(pen, arr);
            else
                g.FillPolygon(brush, arr);
        }
    }
}
