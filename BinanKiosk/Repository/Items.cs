using BinanKiosk.Enums;
using BinanKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Repository
{
	public class Items
	{
		public string Objectname { get; set; }
		public object itemObject { get; set; }
		public Categories itemCategory { get; set; }

	}
}
