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
    /// Interaction logic for SMSGUI.xaml
    /// </summary>
    public partial class SMSGUI : Window
    {
        private string[] AbbrevArray = new string[] { };
        private string[] PhraseArray = new string[] { };
        private string Sms;
        private double SenderNumber;


        public SMSGUI(string MessageID)
        {
            InitializeComponent();
            txtSender.MaxLength = 15;
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
            FacadeSMS fac_Sms = new FacadeSMS(lblMessageID.Content.ToString(),SenderNumber, Sms);
            //Console.WriteLine(AbbrevArray.Count());
            //Console.WriteLine(PhraseArray.Count());
            Console.WriteLine("Sender: +" + SenderNumber);
            Console.WriteLine("Message Reads: " + Sms);
            CloseWindow();
        }

        private void txtSpeakCheck()
        {
            
            string text = " "+ txtMessage.Text + " ";
            
            int total = AbbrevArray.Count();
            for (int i = 0; i < total; i++)
            {
                string str = " "+ AbbrevArray[i]+" ";
                Console.WriteLine(str);
                //Console.WriteLine("-----------");

                if (text.Contains(str))
                {

                    string Cleaned = Regex.Replace(text, str, str + " <"+PhraseArray[i]+"> ");
                    text = Cleaned;

                }
                
            }
            Sms = text;
        }

        private void txtSender_LostFocus(object sender, RoutedEventArgs e)
        {
            string Sender = txtSender.Text;
            if (Sender.StartsWith("0"))
            {
                int lastnumber = Sender.Length - 1;
                Sender = "44" + Sender.Substring(1, lastnumber);
            }


            try
            {
                SenderNumber = double.Parse(Sender);
                btnSend.IsEnabled = true;

            }
            catch (Exception)
            {
                Console.WriteLine("Sender must be a phone Number");
                btnSend.IsEnabled = false;
            }


        }
        private void CloseWindow()
        {
            InputWindow newWin = new InputWindow();
            newWin.Show();
            this.Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
