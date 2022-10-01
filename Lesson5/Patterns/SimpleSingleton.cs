using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class SimpleSingleton
    {
        private static SimpleSingleton _instance;

        SimpleSingleton() { }

        public int Counter { get; set; } = 1;

        public static SimpleSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SimpleSingleton();
                return _instance;
            }
        }

    }
}
