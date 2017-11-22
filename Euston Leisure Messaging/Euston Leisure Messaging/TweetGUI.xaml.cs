using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Web.Script.Serialization;


namespace Euston_Leisure_Messaging
{
    /// <summary>
    /// Interaction logic for TweetGUI.xaml
    /// </summary>
    public partial class TweetGUI : Window
    {
        
        SingletonMentions Mention_List = SingletonMentions.Instance;
        SingletonTag Tag_List = SingletonTag.Instance;
        private string[] AbbrevArray = new string[] { };
        private string[] PhraseArray = new string[] { };
        //public List<string> Hashtag = new List<string>();
        //public List<string> Trend = new List<string>();
        private string Tweet,SenderTag;
        private bool hashtagexists = false;

        public TweetGUI(string MessageID)
        {
            InitializeComponent();
            txtMessage.MaxLength = 144;
            lblMessageID.Content = MessageID;
            LoadTxtSpeak();
           

        }
        //Load Textspeak.csv
        private void LoadTxtSpeak()
        {
            try
            {
                List<string> Abbreviations = new List<string>();
                List<string> Phrases = new List<string>();
                string filename = @"Resources/textwords.csv";
                StreamReader reader = new StreamReader(File.OpenRead(filename));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    Abbreviations.Add(values[0]);
                    Phrases.Add(values[1]);

                }
                Console.WriteLine("\nAbbreviations List Count: " + Abbreviations.Count() + "\nPhrases List Count: " + Phrases.Count());

                Console.WriteLine(Phrases.ToString());
                AbbrevArray = Abbreviations.ToArray();
                PhraseArray = Phrases.ToArray();

            }

            catch (Exception e)
            {

                Console.WriteLine("Error: " + e);
            }

        }
        //Load Hashtag.csv
        

       

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            
            txtSpeakCheck();
            HashtagTrending();
            MentionTrending();
            WriteHashtags();
            WriteMentions();
            FacadeTweet fac_tweet = new FacadeTweet(lblMessageID.Content.ToString(),txtSender.Text,Tweet);

            //Console.WriteLine(AbbrevArray.Count());
            //Console.WriteLine(PhraseArray.Count());

            Console.WriteLine("Message Reads: " + Tweet);
            CloseWindow();
        }



        private void txtSpeakCheck()
        {
            
            string text = " " + txtMessage.Text + " ";

            int total = AbbrevArray.Count();
            for (int i = 0; i < total; i++)
            {
                string str = " " + AbbrevArray[i] + " ";
                Console.WriteLine(str);
                //Console.WriteLine("-----------");

                if (text.Contains(str))
                {
                    string filename = @"Resources/textwords.csv";
                    StreamReader reader = new StreamReader(File.OpenRead(filename));
                    string Cleaned = Regex.Replace(text, str, str + " <" + PhraseArray[i] + "> ");
                    text = Cleaned;

                }
                else if (text.Contains(str.ToLower())&& str.ToLower() != "at")
                {
                    string filename = @"Resources/textwords.csv";
                    StreamReader reader = new StreamReader(File.OpenRead(filename));
                    string Cleaned = Regex.Replace(text, str.ToLower(), str.ToLower() + " <" + PhraseArray[i] + "> ");
                    text = Cleaned;

                }


            }
            Tweet = text;
        }

        //Count hashtag trending
        private void HashtagTrending()
        {
            
            string text = " " + txtMessage.Text + " ";
            var regex = new Regex(@"(?<=#)\w+");
            var matches = regex.Matches(text);

            foreach (Match m in matches)
            {
                string Htag = "#" + m.Value;
               // Console.WriteLine(Htag);
                try
                { 
                foreach (Hashtag H in Tag_List.HashtagList)
                {
                                        
                    if (Htag == H.Tag)
                    {

                        H.Trending = H.Trending + 1;
                        Console.WriteLine("Hashtag = " + H.Tag
                                         + " is trending " + H.Trending
                                         + " retweet(s)");

                        hashtagexists = true;
                        break;

                    }


                }//for loop ends

                if (hashtagexists == false)
                {
                    Hashtag NewH = new Hashtag(Htag, "1");
                    Tag_List.HashtagList.Add(NewH);
                    Console.WriteLine("Hashtag = " + Htag
                                        + " is trending "
                                        + "1 retweet(s)");
                }
                hashtagexists = false;
            }//try ends
                        catch (Exception)
            {

                Console.WriteLine("error");
            }
            //Console.WriteLine(m.Value);
            }
         
        }

        private void WriteHashtags()
        {
            string filename = @"Resources\hashtags.csv"; //filename where data will be stored
            StreamWriter writer = new StreamWriter(filename,false);
            foreach (Hashtag H in Tag_List.HashtagList)
            {
                writer.WriteLine("{0},{1}", H.Tag,H.Trending.ToString()); //adds each object to the file as a line of text

            }//foreach ends
            writer.Close(); //closes the file
            Console.WriteLine("All data saved to " + filename);
        }

        private void MentionTrending()
        {
            bool Mentionexists = false;
            string text = " " + txtMessage.Text + " ";
            var regex = new Regex(@"(?<=@)\w+");
            var matches = regex.Matches(text);

            foreach (Match m in matches)
            {
                string handler = "@" + m.Value;
                // Console.WriteLine(Htag);
                try
                {
                    foreach (Mentions M in Mention_List.MentionList)
                    {

                        if (handler == M.Handle)
                        {

                            M.Trending = M.Trending + 1;
                            Console.WriteLine("User = " + M.Handle
                                             + " is trending " + M.Trending
                                             + " mention(s)");

                            Mentionexists = true;
                            break;

                        }


                    }//for loop ends

                    if (Mentionexists == false)
                    {
                        Mentions NewM = new Mentions(handler, "1");
                        Mention_List.MentionList.Add(NewM);
                        Console.WriteLine("User = " + handler
                                            + "first mention");
                    }
                    Mentionexists = false;
                }//try ends
                catch (Exception)
                {

                    Console.WriteLine("error");
                }
                //Console.WriteLine(m.Value);
            }
        }
        private void WriteMentions()
        {
            string filename = @"Resources\mentions.csv"; //filename where data will be stored
            StreamWriter writer = new StreamWriter(filename,false);
            foreach (Mentions M in Mention_List.MentionList)
            {
                writer.WriteLine("{0},{1}", M.Handle, M.Trending.ToString()); //adds each object to the file as a line of text

            }//foreach ends
            writer.Close(); //closes the file
            Console.WriteLine("All data saved to " + filename);
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
             InputWindow newWin = new InputWindow();
            newWin.Show();
            this.Close();
        }

        private void txtSender_LostFocus(object sender, RoutedEventArgs e)
        {
            string Sender = txtSender.Text;
            if (Sender.StartsWith("@"))
            {
                SenderTag = Sender;
                btnSend.IsEnabled = true;
            }
            else
            {
                Console.WriteLine("Twitter Handles must start with '@'");
                btnSend.IsEnabled = false;
            }
           
        }
        //private void writetoJson()
        //{
        //    string filename = @"Resources\messages\tweets.json"; //filename where data will be stored
            
        //    foreach (Mentions M in Mention_List.MentionList)
        //    {
                
        //        string json = new JavaScriptSerializer().Serialize(M);
        //        File.WriteAllText(filename, json);
        //    }//foreach ends
            
        //    Console.WriteLine("All data saved to " + filename);


        //}


        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        
    }
}
