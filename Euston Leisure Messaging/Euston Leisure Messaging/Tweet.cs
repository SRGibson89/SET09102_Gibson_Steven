using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    class Tweet
    {
        private string messageID;
        private string handle;
        private string message;

        public string MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }
        public string Handle
        {
            get { return handle; }
            set { handle = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
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
