using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    class SMS
    {
        private string messageID;
        private double phoneNumber;
        private string message;

        public string MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }
        public double PhoneNumber

        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
