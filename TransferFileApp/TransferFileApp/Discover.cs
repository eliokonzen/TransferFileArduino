using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferFileApp
{
    public class Discover
    {
        private static Discover instance;
        public static Discover GetInstance()
        {
            if (instance == null)
                instance = new Discover();
            return instance;
        }

    }
}
