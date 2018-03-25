using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Models
{
    public class Office
    {
		public Department department { get; set; }
        public int Office_ID { get; set; }
		public string Office_Name { get; set; }
		public string Room_Name { get; set; }
		public string image_path { get; set; }
    }
}
