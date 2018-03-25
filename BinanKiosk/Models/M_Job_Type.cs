using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Models
{
    public class M_Job_Type
    {
        public int JobType_ID { get; set; }
        public string Job_Types { get; set; }
        public M_Job_Category Category { get; set; }
        public string Job_Description { get; set; }
        public string Job_Location { get; set; }
        public string Job_Company { get; set; }
		public string job_Image_Path { get; set; }
		public string logo_Image_Path { get; set; }
	}
}
