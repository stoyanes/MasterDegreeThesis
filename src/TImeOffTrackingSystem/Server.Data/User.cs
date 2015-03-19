using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
    //[DataContract]
    public class User
    {
        public string Id { get; set; }
        public string Role { get; set; } // need new enum called UserRole
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
