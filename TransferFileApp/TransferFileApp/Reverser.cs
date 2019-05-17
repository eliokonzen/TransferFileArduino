using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferFileApp
{
    public class Reverser
    {
        private static Reverser instance;
        public static Reverser GetInstance()
        {
            if (instance == null)
                instance = new Reverser();
            return instance;
        }
    }
}
