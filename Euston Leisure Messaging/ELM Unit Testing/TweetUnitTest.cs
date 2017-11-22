using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Euston_Leisure_Messaging;

namespace ELM_Unit_Testing
{
    /// <summary>
    /// Summary description for TweetUnitTest
    /// </summary>
    [TestClass]
    public class TweetUnitTest
    {

        [TestMethod]
        public void Create_Tweet_with_valid_data()
        {
            //arrange
            Tweet Test_Tweet = new Tweet();
            string messageID = "T123456789";
            string handle = "@SGibson";
            string message = "Hello World";

            //act
            Test_Tweet.MessageID = messageID;
            Test_Tweet.Handle = handle;
            Test_Tweet.Message = message;

            //assert
            string actualMessageID = Test_Tweet.MessageID;
            string actualHandle = Test_Tweet.Handle;
            string actualMessage = Test_Tweet.Message;

            Assert.AreEqual(messageID, actualMessageID, "SMS Created successfully");
            Assert.AreEqual(handle, actualHandle, "Tweet Created successfully");
            Assert.AreEqual(message, actualMessage, "Tweet Created successfully");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Tweet_with_invalid_MessageID_data_Part1()
        {
            //arrange
            Tweet Test_Tweet = new Tweet();
            string messageID = "E123456789";
            string handle = "@SGibson";
            string message = "Hello World";

            //act
            Test_Tweet.MessageID = messageID;
            Test_Tweet.Handle = handle;
            Test_Tweet.Message = message;

            //assert
            string actualMessageID = Test_Tweet.MessageID;
            string actualHandle = Test_Tweet.Handle;
            string actualMessage = Test_Tweet.Message;

            Assert.AreEqual(messageID, actualMessageID, "SMS Created successfully");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Tweet_with_invalid_MessageID_data_Part2()
        {
            //arrange
            Tweet Test_Tweet = new Tweet();
            string messageID = "T12345678";
            string handle = "@SGibson";
            string message = "Hello World";

            //act
            Test_Tweet.MessageID = messageID;
            Test_Tweet.Handle = handle;
            Test_Tweet.Message = message;

            //assert
            string actualMessageID = Test_Tweet.MessageID;
            string actualHandle = Test_Tweet.Handle;
            string actualMessage = Test_Tweet.Message;

            Assert.AreEqual(messageID, actualMessageID, "SMS Created unsuccessfully");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Tweet_with_invalid_Handle_data_Part1()
        {
            //arrange
            Tweet Test_Tweet = new Tweet();
            string messageID = "T123456789";
            string handle = "SGibson";
            string message = "Hello World";

            //act
            Test_Tweet.MessageID = messageID;
            Test_Tweet.Handle = handle;
            Test_Tweet.Message = message;

            //assert
            string actualMessageID = Test_Tweet.MessageID;
            string actualHandle = Test_Tweet.Handle;
            string actualMessage = Test_Tweet.Message;

            Assert.AreEqual(handle, actualHandle, "SMS Created unsuccessfully");
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Tweet_with_invalid_Handle_data_Part2()
        {
            //arrange
            Tweet Test_Tweet = new Tweet();
            string messageID = "T123456789";
            string handle = "@SGibson12345678";
            string message = "Hello World";

            //act
            Test_Tweet.MessageID = messageID;
            Test_Tweet.Handle = handle;
            Test_Tweet.Message = message;

            //assert
            string actualMessageID = Test_Tweet.MessageID;
            string actualHandle = Test_Tweet.Handle;
            string actualMessage = Test_Tweet.Message;

            Assert.AreEqual(handle, actualHandle, "SMS Created unsuccessfully");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Tweet_with_invalid_Message_data_Part1()
        {
            //Testing if message is left blank
            //arrange
            Tweet Test_Tweet = new Tweet();
            string messageID = "T123456789";
            string handle = "@SGibson";
            string message = "";

            //act
            Test_Tweet.MessageID = messageID;
            Test_Tweet.Handle = handle;
            Test_Tweet.Message = message;

            //assert
            string actualMessageID = Test_Tweet.MessageID;
            string actualHandle = Test_Tweet.Handle;
            string actualMessage = Test_Tweet.Message;

            Assert.AreEqual(message, actualMessage, "SMS Created unsuccessfully");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Tweet_with_invalid_Message_data_Part2()
        {
            //Testing if message is over 144 characters
            //arrange
            Tweet Test_Tweet = new Tweet();
            string messageID = "T123456789";
            string handle = "@SGibson";
            string message = "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

            //act
            Test_Tweet.MessageID = messageID;
            Test_Tweet.Handle = handle;
            Test_Tweet.Message = message;

            //assert
            string actualMessageID = Test_Tweet.MessageID;
            string actualHandle = Test_Tweet.Handle;
            string actualMessage = Test_Tweet.Message;

            Assert.AreEqual(message, actualMessage, "SMS Created unsuccessfully");
        }

    }//End of class
}//end of namespace