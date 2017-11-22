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
using System.IO;

namespace Euston_Leisure_Messaging
{
    /// <summary>
    /// Interaction logic for EmailGUI.xaml
    /// </summary>
    public partial class EmailGUI : Window
    {
        private bool valid_email = false;
        private bool Incident = false, PreviousIncident = false;
        private string Email, Sender, Subject, CenterID;
        SingletonSIR SIR_List = SingletonSIR.Instance;


        public EmailGUI(string MessageID)
        {
            InitializeComponent();
            lblMessageID.Content = MessageID;
            //sets Maximum legnth of text boxes
            txtMessage.MaxLength = 1028;
            txtSubject.MaxLength = 20;
            txtcenter1.MaxLength = 2;
            txtcenter2.MaxLength = 3;
            txtcenter3.MaxLength = 2;
            
        }

        
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Email = txtMessage.Text.ToString();
            Sender = txtSender.Text.ToString();
            Subject = txtSubject.Text.ToString();
            UrlCheck();
            if (Incident == false)
            {
                string NatureofIncidnet = "N/A";
                string CenterID = "N/A";
                Console.WriteLine("Message ID: " + lblMessageID.Content.ToString() +
                                  "\nSender: " + txtSender.Text +
                                  "\nSubject: " + txtSubject.Text +
                                  "\nCeneter Code: " + CenterID +
                                  "\nNature of Incident: " + NatureofIncidnet +
                                  "\nMessage Reads: " + Email);
                FacadeEmail fac_email = new FacadeEmail(lblMessageID.Content.ToString(),
                                                        txtSender.Text,
                                                        Subject,
                                                        NatureofIncidnet,
                                                        CenterID,
                                                        Email);

            }
            else if (Incident == true)
            {
                string NatureofIncidnet = cmbIncident.Text;
                Email = "Center Code: " + CenterID + " "
                        + lblIncident.Content + " "
                        + NatureofIncidnet
                        + "\n" + Email;
                FacadeEmail fac_email = new FacadeEmail(lblMessageID.Content.ToString(),
                                                        txtSender.Text,
                                                        Subject,
                                                        NatureofIncidnet,
                                                        CenterID,
                                                        Email);
                Console.WriteLine("Message ID: " + lblMessageID.Content.ToString() +
                                  "\nSender: " + txtSender.Text +
                                  "\nSubject: " + txtSubject.Text +
                                  "\nCeneter Code: " + CenterID +
                                  "\nNature of Incident: " + NatureofIncidnet +
                                  "\nMessage Reads: " + Email);
                SIRUpdate();
            }
            CloseThisWindow();
           
        }

        private void SIRUpdate()
        {
            string inciddent = cmbIncident.Text;
            try
            {
                foreach (SIR H in SIR_List.SIRList)
                {

                    if (inciddent == H.Incident)
                    {

                        H.Occurances = H.Occurances + 1;
                        Console.WriteLine("Incident = " + H.Incident
                                            + " Has Happened " + H.Occurances
                                            + " time(s)");

                        PreviousIncident = true;
                        break;

                    }


                }//for loop ends

                if (PreviousIncident == false)
                {
                    SIR NewS = new SIR(inciddent, "1");
                    SIR_List.SIRList.Add(NewS);
                    Console.WriteLine("This is the 1st Time " + inciddent
                                        + " has occurred ");
                                        
                }
                PreviousIncident = false;
            }//try ends
            catch (Exception)
            {

                Console.WriteLine("error");
            }
            
            WriteSIR();
                }
            
            


        private void WriteSIR()
        {
                string filename = @"Resources\sir.csv"; //filename where data will be stored
                StreamWriter writer = new StreamWriter(filename,false);
                foreach (SIR S in SIR_List.SIRList)
                {
                    writer.WriteLine("{0},{1}", S.Incident, S.Occurances.ToString()); //adds each object to the file as a line of text

                }//foreach ends
                writer.Close(); //closes the file
                Console.WriteLine("All data saved to " + filename);
        }
        

        private void txtSubject_LostFocus(object sender, RoutedEventArgs e)
        {
            string subject = txtSubject.Text.ToString().ToUpper();

            //Subject Vaildation
            if (subject.Length >= 1)
            {
                valid_email = true;
            }
            else
            {
                valid_email = false;
                Console.WriteLine("Subject Required");
            }
            if (subject.Contains("SIR"))
            {
                Incident = true;
                lblIncident.Visibility = Visibility.Visible;
                cmbIncident.Visibility = Visibility.Visible;
                lblCeneter.Visibility = Visibility.Visible;
                txtcenter1.Visibility = Visibility.Visible;
                lbldash.Visibility = Visibility.Visible;
                txtcenter2.Visibility = Visibility.Visible;
                txtcenter3.Visibility = Visibility.Visible;
            }
            else
            {
                Incident = false;
                lblIncident.Visibility = Visibility.Hidden;
                cmbIncident.Visibility = Visibility.Hidden;
                lblCeneter.Visibility = Visibility.Hidden;
                txtcenter1.Visibility = Visibility.Hidden;
                lbldash.Visibility = Visibility.Hidden;
                txtcenter2.Visibility = Visibility.Hidden;
                txtcenter3.Visibility = Visibility.Hidden;
            }
            emailValidation();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseThisWindow();
        }

        private void txtSender_LostFocus(object sender, RoutedEventArgs e)
        {
            Sender = txtSender.Text.ToString();
            Subject = txtSubject.Text.ToString();
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
                if (Subject.Length >= 1)
                {
                    valid_email = true;
                }
                else
                {
                    valid_email = false;
                    Console.WriteLine("Subject Required");
                }

                emailValidation();
            }
        }

        private void emailValidation()
        {
            if (valid_email == true)
            {
                if (Incident == false)
                {

                   
                    btnSend.IsEnabled = true;
                    valid_email = false;
                }
                if (Incident == true)
                {

                    //string NatureofIncidnet = cmbIncident.Text.ToString();
                    //Email = "Center Code: "+ CenterID + " "+ lblIncident.Content + " " + NatureofIncidnet + "\n" + Email;

                    btnSend.IsEnabled = true;
                    valid_email = false;
                }
            }
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

        private void txtcenter3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Incident == true)
            {
                try
                {
                    int one = int.Parse(txtcenter1.Text);
                    int two = int.Parse(txtcenter2.Text);
                    int three = int.Parse(txtcenter3.Text);
                    CenterID = one + "-" + two + "-" + three;
                    Console.WriteLine("CenterID number :" + CenterID);

                }
                catch (Exception E)
                {
                    Console.WriteLine(E);
                    valid_email = false;
                }
            }
        }

      //end of class  
    }
    //end of namespace
}
