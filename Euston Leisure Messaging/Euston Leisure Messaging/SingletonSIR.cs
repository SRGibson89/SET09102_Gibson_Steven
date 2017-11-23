using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
   
    class SingletonSIR
    {
        private static SingletonSIR instance;
        public List<SIR> SIRList = new List<SIR>();

        private SingletonSIR()
        {

        }

        public static SingletonSIR Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonSIR();
                }
                return instance;
            }
        }

        
    }
}

