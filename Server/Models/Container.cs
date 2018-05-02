using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Container
    {
        public int ContainerID { get; set; }
        public string Plaats { get; set; }
        public DateTime Van { get; set; }
        public DateTime Tot { get; set; }
    }
}
