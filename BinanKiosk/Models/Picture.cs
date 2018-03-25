using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Models
{
    public class Picture
    {
		public string Name { get; set; }
		public byte[] image { get; set; }
		public string FolderName { get; set; }
	}
}
