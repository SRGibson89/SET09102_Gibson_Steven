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
    class FacadeEmail
    {
        SingletonEmail Email_List = SingletonEmail.Instance;
        
        //public FacadeEmail (string M_ID,string s,string sub,string m)
        //{
        //    LoadEmails();
        //    NewEmail(M_ID, s, sub, m);
        //    SaveEmail();
        //}

        
        public FacadeEmail(string M_ID, string s, string sub,string i,string c, string m)
        {
            LoadEmails();
            NewEmail(M_ID, s, sub, i,c,m);
            SaveEmail();
        }

        private void LoadEmails()
        {
            try
            {
                string FileLoc = @"Resources\messages\emails.json";
                string json = File.ReadAllText(FileLoc);
                Email_List.EmailList = JsonConvert.DeserializeObject<List<Email>>(json);
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        //private void NewEmail(string M_ID, string s, string sub, string m)
        //{
        //    try
        //    {
        //        Email E = new Email();
        //        E.MessageID = M_ID;
        //        E.Sender = s;
        //        E.Subject = sub;
        //        E.Message = m;
        //        Email_List.EmailList.Add(E);
        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e.Message);
        //    }
        //}

        private void NewEmail(string M_ID, string s, string sub, string i, string c, string m)
        {
            try
            {
                Email E = new Email();
                E.MessageID = M_ID;
                E.Sender = s;
                E.Subject = sub;
                E.Incident = i;
                E.CenterCode = c;
                E.Message = m;
                Email_List.EmailList.Add(E);
                Console.WriteLine("Saved " + M_ID);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        
        private void SaveEmail()
        {
            string FileLoc = @"Resources\messages\emails.json"; //filename where data will be stored
            File.WriteAllText(FileLoc, JsonConvert.SerializeObject(Email_List.EmailList));
            Console.WriteLine("All data saved to " + FileLoc);
        }
    }
}
