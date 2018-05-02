using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Installatie
    {
        public int InstallatieID { get; set; }
        public int ContainerID { get; set; }
        public int DeviceID { get; set; }
        public DateTime Van { get; set; }
        public DateTime Tot { get; set; }
        public int EventID { get; set; }
        public string Omschrijving { get; set; }
        public int VerantwoordelijkeID { get; set; }
    }
}
