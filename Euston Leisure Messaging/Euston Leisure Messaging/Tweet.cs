using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    public class Tweet
    {
        private string messageID;
        private string handle;
        private string message;

        public string MessageID
        {
            get { return messageID; }
            set
            {
                if (value.StartsWith("T"))
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
                    throw new ArgumentException("MessageID must start with a 'T'");
                }
            }
        }
        public string Handle
        {
            get { return handle; }
            set
            {
                if (value.Length >=2&&value.Length<=15)
                {
                    if (value.StartsWith("@"))
                    {
                        handle = value;
                    }
                    else
                    {
                        throw new ArgumentException("Twitter handle's must start with an '@'");
                    }

                }
                else
                {
                    throw new ArgumentOutOfRangeException("Twitter handle's must between 2 and 15 characters long");
                }

            }
        }
        
        public string Message
        {
            get { return message; }
            set
            {
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

        public Tweet()
        {

        }
        public Tweet (string MID ,string h,string m)
        {
            MessageID = MID;
            Handle = h;
            Message = m;
        }
    }
}
