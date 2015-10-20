using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor._4
{
    public interface IDecorator
    {
        void Show(int lvl);
        void SetDecoratorParams(DecoratorParams DPs);
    }
}
