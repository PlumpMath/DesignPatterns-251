using System;
using System.Windows.Forms;
using System.Drawing;

namespace Editor
{
    public abstract class AShower : IShower
    {
        #region IShower
        public abstract void DrawEllipse(Point Center, Double R);
        public abstract void FillEllipse(Point Center, Double R);
        public abstract void DrawPoligon(params Point[] Points);
        public abstract void FillPoligon(params Point[] Points);
        public abstract void DrawText(String text);
        public abstract void EndShow();

        // Set params for show()
        public abstract void SetBrushForShow(Brush brush);
        #endregion
    }

    public class ConsoleShower : AShower
    {
        public override void FillEllipse(Point Center, double R) { DrawEllipse(Center, R); }
        public override void FillPoligon(params Point[] Points) { DrawPoligon(Points); }
        public override void DrawEllipse(Point Center, double R)
        {
            Console.WriteLine(" : center=" + Center.ToString() + " , R=" + R);
        }
        public override void DrawPoligon(params Point[] Points)
        {
            Console.Write(" : points=");
            for (int i = 0; i < Points.Length; i++)
            {
                Console.Write(Points[i].ToString());
                if (i != Points.Length - 1)
                    Console.Write(",");
            }
            Console.WriteLine();
        }
        public override void DrawText(String text)
        {
            Console.Write(text);
        }

        public override void EndShow()
        {
            Console.WriteLine("Done!" + Environment.NewLine + Environment.NewLine);
        }

        public override void SetBrushForShow(Brush brush)
        {
        }
    }
    public class WindowShower : AShower
    {
        private Point formCenter;
        protected Brush brush = Brushes.Black;
        protected Pen pen;
        public double transparency { get; set; }
        public double scale { get; set; }
        private double kScale;
        private Form1 f1;
        public Graphics g;
        public WindowShower(double transparency, double scale)
        {
            this.transparency = transparency;
            this.scale = scale;
            this.kScale = scale / 100.0;
            this.pen = new Pen(brush);
            f1 = new Form1();
            g = Graphics.FromImage(f1.bmp);
            this.formCenter = new Point(f1.bmp.Width / 2.0, f1.bmp.Height / 2.0);
        }
        public Form1 GetForm()
        {
            return f1;
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
            PointF p123 = convert(convert(EllipseCenter) - (new Point(r,r)));

            pen = new Pen(Brushes.YellowGreen);
            g.DrawEllipse(pen, new RectangleF(p123, size));
        }
        public override void DrawPoligon(params Point[] Points)
        {
            PointF[] arr = new PointF[Points.Length];
            for (int i = 0; i < Points.Length; i++) arr[i] = getCoords(Points[i]);

            pen = new Pen(Brushes.YellowGreen);
            g.DrawPolygon(pen, arr);
        }
        public override void FillEllipse(Point Center, double R)
        {
            float r = (float)(R * kScale);
            SizeF size = new SizeF(2.0f * r, 2.0f * r);
            PointF EllipseCenter = getCoords(Center);
            PointF p123 = convert(convert(EllipseCenter) - (new Point(r, r)));

            g.FillEllipse(brush, new RectangleF(p123, size));
        }
        public override void FillPoligon(params Point[] Points)
        {
            PointF[] arr = new PointF[Points.Length];
            for (int i = 0; i < Points.Length; i++) arr[i] = getCoords(Points[i]);

            g.FillPolygon(brush, arr);
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
