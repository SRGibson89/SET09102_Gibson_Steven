using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    class SingletonSms
    {
        private static SingletonSms instance;
        public List<SMS> SMSList = new List<SMS>();

        private SingletonSms()
        {

        }

        public static SingletonSms Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonSms();
                }
                return instance;
            }
        }
    }
}
