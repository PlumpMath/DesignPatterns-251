using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    interface IKit
    {
        List<IFigure> get();
        void Add(IFigure f);

        IFigure Get(int ind);
        IFigure CreateClone(IFigure f);
    }
}
