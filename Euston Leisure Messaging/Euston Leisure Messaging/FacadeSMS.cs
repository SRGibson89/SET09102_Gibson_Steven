using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// Facade Design Pattern.
namespace Euston_Leisure_Messaging
{
    class FacadeSMS
    {
        SingletonSms SMS_List = SingletonSms.Instance;

        public FacadeSMS (string M_ID,double s, string m)
        {
            //LoadSMS();
            New_SMS(M_ID,s,m);
            SaveSMS();
        }

        

        private void LoadSMS()
        {
            try
            {
                string FileLoc = @"Resources\messages\sms.json";
                string json = File.ReadAllText(FileLoc);
                SMS_List.SMSList = JsonConvert.DeserializeObject<List<SMS>>(json);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void New_SMS(string M_ID, double s, string m)
        {
            try
            {
                //makes a new customer then adds them to the singalton list
                SMS S = new SMS();
                S.MessageID = M_ID;
                S.PhoneNumber = s;
                S.Message = m;
                SMS_List.SMSList.Add(S);
                Console.WriteLine("Saved " + M_ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SaveSMS()
        {
            string FileLoc = @"Resources\messages\sms.json"; //filename where data will be stored
            File.WriteAllText(FileLoc, JsonConvert.SerializeObject(SMS_List.SMSList));
            Console.WriteLine("All data saved to " + FileLoc);
        }
    }
}
