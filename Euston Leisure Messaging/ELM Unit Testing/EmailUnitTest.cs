using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Euston_Leisure_Messaging;

namespace ELM_Unit_Testing
{
    /// <summary>
    /*
    * Author: Steven Gibson
    * Matriculation Number: 40270320
    * Class name: EmailUnitTest
    * Description: This unit test will test error checking that is part of the Email class
    * Date Last Modified: 21/11/2017
    * Unit testing for Email Class

    */
    /// </summary>
    [TestClass]
    public class EmailUnitTest
    {
        [TestMethod]
        public void Create_Email_with_valid_data()
        {
            //arrange
            Email Test_Email = new Email();
            string messageID = "E123456789";
            string sender = "steven@fake-email.com";
            string subject = "testing";
            string message = "Hello World";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;

            Assert.AreEqual(messageID, actualMessageID, "Email Created successfully");
            Assert.AreEqual(sender, actualSender, "Email Created successfully");
            Assert.AreEqual(subject, actualSubject, "Email Created successfully");
            Assert.AreEqual(message, actualMessage, "Email Created successfully");


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Email_with_invalid_Message_ID_data()
        {
            //arrange
            Email Test_Email = new Email();
            string messageID = "S123456789";
            string sender = "steven@fake-email.com";
            string subject = "testing";
            string message = "Hello World";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;

            Assert.AreEqual(messageID, actualMessageID, "Email Created Unsuccessfully");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Email_with_invalid_Message_ID_data_part2()
        {
            //arrange
            Email Test_Email = new Email();
            string messageID = "E12345678";
            string sender = "steven@fake-email.com";
            string subject = "testing";
            string message = "Hello World";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;

            Assert.AreEqual(messageID, actualMessageID, "Email Created Unsuccessfully");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Email_with_invalid_Sender_data_Part1()
        {
            //arrange
            Email Test_Email = new Email();
            string messageID = "E123456789";
            string sender = "stevenfake-email.com";
            string subject = "testing";
            string message = "Hello World";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;

            Assert.AreEqual(sender, actualSender, "Email Created Unsuccessfully");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Email_with_invalid_Sender_data_Part2()
        {
            //arrange
            Email Test_Email = new Email();
            string messageID = "E123456789";
            string sender = "steven@fake-email.fake";
            string subject = "testing";
            string message = "Hello World";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;

            Assert.AreEqual(sender, actualSender, "Email Created Unsuccessfully");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Email_with_invalid_Subject_data()
        {
            //arrange
            Email Test_Email = new Email();
            string messageID = "E123456789";
            string sender = "steven@fake-email.com";
            string subject = "";
            string message = "Hello World";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;

            Assert.AreEqual(subject, actualSubject, "Email Created Unsuccessfully");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Email_with_invalid_Message_data_Part1()
        {
            //Testign with No message
            //arrange
            Email Test_Email = new Email();
            string messageID = "E123456789";
            string sender = "steven@fake-email.com";
            string subject = "testing";
            string message = "";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;

            Assert.AreEqual(message, actualMessage, "Email Created Unsuccessfully");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Email_with_invalid_Message_data_Part_2()
        {
            //testing with 1070 character message
            //arrange
            Email Test_Email = new Email();
            string messageID = "E123456789";
            string sender = "steven@fake-email.com";
            string subject = "testing";
            string message = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;

            Assert.AreEqual(subject, actualSubject, "Email Created Unsuccessfully");
        }

        [TestMethod]
        
        public void Create_Email_with_valid_CeneterCode_data()
        {
            //testing with 1070 character message
            //arrange
            Email Test_Email = new Email();
            string messageID = "E123456789";
            string sender = "steven@fake-email.com";
            string subject = "sir";
            string message = "Hello World";
            string centerCode = "12-123-12";
            string incident = "robbery";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;
            Test_Email.CenterCode = centerCode;
            Test_Email.Incident = incident;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;
            string actualCenterCode = Test_Email.CenterCode;
            string actualIncident = Test_Email.Incident;

            Assert.AreEqual(centerCode, actualCenterCode, "Email Created successfully");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Email_with_invalid_CeneterCode_data()
        {
            //testing with 1070 character message
            //arrange
            Email Test_Email = new Email();
            string messageID = "E123456789";
            string sender = "steven@fake-email.com";
            string subject = "sir";
            string message = "Hello World";
            string centerCode = "1-123-12";
            string incident = "robbery";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;
            Test_Email.CenterCode = centerCode;
            Test_Email.Incident = incident;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;
            string actualCenterCode = Test_Email.CenterCode;
            string actualIncident = Test_Email.Incident;

            Assert.AreEqual(centerCode, actualCenterCode, "Email Created Unsuccessfully");
        }

        [TestMethod]
        
        public void Create_Email_with_valid_incident_data()
        {
            //testing with 1070 character message
            //arrange
            Email Test_Email = new Email();
            string messageID = "E123456789";
            string sender = "steven@fake-email.com";
            string subject = "sir";
            string message = "Hello World";
            string centerCode = "12-123-12";
            string incident = "robbery";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;
            Test_Email.CenterCode = centerCode;
            Test_Email.Incident = incident;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;
            string actualCenterCode = Test_Email.CenterCode;
            string actualIncident = Test_Email.Incident;

            Assert.AreEqual(incident, actualIncident, "Email Created successfully");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Email_with_invalid_Incident_data()
        {
            //testing with 1070 character message
            //arrange
            Email Test_Email = new Email();
            string messageID = "E123456789";
            string sender = "steven@fake-email.com";
            string subject = "Test";
            string message = "Hello World";
            string centerCode = "1-123-12";
            string incident = "Robbery";

            //act
            Test_Email.MessageID = messageID;
            Test_Email.Sender = sender;
            Test_Email.Subject = subject;
            Test_Email.Message = message;
            Test_Email.CenterCode = centerCode;
            Test_Email.Incident = incident;

            //assert
            string actualMessageID = Test_Email.MessageID;
            string actualSender = Test_Email.Sender;
            string actualSubject = Test_Email.Subject;
            string actualMessage = Test_Email.Message;
            string actualCenterCode = Test_Email.CenterCode;
            string actualIncident = Test_Email.Incident;

            Assert.AreEqual(incident, actualIncident, "Email Created unsuccessfully");
        }

    }//end of class

}//end of namespace
