using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: Hashtag
 * Description: This is where the Hashtag object will be created, it stores the hashtag and how many times it will behave been used.
 * Date Last Modified: 18/11/17
 */

namespace Euston_Leisure_Messaging
{
    class Hashtag
    {
        public string tag;
        public int trending;
         
        public string Tag
        {
            get {return tag;}
            set { tag = value; }
        }

        public int Trending
        {
            get { return trending; }
            set { trending = value; }
        }

        public Hashtag (string t,string tre)
        {
            Tag = t;
            Trending = int.Parse(tre);
        }
    }
}
