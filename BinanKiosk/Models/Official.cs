using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Models
{
    public class Official
    {
        public int Officials_ID { get; set; }
        public string First_Name { get; set; }
        public string Middle_Initial { get; set; }
        public string Last_Name { get; set; }
        public string Suffix { get; set; }
        public Position position { get; set; }
        public Department department { get; set; }
    }
}
