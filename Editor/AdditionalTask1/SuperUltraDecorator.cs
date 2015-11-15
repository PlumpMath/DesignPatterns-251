using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class SuperUltraDecorator : ADecorator
    {
        public SuperUltraDecorator(IFigure figureToDecorate) : base(figureToDecorate) { }

        public override void Show(int lvl = 0)
        {
            Shower.DrawText(new String(' ', lvl * 2) + "SuperUltraDecorator {" + Environment.NewLine);
            
            // Меняем Shower для фигур
            if (Shower is WindowShower)
            {
                IFigure originFigure = GetDecoratedFigure();
                WindowShower cur = (WindowShower)Shower;
                AShower sh = new SuperUltraShower(cur.GetForm(), cur.transparency, cur.scale);
                originFigure.SetShower(sh);
            }

            // Рисуем всё
            base.Show(lvl);

            Shower.DrawText(new String(' ', lvl * 2) + "}" + Environment.NewLine);
        }

        private IFigure GetDecoratedFigure()
        {
            IFigure f = decoratedFigure;

            while (f is ADecorator)
                f = ((ADecorator)f).RemoveLastDecorator();

            return f;
        }
    }
}
