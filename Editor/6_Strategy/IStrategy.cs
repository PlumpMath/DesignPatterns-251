using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public interface IStrategy
    {
        void Sort(ref List<IFigure> arr);
    }
}
