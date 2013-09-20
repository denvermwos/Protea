using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protea
{
    class cboxDCItem
    {
        public string Name;
        public int DorCInt;
        public cboxDCItem(string name,int dorcint)
        {
            Name = name;
            DorCInt = dorcint;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
