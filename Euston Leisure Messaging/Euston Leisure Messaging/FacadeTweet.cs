using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.ServiceModel.Web;
using Newtonsoft.Json.Linq;


/// Facade Design Pattern.
namespace Euston_Leisure_Messaging
{
    class FacadeTweet
    {
        SingletonTweets Tweet_List = SingletonTweets.Instance;

        public FacadeTweet(string M_ID,string h, string m)
        {
            LoadTweets();
            New_Tweet(M_ID,h,m);
            SaveTweet();
        }

        private void LoadTweets()
        {
            try
            {


                string FileLoc = @"Resources\messages\tweets.json";
                string json = File.ReadAllText(FileLoc);
                Tweet_List.TweetsList = JsonConvert.DeserializeObject<List<Tweet>>(json);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void New_Tweet(string M_ID,string h,string m)
        {
            try
            {
                //makes a new customer then adds them to the singalton list
                Tweet T = new Tweet();
                T.MessageID = M_ID;
                T.Handle = h;
                T.Message = m;
                Tweet_List.TweetsList.Add(T);
                Console.WriteLine("Saved " + M_ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SaveTweet()
        {
            string FileLoc = @"Resources\messages\tweets.json"; //filename where data will be stored
            File.WriteAllText(FileLoc, JsonConvert.SerializeObject(Tweet_List.TweetsList));
            Console.WriteLine("All data saved to " + FileLoc);
        }

    }
}
