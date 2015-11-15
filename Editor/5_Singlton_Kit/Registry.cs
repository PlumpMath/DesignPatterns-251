using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class Registry : Singleton<Registry>, IKit
    {
        private List<IFigure> children;

        private Registry()
        {
            children = new List<IFigure>();
        }

        // IKit
        public void Add(IFigure f)
        {
            children.Add(f.Clone());
        }

        public IFigure CreateClone(IFigure f)
        {
            return f.Clone();
        }

        public List<IFigure> get()
        {
            return children;
        }

        public IFigure Get(int ind)
        {
            if (ind < 0 || ind >= children.Count)
                throw new ArgumentOutOfRangeException("Registry.Get(" + ind + "), but children.Count = " + children.Count);

            return children[ind];
        }
    }
}
