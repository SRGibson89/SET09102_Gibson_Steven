using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    class SingletonTweets
    {
        private static SingletonTweets instance;
        public List<Tweet> TweetsList = new List<Tweet>();

        private SingletonTweets()
        {

        }

        public static SingletonTweets Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonTweets();
                }
                return instance;
            }
        }

        public Tweet Tweet
        {
            get => default(Tweet);
            set
            {
            }
        }
    }
}
