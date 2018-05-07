using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Events
    {
        public int EventID { get; set; }
        public string Naam { get; set; }
        public string Locatie { get; set; }
        public int ContactpersoonID { get; set; }
        public int VerantwoordelijkeID { get; set; }
    }
}