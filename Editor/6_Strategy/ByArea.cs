using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class ByArea : IStrategy
    {
        public void Sort(ref List<IFigure> arr)
        {
            for (int i=0; i<arr.Count-1; i++)
                for (int j = 0; j< arr.Count - 1  - i; j++)
                    if (arr[j].Area() < arr[j+1].Area())
                    {
                        IFigure tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
            //arr.OrderBy(x => x.Area());
        }
    }
}
