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
            // 6
            //IFigure dr6 = new Rectangle(new Point(0, 0), new Point(10, 0), new Point(10, 10), new Point(0, 10));
            //IFigure dt6 = new Triangle(new Point(0, 0), new Point(10, 0), new Point(0, 10));
            //CompositeFigure root6_1 = new CompositeFigure();
            //root6_1.Add(dr6.Clone());
            //root6_1.Add(dt6.Clone());
            //root6_1.Add(dr6.Clone());

            //CompositeFigure root6_2 = new CompositeFigure();
            //root6_2.Add(dt6.Clone());
            //root6_2.Add(dr6.Clone());
            //root6_2.Add(root6_1.Clone());

            //root6_2.SetShower(new ConsoleShower());
            //root6_2.Show();
            //root6_2.EndShow();

            ////root7.Sort(new ByArea());
            //root6_2.Sort(new ByPerimeter());
            //root6_2.Show();
            //root6_2.EndShow();

            // 7
            IFigure dc7 = new Circle(new Point(10.0, -10.0), 10.0);
            IFigure dr7 = new Rectangle(new Point(0, 0), new Point(10, 0), new Point(10, 10), new Point(0, 10));
            IFigure dt7 = new Triangle(new Point(0, 0), new Point(10, 0), new Point(0, 10));
            CompositeFigure cf7 = new CompositeFigure(dc7, dr7, dt7);
            //cf7.Remove(dc7);

            User user = new User();

            user.AddFigure(dc7);
            user.AddFigure(dr7);
            user.AddFigure(dt7);
            user.AddFigure(cf7);
            user.DelFigure(dr7);
            user.AddFigure(dr7);
            user.MakeComposite(dc7, dr7);

            user.Undo(2);

            Console.ReadKey();
        }
    }
}

