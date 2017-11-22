using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Euston_Leisure_Messaging
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SingletonMentions Mention_List = SingletonMentions.Instance;
        SingletonTag Tag_List = SingletonTag.Instance;
        SingletonSIR SIR_List = SingletonSIR.Instance;
        public MainWindow()
        {
            InitializeComponent();
            if (Mention_List.MentionList.Count()==0 && Tag_List.HashtagList.Count()==0 && SIR_List.SIRList.Count()==0)
            {
                LoadData();
            }
            
        }

        private void LoadData()
        {
            LoadHashatgs();
            LoadMentions();
            LoadSIRS();

        }

        private void LoadHashatgs()
        {
            string filename = @"Resources/hashtags.csv";
            StreamReader reader = new StreamReader(File.OpenRead(filename));
            if (reader.Peek() == 0) //checks to see if the file is empty
            {
                Console.WriteLine("File is empty");
            }
            else
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string line = reader.ReadLine();
                        var value = line.Split(',');
                        Hashtag H = new Hashtag(value[0], value[1]); //make a new hashtag object
                        Tag_List.HashtagList.Add(H);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e);
                    }
                }//end of while
                reader.Close();
            }//end of else
        }

        private void LoadMentions()
        {
            string filename = @"Resources/mentions.csv";
            StreamReader reader = new StreamReader(File.OpenRead(filename));
            if (reader.Peek() == 0) //checks to see if the file is empty
            {
                Console.WriteLine("File is empty");
            }
            else
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string line = reader.ReadLine();
                        var value = line.Split(',');
                        Mentions M = new Mentions(value[0], value[1]); //make a new hashtag object
                        Mention_List.MentionList.Add(M);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e);
                    }
                }//end of while
                reader.Close();
            }//end of else
        }

        private void LoadSIRS()
        {
            string filename = @"Resources/sir.csv";
            StreamReader reader = new StreamReader(File.OpenRead(filename));
            if (reader.Peek() == 0) //checks to see if the file is empty
            {
                Console.WriteLine("File is empty");
            }
            else
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string line = reader.ReadLine();
                        var value = line.Split(',');
                        SIR S = new SIR(value[0], value[1]); //make a new hashtag object
                        SIR_List.SIRList.Add(S);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e);
                    }
                }//end of while
                reader.Close();
            }
        }


        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            InputWindow newwin = new InputWindow();
            newwin.Show();
            this.Hide();

        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            ReadMessages newwin = new ReadMessages();
            newwin.Show();
            this.Hide();
        }

        
    }
}
