using System;
using System.Collections.Generic;
using System.Linq;

namespace Editor
{
    class Registry : Singleton<Registry>, IKit
    {
        private Dictionary<int, IFigure> children;

        private Registry()
        {
            children = new Dictionary<int, IFigure>();
        }

        #region IKit
        public IFigure Create(int key)
        {
            if (!children.ContainsKey(key))
                throw new IndexOutOfRangeException("Registry.Create(" + key + ")");

            return children[key].Clone();
        }
        public int Register(IFigure f)
        {
            int key = (children.Keys.Count == 0) ? 0 : (children.Keys.Max() + 1);

            children.Add(key, f.Clone());

            return key;
        }
        #endregion
    }
}
