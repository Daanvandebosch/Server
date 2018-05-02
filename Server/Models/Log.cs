using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Log
    {
        public int LogID { get; set; }
        public int InstallatieID { get; set; }
        public string Melding { get; set; }
        public DateTime Tijd { get; set; }
    }
}
