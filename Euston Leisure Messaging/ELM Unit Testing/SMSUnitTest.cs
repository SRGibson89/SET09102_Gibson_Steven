using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Euston_Leisure_Messaging;
/*
   * Author: Steven Gibson
   * Matriculation Number: 40270320
   * Class name: SMSUnitTest
   * Description: This unit test will test error checking that is part of the SMS class
   * Date Last Modified: 21/11/2017
   * Unit testing for SMS Class

   */
namespace ELM_Unit_Testing
{
    /// <summary>
    /// Summary description for SMSUnitTest
    /// </summary>

    [TestClass]
    public class SMSlUnitTest
    {
        [TestMethod]
        public void Create_SMS_with_valid_data()
        {
            //arrange
            SMS Test_SMS = new SMS();
            string messageID = "S123456789";
            double phoneNumber = 07792923557;
            string message = "Hello World";

            //act
            Test_SMS.MessageID = messageID;
            Test_SMS.PhoneNumber = phoneNumber;
            Test_SMS.Message = message;

            //assert
            string actualMessageID = Test_SMS.MessageID;
            double actualPhoneNumber = Test_SMS.PhoneNumber;
            string actualMessage = Test_SMS.Message;

            Assert.AreEqual(messageID, actualMessageID, "SMS Created successfully");
            Assert.AreEqual(phoneNumber, actualPhoneNumber, "SMS Created successfully");
            Assert.AreEqual(message, actualMessage, "SMS Created successfully");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_SMS_with_invalid_MessageID_data_Part1()
        {
            //arrange
            SMS Test_SMS = new SMS();
            string messageID = "E123456789";
            double phoneNumber = 07792923557;
            string message = "Hello World";

            //act
            Test_SMS.MessageID = messageID;
            Test_SMS.PhoneNumber = phoneNumber;
            Test_SMS.Message = message;

            //assert
            string actualMessageID = Test_SMS.MessageID;
            double actualPhoneNumber = Test_SMS.PhoneNumber;
            string actualMessage = Test_SMS.Message;

            Assert.AreEqual(messageID, actualMessageID, "SMS Created successfully");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_SMS_with_invalid_MessageID_data_Part2()
        {
            //arrange
            SMS Test_SMS = new SMS();
            string messageID = "S12345678";
            double phoneNumber = 07792923557;
            string message = "Hello World";

            //act
            Test_SMS.MessageID = messageID;
            Test_SMS.PhoneNumber = phoneNumber;
            Test_SMS.Message = message;

            //assert
            string actualMessageID = Test_SMS.MessageID;
            double actualPhoneNumber = Test_SMS.PhoneNumber;
            string actualMessage = Test_SMS.Message;

            Assert.AreEqual(messageID, actualMessageID, "SMS Created successfully");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_SMS_with_invalid_PhoneNumber_data()
        {
            //arrange
            SMS Test_SMS = new SMS();
            string messageID = "S123456789";
            double phoneNumber = 0779292355;
            string message = "Hello World";

            //act
            Test_SMS.MessageID = messageID;
            Test_SMS.PhoneNumber = phoneNumber;
            Test_SMS.Message = message;

            //assert
            string actualMessageID = Test_SMS.MessageID;
            double actualPhoneNumber = Test_SMS.PhoneNumber;
            string actualMessage = Test_SMS.Message;

            Assert.AreEqual(messageID, actualMessageID, "SMS Created successfully");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_SMS_with_invalid_Message_data_Part1()
        {
            //Testing if message is left blank

            //arrange
            SMS Test_SMS = new SMS();
            string messageID = "S123456789";
            double phoneNumber = 07792923557;
            string message = "";

            //act
            Test_SMS.MessageID = messageID;
            Test_SMS.PhoneNumber = phoneNumber;
            Test_SMS.Message = message;

            //assert
            string actualMessageID = Test_SMS.MessageID;
            double actualPhoneNumber = Test_SMS.PhoneNumber;
            string actualMessage = Test_SMS.Message;

            Assert.AreEqual(messageID, actualMessageID, "SMS Created successfully");

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_SMS_with_invalid_Message_data_Part2()
        {
            //Testing if message character count above 144
            //arrange
            SMS Test_SMS = new SMS();
            string messageID = "S123456789";
            double phoneNumber = 07792923557;
            string message = "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

            //act
            Test_SMS.MessageID = messageID;
            Test_SMS.PhoneNumber = phoneNumber;
            Test_SMS.Message = message;

            //assert
            string actualMessageID = Test_SMS.MessageID;
            double actualPhoneNumber = Test_SMS.PhoneNumber;
            string actualMessage = Test_SMS.Message;

            Assert.AreEqual(messageID, actualMessageID, "SMS Created successfully");

        }
    }//end of class

}//end of namespace