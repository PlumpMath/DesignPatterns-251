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
            //FigureCollection fc = new FigureCollection();
            //PrototypeFigure pf = new Circle(new Point(0,0), 5);
            //fc.Add(new Circle(new Point(0, 0), 5));
            //fc.Add(new Rectangle(new Point(-1, -1), new Point(-1, 1), new Point(1, 1), new Point(1, -1)));
            //fc.Add(new Triangle(new Point(-1,-1), new Point(0, 1), new Point(1, -1)));
            //fc.Add(new Circle(new Point(0, 0), 5));
            //fc.Add(pf);
            //PrototypeFigure pf1 = pf.Clone();
            //fc.Add(pf1);
            //fc.Add(new Circle(new Point(0, 0), 5));
            //fc.Add(new Rectangle(new Point(-1, -1), new Point(-1, 1), new Point(1, 1), new Point(1, -1)));

            //fc.Del(new Circle(new Point(0, 0), 5));
            //fc.Del(pf);
            //fc.Del(pf);

            // 2
            //OutputterAbstraction ab = new RefinedAbstraction();
            //ab.Outputter = new ConsoleOutputter();
            //ab.Output();
            //ab.Outputter = new WindowOutputter();
            //ab.Output();

            PrototypeFigure pfc1 = new Circle(new Point(-1, -1), 50);
            PrototypeFigure pfc2 = new Circle(new Point(1, -1), 75);
            PrototypeFigure pfc3 = new Circle(new Point(1, -1), 100);
            PrototypeFigure pfr1 = new Rectangle(new Point(-100, -100), new Point(-100, 100), new Point(100, 100), new Point(100, -100));
            PrototypeFigure pfr2 = new Rectangle(new Point(-2, -1), new Point(-1, 1), new Point(1, 1), new Point(1, -1));
            PrototypeFigure pfr3 = new Rectangle(new Point(-3, -1), new Point(-1, 1), new Point(1, 1), new Point(1, -1));
            PrototypeFigure pft1 = new Triangle(new Point(-1, -1), new Point(-1, 1), new Point(1, 1));
            PrototypeFigure pft2 = new Triangle(new Point(-2, -1), new Point(-1, 1), new Point(1, 1));
            PrototypeFigure pft3 = new Triangle(new Point(-40, -40), new Point(0, 45), new Point(40, 1));

            // 3
            // Create a tree structure
            CompositeFigure root = new CompositeFigure();

            root.Add(pfc1);
            root.Add(pfc2);

            CompositeFigure comp1 = new CompositeFigure();
            comp1.Add(pfr1);
            comp1.Add(pfr2);

            CompositeFigure comp2 = new CompositeFigure();
            comp2.Add(pfc3);
            comp2.Add(pfr3);
            comp2.Add(pft3);
            comp1.Add(comp2);

            root.Add(comp1);
            root.Add(pfc3);

            root.Outputter = new ConsoleOutputter();
            root.Output();

            root.Outputter = new WindowOutputter(0, 50);
            root.Output();
        }
    }
}

