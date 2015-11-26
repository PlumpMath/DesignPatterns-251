using System;

namespace Editor
{
    public abstract class Singleton<T>
    {
        private static readonly object instanceLock = new object();
        private static T instance;
        
        protected Singleton()
        {
        }
        
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
    }
}
