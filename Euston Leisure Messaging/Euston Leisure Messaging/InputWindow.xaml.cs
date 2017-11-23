using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public InputWindow()
        {
            InitializeComponent();
            txtID.CharacterCasing = CharacterCasing.Upper;
            txtID.MaxLength = 10;
        }

        

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
           
            
            string ID = txtID.Text.ToString();
            
            if (ID.Length < 10)
            {
                Console.WriteLine("Message Id Not long enough, ID must Be 10 characters Long");
                
            }
            else
            {
                try
                {
                    string IDNumber = ID.Substring(1, 9);
                    Console.WriteLine(IDNumber);
                    int Number = int.Parse(IDNumber);
                }
                catch (Exception)
                {

                    Console.WriteLine("Error! Message ID must contain 9 Numbers after 1st letter");
                }
               
                if (ID.StartsWith("E"))
                {
                    EmailGUI newEmail =  new EmailGUI(ID);
                    newEmail.Show();
                    this.Close();
                    Console.WriteLine(ID);
                    Console.WriteLine("Welcome User"
                                       +"\nEnter the email you wish to send");
                }
                else if (ID.StartsWith("S"))
                {
                    SMSGUI NewSMS = new SMSGUI(ID);
                    NewSMS.Show();
                    this.Close();
                    Console.WriteLine(ID);
                    Console.WriteLine("Welcome User"
                                      + "\nEnter the SMS Message you wish to send");
                }
                else if (ID.StartsWith("T"))
                {
                    TweetGUI newTweet = new TweetGUI(ID);
                    newTweet.Show();
                    this.Close();
                    Console.WriteLine(ID);
                    Console.WriteLine("Welcome User"
                                      + "\nEnter the Tweet you wish to send");
                }
                else
                {
                    Console.WriteLine("Invaid message ID");
                    
                }
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWin = new MainWindow();
            newWin.Show();
            this.Close();

        }
    }
}
