using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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
    /// Interaction logic for ReadMessages.xaml
    /// </summary>
    public partial class ReadMessages : Window
    {
        SingletonTweets Tweet_List = SingletonTweets.Instance;
        SingletonEmail Email_List = SingletonEmail.Instance;
        SingletonSms Sms_List = SingletonSms.Instance;
        SingletonSIR SIR_List = SingletonSIR.Instance;
        SingletonMentions Mention_List = SingletonMentions.Instance;
        SingletonTag Tag_List = SingletonTag.Instance;

        public ReadMessages()
        {
            InitializeComponent();
            LoadMessages();
           
        }

       

        private void LoadMessages()
        {
            LoadTweets();
            LoadEmail();
            LoadSms();
            
        }
        

        private void LoadSms()
        {
            string FileLoc = @"Resources\messages\sms.json";
            string json = File.ReadAllText(FileLoc);
           Sms_List.SMSList = JsonConvert.DeserializeObject<List<SMS>>(json);
        }

        private void LoadEmail()
        {
            string FileLoc = @"Resources\messages\emails.json";
            string json = File.ReadAllText(FileLoc);
            Email_List.EmailList = JsonConvert.DeserializeObject<List<Email>>(json);
        }

        private void LoadTweets()
        {
            string FileLoc = @"Resources\messages\tweets.json";
            string json = File.ReadAllText(FileLoc);
            Tweet_List.TweetsList = JsonConvert.DeserializeObject<List<Tweet>>(json);
        }
        
        //show Tweets in box;
        private void cmbTweets_DropDownOpened(object sender, EventArgs e)
        {
            cmbEmail.Items.Clear();
            cmbSMS.Items.Clear();
            cmbTweets.Items.Clear();
            if (Tweet_List.TweetsList.Count() != 0)
            {
                foreach (Tweet T in Tweet_List.TweetsList)
                {
                    cmbTweets.Items.Add(T.MessageID);
                }
            }
            else
            {
                cmbTweets.Items.Add("There are no Tweets");
            }
        }
        private void cmbTweets_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            lstShow.Items.Clear();
            foreach (Tweet T in Tweet_List.TweetsList)
            {
                if (cmbTweets.Text == T.MessageID)
                {
                    lstShow.Items.Add("Message ID: " + T.MessageID +
                                        "\nTwitter Account: " + T.Handle +
                                        "\nTweet: " + T.Message);
                }

            }
        }
       
        private void cmbEmail_DropDownOpened(object sender, EventArgs e)
        {
            cmbTweets.Items.Clear();
            cmbSMS.Items.Clear();
            cmbEmail.Items.Clear();
            if (Email_List.EmailList.Count() !=0)
            {
                foreach(Email E in Email_List.EmailList)
                {
                    cmbEmail.Items.Add(E.MessageID);
                }
            }
            else
            {
                cmbEmail.Items.Add("There are no Emails");
            }
        }

        private void cbmSMS_DropDownOpened(object sender, EventArgs e)
        {
            cmbTweets.Items.Clear();
            cmbEmail.Items.Clear();
            cmbSMS.Items.Clear();
            if (Sms_List.SMSList.Count() !=0)
            {
                foreach(SMS S in Sms_List.SMSList)
                {
                    cmbSMS.Items.Add(S.MessageID);
                }
            }
            else
            {
                cmbSMS.Items.Add("There are no SMS");
            }
        }

        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTweets.Text != "")
            {
                lstShow.Items.Clear();
                foreach (Tweet T in Tweet_List.TweetsList)
                {
                    if (cmbTweets.Text == T.MessageID)
                    {
                        lstShow.Items.Add("Message ID: " + T.MessageID +
                                            "\nTwitter Account: " + T.Handle +
                                            "\nTweet: " + T.Message);
                    }

                }
            }
            else if(cmbEmail.Text !="")
            {
                lstShow.Items.Clear();
                foreach(Email E in Email_List.EmailList)
                {
                    if (cmbEmail.Text == E.MessageID)
                    {
                        lstShow.Items.Add("Message ID: " + E.MessageID +
                                            "\nEmail Address: " +E.Sender +
                                            "\nSubject: " + E.Subject +
                                            "\nMessage: "+ E.Message);
                    }
                }
            }
            else if (cmbSMS.Text != "")
            {
                lstShow.Items.Clear();
                foreach (SMS S in Sms_List.SMSList)
                {
                    if (cmbSMS.Text == S.MessageID)
                    {
                        lstShow.Items.Add("Message ID: " + S.MessageID +
                                            "\nPhone Number: " + S.PhoneNumber +
                                            "\nMessage: " + S.Message);
                    }
                }
            }
            else
            {
                lstShow.Items.Clear();
                lstShow.Items.Add("Please Select message to view");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWin = new MainWindow();
            newWin.Show();
            this.Close();
        }

        private void btntrending_Click(object sender, RoutedEventArgs e)
        {
            lstShow.Items.Clear();

            lstShow.Items.Add("**Hastags**");
            
            foreach (Hashtag H in Tag_List.HashtagList)
            {
                lstShow.Items.Add("Hashtag: " + H.Tag +
                                 "\nTrending: " + H.Trending+
                                 "\n-------------------------------");
            }

            lstShow.Items.Add("\n**Mentions**");

            foreach (Mentions M in Mention_List.MentionList)
            {
                lstShow.Items.Add("Mentions: " + M.Handle +
                                 "\nTrending: " + M.Trending +
                                 "\n-------------------------------");
            }
        }

        private void btnSirs_Click(object sender, RoutedEventArgs e)
        {
            lstShow.Items.Clear();
            lstShow.Items.Add("Serious Incidents Report");
            foreach (SIR S in SIR_List.SIRList)
            {
                lstShow.Items.Add("Incident: " + S.Incident+
                                 "\nHas Occurred: " + S.Occurances +
                                 "\n-------------------------------");
            }
        }
    }
}
