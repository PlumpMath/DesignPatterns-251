using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public abstract class Singleton<T> //: IKit
    {
        private static readonly object instanceLock = new object();
        private static T instance; // Derived class instance

        // Protected constructor accessible from derived class
        protected Singleton()
        {
        }

        // Returns the singleton instance of the derived class
        public static T GetInstance()
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = (T)Activator.CreateInstance(typeof(T), true);
                }
                return instance;
            }
        }

        // IKit
    }
}
