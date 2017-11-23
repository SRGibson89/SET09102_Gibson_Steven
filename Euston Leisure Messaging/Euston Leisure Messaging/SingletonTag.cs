using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: SingletonTag
 * Description: This is where the Hashtag list will be stored but because I only want one list I used
 *	            the singleton pattern.
 * Date Last Modified: 18/11/17
 * Design Pattern: Singleton

 */
namespace Euston_Leisure_Messaging
{
    class SingletonTag
    {
        private static SingletonTag instance;
        public List<Hashtag> HashtagList = new List<Hashtag>();

        private SingletonTag()
        {

        }

        public static SingletonTag Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonTag();
                }
                return instance;
            }
        }

        
    }
}
