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
            // 4
            //IFigure dc4 = new Circle(new Point(70, 70), 30);
            //IFigure dr4 = new Rectangle(new Point(-40, 40), new Point(-90, 40), new Point(-90, 90), new Point(-40, 90));
            //IFigure dt4 = new Triangle(new Point(-20, -40), new Point(20, -40), new Point(0, 0));

            ////dc4 = new BorderDecorator(dc4);
            ////dt4 = new BorderDecorator(dt4);
            ////dt4 = new RemoveLastPropertyDecorator(dt4);

            //CompositeFigure root4 = new CompositeFigure();
            //root4.Add(dt4);
            //root4.Add(dr4);
            //root4.Add(dc4);

            //IFigure forClone = new ShadowDecorator(root4);
            //forClone = new ShadowDecorator(forClone);
            //forClone = new BorderDecorator(forClone);
            ////forClone = new RemoveLastPropertyDecorator(forClone);

            //IFigure IFSD4 = forClone.Clone();
            //forClone = root4;

            //IFSD4.SetShower(new ConsoleShower());
            //IFSD4.Show();

            //IFSD.SetShower(new WindowShower(0, 200));
            //IFSD.Show();
            //IFSD.EndShow();

            // Костыль
            //IFSD4.SetShower(new CleverWindowShower(0, 200));
            //IFSD4.Show();
            //IFSD4.EndShow();

            // Декоратор
            //IFSD4 = new SuperUltraDecorator(IFSD4);

            //IFSD4.SetShower(new ConsoleShower());
            //IFSD4.Show();

            //IFSD4.SetShower(new WindowShower(0, 200));
            //IFSD4.Show();
            //IFSD4.EndShow();

            // 5
            IFigure dc5 = new Circle(new Point(70, 70), 30);
            IFigure dr5 = new Rectangle(new Point(-40, 40), new Point(-90, 40), new Point(-90, 90), new Point(-40, 90));
            IFigure dt5 = new Triangle(new Point(-20, -40), new Point(20, -40), new Point(0, 0));
            CompositeFigure root5 = new CompositeFigure();
            root5.Add(dc5);
            root5.Add(dr5);
            root5.Add(dt5);

            List<int> keys = new List<int>();
            Registry r1 = Registry.GetInstance();
            keys.Add(r1.Regisry(dc5));
            keys.Add(r1.Regisry(dr5));
            keys.Add(r1.Regisry(dt5));
            keys.Add(r1.Regisry(root5));

            IFigure IFSD5_1 = r1.Create(3);
            IFigure IFSD5_2 = r1.Create(3);
            IFSD5_1.MoveOn(new Point(15, 15));

            CompositeFigure IFSD5 = new CompositeFigure();
            IFSD5.Add(IFSD5_1);
            IFSD5.Add(IFSD5_2);

            IFSD5.SetShower(new WindowShower(0, 200));
            IFSD5.Show();
            IFSD5.EndShow();
        }
    }
}

