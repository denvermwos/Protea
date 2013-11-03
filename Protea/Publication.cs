using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protea
{
    public class Publication
    {
        public int PublicationID {get;set;}
        public string PublicationName { get; set; }
        public decimal PublicationPrice { get; set; }

        public static List<Publication> GetPublications()
        {
            return new List<Publication>();
        }
    }
}
