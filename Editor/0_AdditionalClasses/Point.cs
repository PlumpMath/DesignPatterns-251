﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Point operator *(Point p, double c)
        {
            return new Point(c * p.X, c * p.Y);
        }
        public static Point operator *(double c, Point p)
        {
            return new Point(c * p.X, c * p.Y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Double DistanceBetween(Point A, Point B)
        {
            return Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }
        public static Double TriangleArea(Point A, Point B, Point C)
        {
            Double a = Point.DistanceBetween(B, C);
            Double b = Point.DistanceBetween(A, C);
            Double c = Point.DistanceBetween(B, A);
            Double p = (a + b + c) / 2.0;

            Double tmp = p * (p - a) * (p - b) * (p - c);
            if (tmp < 0)
                throw new ArgumentOutOfRangeException("Wrong triangle");

            return Math.Sqrt(tmp);
        }
        public override string ToString()
        {
            return "(" + X + ";" + Y + ")";
        }
    }
}