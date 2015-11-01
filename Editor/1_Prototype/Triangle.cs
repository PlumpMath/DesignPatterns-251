using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Triangle : AFigure
    {
        private Point[] points;

        public Triangle(Point a1, Point a2, Point a3)
        {
            SetName("Triangle");

            points = new Point[3];
            points[0] = new Point(a1);
            points[1] = new Point(a2);
            points[2] = new Point(a3);
        }
        public override IFigure Clone() { return new Triangle(points[0], points[1], points[2]); }

        public override double Area()
        {
            return
                Point.TriangleArea(points[0], points[1], points[2]);
        }
        public override double Perimeter()
        {
            return
                Point.DistanceBetween(points[0], points[1]) +
                Point.DistanceBetween(points[1], points[2]) +
                Point.DistanceBetween(points[2], points[0]);
        }

        public override void Show(int lvl = 0)
        {
            DrawText(new String('-', lvl * 2) + GetName() + " : P=,S=");
            DrawPoligon(points);
        }

        public override void MoveTo(Point x)
        {
            foreach (Point p in points)
                p.MoveTo(x);
        }
        public override void MoveOn(Point dx)
        {
            foreach (Point p in points)
                p.MoveOn(dx);
        }
        public override Point[] GetBorder()
        {
            double minX = points[0].X, maxX = points[0].X;
            double minY = points[0].Y, maxY = points[0].Y;

            foreach (Point p in points)
            {
                if (p.X < minX) minX = p.X;
                if (p.X > maxX) maxX = p.X;
                if (p.Y < minY) minY = p.Y;
                if (p.Y > maxY) maxY = p.Y;
            }

            return new Point[2] { new Point(minX, minY), new Point(maxX, maxY) };
        }
        public override void ShowShadow(int lvl, IShower shower, Point dx)
        {
            DrawText(new String('+', lvl * 2) + "shadow");

            Point[] poligon = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
                poligon[i] = points[i] + dx;
            DrawPoligon(shower, poligon);
        }
        public override void ShowBorder(int lvl, IShower shower)
        {
            DrawText(new String('+', lvl * 2) + "border");

            Point[] border = GetBorder();
            Point[] poligon = new Point[4];
            poligon[0] = new Point(border[0].X, border[0].Y);
            poligon[1] = new Point(border[0].X, border[1].Y);
            poligon[2] = new Point(border[1].X, border[1].Y);
            poligon[3] = new Point(border[1].X, border[0].Y);
            DrawPoligon(shower, poligon);
        }
    }
}
