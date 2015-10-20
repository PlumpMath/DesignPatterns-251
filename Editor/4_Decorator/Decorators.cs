using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor._4
{
    public abstract class ADecorators : IDecorator
    {
        protected IDecorator figureToBeDecorated;

        public ADecorators(IDecorator figureToBeDecorated)
        {
            this.figureToBeDecorated = figureToBeDecorated;
        }

        public virtual void SetDecoratorParams(DecoratorParams DPs)
        {
            figureToBeDecorated.SetDecoratorParams(DPs);
        }
        public virtual void Show(int lvl)
        {
            figureToBeDecorated.Show(lvl);
        }
    }

    public class ShadowDecorator : ADecorators
    {
        public ShadowDecorator(IDecorator figureToBeDecorated) : base(figureToBeDecorated) { }

        public override void SetDecoratorParams(DecoratorParams DPs)
        {
            DPs.ChangeParams(1.0);

            figureToBeDecorated.SetDecoratorParams(DPs);
        }
        public override void Show(int lvl)
        {
            figureToBeDecorated.Show(lvl);
        }
    }
}
