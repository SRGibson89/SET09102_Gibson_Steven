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
using System.Text.RegularExpressions;

namespace Euston_Leisure_Messaging
{
    /// <summary>
    /// Interaction logic for EmailGUI.xaml
    /// </summary>
    public partial class EmailGUI : Window
    {
        private bool valid_email = false;
        private bool Incident = false;
        private string Email,Sender,Subject;
        

        public EmailGUI(string MessageID)
        {
            InitializeComponent();
            lblMessageID.Content = MessageID;
            //sets Maximum legnth of text boxes
            txtMessage.MaxLength = 1028;
            txtSubject.MaxLength = 20;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Email = txtMessage.Text.ToString();
            Sender = txtSender.Text.ToString();
            Subject = txtSubject.Text.ToString();
            UrlCheck();
            //Sender Validation
            Sender.ToLower();
            if (valid_email == false)
            {
                if (Sender.Contains('@'))
                {
                    if (Sender.Contains(".uk") || Sender.Contains(".com"))
                    {
                        valid_email = true;
                    }
                    else
                    {
                        valid_email = false;
                        Console.WriteLine("Sender is Invalid");
                    }
                }
                else
                {
                    valid_email = false;
                    Console.WriteLine("Sender is Invalid");
                }
                //Subject Vaildation
                if (Subject.Length >= 1)
                {
                    valid_email = true;
                }
                else
                {
                    valid_email = false;
                    Console.WriteLine("Subject Required");
                }
            }
            if (valid_email==true)
            {
                if (Incident == false)
                {
                    
                    Console.WriteLine("Message ID: " + lblMessageID.Content
                                      + "\nSender: " + Sender
                                      + "\nSubject: " + Subject
                                      + "\nMessage Reads: " + Email);
                    valid_email = false;
                }
                if (Incident == true)
                {
                    
                    string NatureofIncidnet = cmbIncident.Text.ToString();
                    Email = lblIncident.Content + " " +  NatureofIncidnet + "\n" + Email; 
                    Console.WriteLine("Message ID: " + lblMessageID.Content
                                      + "\nSender: " + Sender
                                      + "\nSubject: " + Subject
                                      + "\nMessage Reads: " + Email);
                    valid_email = false;
                }
                }
        }

        private void txtSubject_LostFocus(object sender, RoutedEventArgs e)
        {
            string subject = txtSubject.Text.ToString().ToUpper();
 
            if (subject.Contains("SIR"))
            {
                Incident = true;
                lblIncident.Visibility = Visibility.Visible;
                cmbIncident.Visibility = Visibility.Visible;
            }
            else
            {
                Incident = false;
                lblIncident.Visibility = Visibility.Hidden;
                cmbIncident.Visibility = Visibility.Hidden;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseThisWindow();
        }

        private void CloseThisWindow()
        {
            InputWindow newWin = new InputWindow();
            newWin.Show();
            this.Close();
        }
        private void UrlCheck()
        {
            string text = txtMessage.Text.ToLower();
            if (text.Contains("http://"))
            {
               
                    string Cleaned = Regex.Replace(text, @"http[^\s]+", "<URL>");
                    Email = Cleaned;
                
            }
            else
            {
                Email = text;
            }
            
        }

        
    }
}
