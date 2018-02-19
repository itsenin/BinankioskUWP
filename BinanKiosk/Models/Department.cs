using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Models
{
    public class Department
    {
        public int Department_ID { get; set; }
        public string Department_Name { get; set; }
        public Floor Room { get; set; }
        public string Department_Description { get; set; }
    }
}
