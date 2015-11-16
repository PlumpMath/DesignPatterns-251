using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    interface IKit
    {
        int  Regisry(IFigure f);
        IFigure Create(int key);
    }
}
