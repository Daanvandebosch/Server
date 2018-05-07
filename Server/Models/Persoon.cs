using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Persoon
    {
        public int PersoonID { get; set; }
        public string GSM { get; set; }
        public string Functie { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
    }
}
