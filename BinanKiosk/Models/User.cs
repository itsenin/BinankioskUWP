using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Models
{
    public class User
    {
        public string Username { get; set; }
        public string password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Middle_Initial { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
    }
}
