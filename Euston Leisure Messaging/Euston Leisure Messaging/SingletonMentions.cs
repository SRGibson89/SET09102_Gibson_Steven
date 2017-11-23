using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    class SingletonMentions
    {
        private static SingletonMentions instance;
        public List<Mentions> MentionList = new List<Mentions>();

        private SingletonMentions()
        {

        }

        public static SingletonMentions Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonMentions();
                }
                return instance;
            }
        }

        internal Mentions Mentions
        {
            get => default(Mentions);
            set
            {
            }
        }
    }
}


