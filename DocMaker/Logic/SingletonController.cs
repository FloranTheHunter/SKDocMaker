using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocMaker.Logic
{
    class SingletonController
    {
        private static SingletonController _instance;

        private SingletonController()
        { }

        public static SingletonController GetInstance()
        {
            if (_instance == null)
                _instance = new SingletonController();
            return _instance;
        }
    }
}
