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
            // 7
            IFigure dc7 = new Circle(new Point(0.0, -50.0), 50.0);
            IFigure dr7 = new Rectangle(new Point(50, 50), new Point(150, 50), new Point(150, 150), new Point(50, 150));
            IFigure dt7 = new Triangle(new Point(-150, 50), new Point(-50, 50), new Point(-100, 150));
            CompositeFigure cf7 = new CompositeFigure(dc7, dr7, dt7);

            User user = new User();

            user.AddFigure(dc7);
            user.AddFigure(dr7);
            user.DecorateWithShadow(ref dt7);
            user.AddFigure(dt7);
            user.AddFigure(cf7);
            user.DelFigure(dr7);
            user.AddFigure(dr7);
            user.MakeComposite(dc7, dr7);

            AShower shower = new WindowShower(100.0, 100.0);
            user.Show(shower);

            user.Undo(5);

            user.Show(shower);

            Console.ReadKey();
        }
    }
}

