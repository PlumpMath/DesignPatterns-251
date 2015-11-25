using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Editor;

namespace UnitTestProject._0_AdditionalClasses
{
    [TestClass]
    public class PointTest
    {
        private const double DELTA = 1e-10;

        [TestMethod]
        public void TM01_Constructor()
        {
            double X = 1.0;
            double Y = 2.0;

            Point p = new Point(X, Y);

            Assert.AreEqual(X, p.X, DELTA);
            Assert.AreEqual(Y, p.Y, DELTA);
        }

        [TestMethod]
        public void TM02_Constructor()
        {
            double X = 1.0;
            double Y = 2.0;
            Point p1 = new Point(X, Y);

            Point p = new Point(p1);

            Assert.AreEqual(X, p.X, DELTA);
            Assert.AreEqual(Y, p.Y, DELTA);
        }

        [TestMethod]
        public void TM03_operator_multiply()
        {
            double X = 1.0;
            double Y = 2.0;
            double c = 3.0;
            Point p1 = new Point(X, Y);

            Point p = p1 * c;

            Assert.AreEqual(c * X, p.X, DELTA);
            Assert.AreEqual(c * Y, p.Y, DELTA);
        }

        [TestMethod]
        public void TM04_operator_multiply()
        {
            double X = 1.0;
            double Y = 2.0;
            double c = 3.0;
            Point p1 = new Point(X, Y);

            Point p = c * p1;

            Assert.AreEqual(c * X, p.X, DELTA);
            Assert.AreEqual(c * Y, p.Y, DELTA);
        }

        [TestMethod]
        public void TM05_operator_()
        {
            double X1 = 1.0, Y1 = 2.0;
            double X2 = 3.0, Y2 = 4.0;
            Point p1 = new Point(X1, Y1);
            Point p2 = new Point(X2, Y2);

            Point p = p2 - p1;

            Assert.AreEqual(X2 - X1, p.X, DELTA);
            Assert.AreEqual(Y2 - Y1, p.Y, DELTA);
        }

        [TestMethod]
        public void TM06_operator_sum()
        {
            double X1 = 1.0, Y1 = 2.0;
            double X2 = 3.0, Y2 = 4.0;
            Point p1 = new Point(X1, Y1);
            Point p2 = new Point(X2, Y2);

            Point p = p1 + p2;

            Assert.AreEqual(X1 + X2, p.X, DELTA);
            Assert.AreEqual(Y1 + Y2, p.Y, DELTA);
        }

        [TestMethod]
        public void TM07_Clone()
        {
            double X1 = 1.0, Y1 = 2.0;
            Point p1 = new Point(X1, Y1);

            Point p = p1.Clone();
            p1 = new Point(X1 + 1.0, Y1 + 1.0);

            Assert.AreEqual(X1, p.X, DELTA);
            Assert.AreEqual(Y1, p.Y, DELTA);
        }

        [TestMethod]
        public void TM08_DistanceBetween()  // Another tests can be written
        {
            double X1 = 1.0, Y1 = 1.0;
            double X2 = 4.0, Y2 = 5.0;
            Point p1 = new Point(X1, Y1);
            Point p2 = new Point(X2, Y2);

            double dist = Point.DistanceBetween(p1, p2);

            Assert.AreEqual(5.0, dist, DELTA);
        }

        [TestMethod]
        public void TM09_TriangleArea()  // Another tests can be written
        {
            // [AB, BC, AC] == [3, 4, 5]
            double X1 = 1.0, Y1 = 1.0;
            double X2 = 4.0, Y2 = 1.0;
            double X3 = 4.0, Y3 = 5.0;
            Point p1 = new Point(X1, Y1);
            Point p2 = new Point(X2, Y2);
            Point p3 = new Point(X3, Y3);

            double dist = Point.TriangleArea(p1, p2, p3);

            Assert.AreEqual(6.0, dist, DELTA);
        }

        [TestMethod]
        public void TM10_MoveTo()
        {
            double X1 = 1.0, Y1 = 2.0;
            double X2 = 3.0, Y2 = 4.0;
            Point p1 = new Point(X1, Y1);
            Point p = new Point(X2, Y2);

            p.MoveTo(p1);

            Assert.AreEqual(X1, p.X, DELTA);
            Assert.AreEqual(Y1, p.Y, DELTA);
        }

        [TestMethod]
        public void TM11_MoveOn()
        {
            double X1 = 1.0, Y1 = 2.0;
            double X2 = 3.0, Y2 = 4.0;
            Point p1 = new Point(X1, Y1);
            Point p = new Point(X2, Y2);

            p.MoveOn(p1);

            Assert.AreEqual(X1 + X2, p.X, DELTA);
            Assert.AreEqual(Y1 + Y2, p.Y, DELTA);
        }

        [TestMethod]
        public void TM12_Equals()
        {
            double X1 = 1.0, Y1 = 2.0;
            Point p1 = new Point(X1, Y1);

            bool b = p1.Equals(null);

            Assert.IsFalse(b);
        }

        [TestMethod]
        public void TM13_Equals()
        {
            double X1 = 1.0, Y1 = 2.0;
            Point p1 = new Point(X1, Y1);

            bool b = p1.Equals(new object());

            Assert.IsFalse(b);
        }

        [TestMethod]
        public void TM14_Equals()
        {
            double X1 = 1.0, Y1 = 2.0;
            double X2 = 1.0, Y2 = 2.0;
            Point p1 = new Point(X1, Y1);
            Point p2 = new Point(X2, Y2);

            bool b = p1.Equals(p2);

            Assert.IsFalse(b);
        }

        [TestMethod]
        public void TM15_Equals()
        {
            double X1 = 1.0, Y1 = 2.0;
            double X2 = 3.0, Y2 = 2.0;
            Point p1 = new Point(X1, Y1);
            Point p2 = new Point(X2, Y2);

            bool b = p1.Equals(p2);

            Assert.IsFalse(b);
        }

        [TestMethod]
        public void TM16_Equals()
        {
            double X1 = 1.0, Y1 = 2.0;
            Point p1 = new Point(X1, Y1);

            bool b = p1.Equals(p1);

            Assert.IsTrue(b);
        }

        [TestMethod]
        public void TM17_Equals()
        {
            double X1 = 1.0, Y1 = 2.0;
            Point p1 = new Point(X1, Y1);
            Point p2 = p1;

            bool b = p1.Equals(p2);

            Assert.IsTrue(b);
        }
    }
}
