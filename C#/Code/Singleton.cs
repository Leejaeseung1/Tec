using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_.Code
{
    internal class Singleton<T> where T : class, new()
    {
        private static T? _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    object o = new object();
                    lock (o)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                        //_instance ??= new T(); //same null check
                    }
                }
                return _instance;
            }
        }
    }
}
