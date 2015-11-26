using System.Collections.Generic;

namespace Editor
{
    public interface IStrategy
    {
        void Sort(List<IFigure> arr);
    }
}
