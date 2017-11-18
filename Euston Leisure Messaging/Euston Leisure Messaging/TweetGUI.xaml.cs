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

namespace Euston_Leisure_Messaging
{
    /// <summary>
    /// Interaction logic for TweetGUI.xaml
    /// </summary>
    public partial class TweetGUI : Window
    {
        public string[] AbbrevArray = new string[] { };
        public string[] PhraseArray = new string[] { };
        public List<string> Hashtag = new List<string>();
        public List<string> Trend = new List<string>();
        public string Tweet,SenderTag;
        
        public TweetGUI(string MessageID)
        {
            InitializeComponent();
            txtMessage.MaxLength = 144;
            lblMessageID.Content = MessageID;
            LoadTxtSpeak();
            LoadHashtags();
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
        private void LoadHashtags()
        {
            try
            {
                List<string> Hashtags = new List<string>();
                List<string> Trending = new List<string>();
                string filename = @"Resources/hashtags.csv";
                StreamReader reader = new StreamReader(File.OpenRead(filename));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    Hashtags.Add(values[0]);
                    Trending.Add(values[1]);

                }
                Console.WriteLine("\nAbbreviations List Count: " + Hashtags.Count() + "\nPhrases List Count: " + Trending.Count());

                Console.WriteLine(Hashtags.ToString());
                Hashtag = Hashtags;
                Trend = Trending;

            }

            catch (Exception e)
            {

                Console.WriteLine("Error: " + e);
            }

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            
            txtSpeakCheck();
            HashtagTrending();
            Console.WriteLine(AbbrevArray.Count());
            Console.WriteLine(PhraseArray.Count());
            
            Console.WriteLine("Message Reads: " + Tweet);
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
                

            }
            Tweet = text;
        }

        //Count hashtag trending
        private void HashtagTrending()
        {
            LoadHashtags();
            string text = " " + txtMessage.Text + ",";

            if (text.Contains('#'))
            {
                for (int i = 0; i < Hashtag.Count(); i++)
                {
                    string str = Hashtag[i];
                    if (text.Contains(str)) 
                    {
                    
                    }
                }

            }

            //int total = text.Length;
            //for (int i = 0; i < total; i++)
            //{
            //    string str = Hashtag[i];
            //    string hashtag = Hashtag[i];
            //    string filename = @"hashtags.csv"; //filename where data will be stored
            //    StreamWriter writer = new StreamWriter(filename);
            //    if (text.Contains(str))
            //    {
            //        StreamReader reader = new StreamReader(File.OpenRead(filename));

            //        while (!reader.EndOfStream)
            //        {
            //            if (line.Split(',')[0].Equals(hashtag))
            //            {
            //                int counter = int.Parse(line.Split(',')[1].ToString());
            //                counter = counter++;
            //                writer.Write("{0},{1}", line.Split(',')[0], line.Split(',')[1]);

            //            }
            //        }
            //    }
            //    else if (text.Contains('#'))
            //    {
            //        string tag = getBetween(text, "#", ",");
            //        Hashtag.Add(tag);
            //        Trend.Add("1");

            //    }

            //    writer.Close();
            //}

        }
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
