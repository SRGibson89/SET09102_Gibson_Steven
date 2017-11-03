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
        public string Tweet,SenderTag;
        
        public TweetGUI(string MessageID)
        {
            InitializeComponent();
            txtMessage.MaxLength = 144;
            lblMessageID.Content = MessageID;
            LoadTxtSpeak();
        }
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

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            txtSpeakCheck();
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

                    string Cleaned = Regex.Replace(text, str, str + " <" + PhraseArray[i] + "> ");
                    text = Cleaned;

                }

            }
            Tweet = text;
        }
    }
}
