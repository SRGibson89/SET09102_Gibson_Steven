﻿using System;
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
    /// Interaction logic for TweetGUI.xaml
    /// </summary>
    public partial class TweetGUI : Window
    {
        public TweetGUI(string MessageID)
        {
            InitializeComponent();
            txtMessage.MaxLength = 144;
            lblMessageID.Content = MessageID;
        }
    }
}
