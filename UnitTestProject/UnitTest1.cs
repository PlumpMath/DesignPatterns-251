using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Editor;

namespace UnitTestProject
{
    [TestClass]
    public class StagesTests
    {
        [TestMethod]
        public void Stage1_Prototype_triangle()
        {
            IFigure tr = new Triangle(
                new Point(-10.0, -10.0),
                new Point(10.0, -10.0),
                new Point(0, 10)
                );

            IFigure tr1 = tr.Clone();

            Assert.IsNotNull(tr1);
        }
        [TestMethod]
        public void Stage1_Prototype_rectangle()
        {
            IFigure re = new Rectangle(
                new Point(-10.0, -10.0),
                new Point(10.0, -10.0),
                new Point(10.0, 10.0),
                new Point(-10.0, 10.0)
                );

            IFigure re1 = re.Clone();

            Assert.IsNotNull(re1);
        }
        [TestMethod]
        public void Stage1_Prototype_circle()
        {
            IFigure ci = new Circle(
                new Point(-10.0, -10.0), 
                5.0
                );

            IFigure ci1 = ci.Clone();

            Assert.IsNotNull(ci1);
        }
    }
}
