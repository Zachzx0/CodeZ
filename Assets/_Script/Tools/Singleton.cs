using System;

namespace CodeZ.Tools
{
    public class Singleton<T> where T : class, new()
    {
        static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Activator.CreateInstance(typeof(T)) as T;
                }
                return _instance;
            }
        }
    }
}