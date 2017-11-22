using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    public class Email
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
            
            set
            {
                if (value.StartsWith("E"))
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
                    throw new ArgumentException("MessageID must start with an 'E'");
                }
            }
        }
        public string Sender
        {
            get { return sender; }
            set
            {
                if (value.Contains("@") && !value.StartsWith("@"))
                {
                    
                    if (value.EndsWith(".co.uk") || value.EndsWith(".com")|| value.EndsWith(".org")|| value.EndsWith(".ac.uk")|| value.EndsWith(".uk"))
                    {
                        sender = value;
                    }
                    else
                    {
                        throw new ArgumentException("Sender must end with with either '.com','.co.uk', '.org', '.ac.uk'");
                    }
                }
                else
                {
                    throw new ArgumentException("Sender must have an '@' in it");
                }
                
            }
        }
        public string Subject
        {
            get { return subject; }
            set
            {
                if (value != "")
                {
                    subject = value;
                }
                else if (value.ToUpper().Contains("SIR"))
                {
                    if (centerCode == "" || incident == "")
                    {
                        throw new ArgumentException("SIR reports require Incident and Center Code");
                    }
                    else
                    {
                        subject = value;
                    }
                }

                else
                {
                    throw new ArgumentException("Email Subject required");
                }
            }
        }
        public string Incident
        {
            get { return incident; }
            set
            {
                if (subject.ToUpper().Contains("SIR"))
                {
                    if (value !="")
                    {
                        incident = value;
                    }
                    else
                    {
                        throw new ArgumentException("SIR reports require an Incident");
                    }
                }
                else if (!subject.ToUpper().Contains("SIR") && value == "N/A")
                {
                    incident = value;
                }
                else if (!subject.ToUpper().Contains("SIR") && value !="N/A")
                {
                    throw new ArgumentException("an Incident cannont be added without SIR in subject");
                }
                
            }
        }
        public string CenterCode
        {
            get { return centerCode; }
            set
            {
                if (subject.ToUpper().Contains("SIR"))
                {
                    if (value.Substring(2, 1) == "-" && value.Substring(6, 1) == "-")
                    {
                        centerCode = value;
                    }
                    else
                    {
                        throw new ArgumentException("Center format incorrect, correct example: 12-123-12");
                    }
                }
                else if (!subject.ToUpper().Contains("SIR") && value == "N/A")
                {
                    centerCode = value;
                }
                else if (!subject.ToUpper().Contains("SIR") && value != "N/A")
                {
                    throw new ArgumentException("an Center Code cannont be added without SIR in subject");
                }

            }
        }
        public string Message
        {
            get { return message; }
            set
            {
                if (value.Length >= 1 && value.Length <= 1028)
                {
                    message = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Message must be between 1 and 1028 characters long");
                }
            }
        }
        public Email()
        {

        }
    }

}
