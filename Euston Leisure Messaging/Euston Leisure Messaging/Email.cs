using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    class Email
    {
        private string messageID;
        private string sender;
        private string subject;
        private string incident;
        private string centerCode;
        private string message;
                
        public string MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public string Incident
        {
            get { return incident; }
            set { incident = value; }
        }
        public string CenterCode
        {
            get { return centerCode; }
            set { centerCode = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }

}
