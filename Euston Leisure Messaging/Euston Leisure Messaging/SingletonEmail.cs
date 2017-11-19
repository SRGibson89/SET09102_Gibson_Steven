using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    class SingletonEmail
    {
        private static SingletonEmail instance;
        public List<Email> EmailList = new List<Email>();

        private SingletonEmail()
        {

        }

        public static SingletonEmail Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonEmail();
                }
                return instance;
            }
        }
    }
}
