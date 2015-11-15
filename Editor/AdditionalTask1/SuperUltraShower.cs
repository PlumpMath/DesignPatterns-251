using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Editor
{
    class SuperUltraShower : AShower
    {
        private Point formCenter;
        protected Brush brush = Brushes.Black;
        protected Pen pen;
        public double transparency { get; set; }
        public double scale { get; set; }
        private double kScale;
        private Form1 f1;
        public Graphics g;

        public SuperUltraShower(Form1 f1, double transparency, double scale)
        {
            this.transparency = transparency;
            this.scale = scale;
            this.kScale = scale / 100.0;
            this.pen = new Pen(brush);
            this.f1 = f1;
            g = Graphics.FromImage(f1.bmp);
            this.formCenter = new Point(f1.bmp.Width / 2.0, f1.bmp.Height / 2.0);
        }

        protected PointF getCoords(Point p)
        {
            Point newPoint = formCenter - kScale * p;
            return convert(newPoint);
        }
        private Point convert(PointF pf) { return new Point((double)pf.X, (double)pf.Y); }
        private PointF convert(Point pf) { return new PointF((float)pf.X, (float)pf.Y); }

        // AShower
        public override void DrawEllipse(Point Center, double R)
        {
            float r = (float)(R * kScale);
            SizeF size = new SizeF(2.0f * r, 2.0f * r);
            PointF EllipseCenter = getCoords(Center);
            PointF p123 = convert(convert(EllipseCenter) - (new Point(r, r)));

            g.DrawEllipse(pen, new RectangleF(p123, size));
            //g.FillEllipse(brush, new RectangleF(p123, size));
        }
        public override void DrawPoligon(params Point[] Points)
        {
            PointF[] arr = new PointF[Points.Length];
            for (int i = 0; i < Points.Length; i++) arr[i] = getCoords(Points[i]);

            g.DrawPolygon(pen, arr);
            //g.FillPolygon(brush, arr);
        }
        public override void DrawText(String text) { }

        public override void EndShow()
        {
            f1.Invalidate();
            f1.ShowDialog();
        }

        public override void SetBrushForShow(Brush brush)
        {
            this.brush = brush;
            pen = new Pen(brush);
        }
    }
}
