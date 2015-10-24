using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class ShadowDecorator : ADecorator
    {
        public ShadowDecorator(IFigure f) : base(f) { }

        public override void Show(int lvl = 0)
        {
            figure.ShowShadow();
            figure.Show(lvl);
        }
    }
}
