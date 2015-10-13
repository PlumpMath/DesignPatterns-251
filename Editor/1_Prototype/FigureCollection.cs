using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor._1_Prototype
{
    class FigureCollection
    {
        private List<PrototypeFigure> figures;

        public FigureCollection()
        {
            figures = new List<PrototypeFigure>();
        }

        public void Add(PrototypeFigure figure)
        {
            figures.Add(figure);
        }
        public PrototypeFigure Get(int index)
        {
            if (index < 0 || index > figures.Count)
                throw new IndexOutOfRangeException("FigureCollection: Get: Wrong ind");

            return figures[index];
        }
        public void Del(int index)
        {
            if (index < 0 || index > figures.Count)
                throw new IndexOutOfRangeException("FigureCollection: Del: Wrong ind");

            figures.RemoveAt(index);
        }
        public void Del(PrototypeFigure figure)
        {
            figures.Remove(figure);
        }
    }
}
