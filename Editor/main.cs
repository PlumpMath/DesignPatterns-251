using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class main
    {
        static void Main(string[] args)
        {
            IFigure pfc1 = new Circle(new Point(-1, -1), 50);
            IFigure pfc2 = new Circle(new Point(1, -1), 75);
            IFigure pfc3 = new Circle(new Point(1, -1), 100);
            IFigure pfr1 = new Rectangle(new Point(-100, -100), new Point(-100, 100), new Point(100, 100), new Point(100, -100));
            IFigure pfr2 = new Rectangle(new Point(-2, -1), new Point(-1, 1), new Point(1, 1), new Point(1, -1));
            IFigure pfr3 = new Rectangle(new Point(-3, -1), new Point(-1, 1), new Point(1, 1), new Point(1, -1));
            IFigure pft1 = new Triangle(new Point(-1, -1), new Point(-1, 1), new Point(1, 1));
            IFigure pft2 = new Triangle(new Point(-2, -1), new Point(-1, 1), new Point(1, 1));
            IFigure pft3 = new Triangle(new Point(-40, -40), new Point(0, 45), new Point(40, 1));

            /**/
            // 3
            // Create a tree structure
            //CompositeFigure root = new CompositeFigure();

            //root.Add(pfc1);
            //root.Add(pfc2);

            //CompositeFigure comp1 = new CompositeFigure();
            //comp1.Add(pfr1);
            //comp1.Add(pfr2);

            //CompositeFigure comp2 = new CompositeFigure();
            //comp2.Add(pfc3);
            //comp2.Add(pfr3);
            //comp2.Add(pft3);
            //comp1.Add(comp2);

            //root.Add(comp1);
            //root.Add(pfc3);

            //root.SetShower(new ConsoleShower());
            //root.Show();
            //root.EndShow();

            //root.SetShower(new WindowShower(0, 200));
            //root.Show();
            //root.EndShow();

            /**/

            // 4
            IFigure dc1 = new Circle(new Point(70, 70), 30);
            IFigure dr1 = new Rectangle(new Point(-40, 40), new Point(-90, 40), new Point(-90, 90), new Point(-40, 90));
            IFigure dt1 = new Triangle(new Point(-20, -40), new Point(20, -40), new Point(0, 0));

            dc1 = new BorderDecorator(dc1);

            CompositeFigure root = new CompositeFigure();
            root.Add(dt1);
            root.Add(dr1);
            root.Add(dc1);

            //IFigure IFSD = new Triangle(new Point(-40, -40), new Powdewint(40, -40), new Point(0, 40));
            IFigure IFSD = new ShadowDecorator(root);
            IFSD = new ShadowDecorator(IFSD);
            IFSD = new BorderDecorator(IFSD);
            IFSD = new RemoveLastPropertyDecorator(IFSD);

            IFSD.SetShower(new ConsoleShower());
            IFSD.Show();

            IFSD.SetShower(new WindowShower(0, 200));
            IFSD.Show();
            IFSD.EndShow();
        }
    }
}

