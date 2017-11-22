using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    class SIR
    {
        private string incident;
        private int occurances;

        public string Incident
        {
            get { return incident; }
            set { incident = value; }
        }

        public int Occurances
        {
            get { return occurances; }
            set { occurances = value; }
        }

        public SIR(string i, string occ)
        {
            Incident = i;
            Occurances = int.Parse(occ);
        }
    }
}
