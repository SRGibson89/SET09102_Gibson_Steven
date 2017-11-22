using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    public class SMS
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
                    if (value.Length == 10)
                    {
                        messageID = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("MessageId mus be 10 characters long");
                    }
                }
                else
                {
                    throw new ArgumentException("MessageID must start with a 'S'");
                }
            }
        }
        public double PhoneNumber

        {
            get { return phoneNumber; }
            set 
            {
                string Pnum = value.ToString();
                if (Pnum.Length >= 10 && Pnum.Length <= 16)
                {
                    phoneNumber = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Phone Number is invalid");
                }
                
            }
        }

        public string Message
        {
            get { return message; }
            set {
                if (value.Length >= 1 && value.Length <= 144)
                {
                    message = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Message must be between 1 and 144 characters long");
                }
                
            }
        }

        public SMS()
        {
        }
    }
}
