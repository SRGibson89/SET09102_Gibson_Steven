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
            set 
            {
                if (value.StartsWith("S"))
                {
                    messageID = value;
                }
                else
                {
                    throw new ArgumentException("Phone Number is invalid");
                }
            }
        }
        public double PhoneNumber

        {
            get { return phoneNumber; }
            set 
            {
                string Pnum = value.ToString();
                if (Pnum.Length <= 11 && Pnum.Length >= 15)
                {
                    phoneNumber = value; 
                }
                else
                {
                    throw new ArgumentException("Phone Number is invalid");
                }
                
            }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
