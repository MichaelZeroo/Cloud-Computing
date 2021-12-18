using System;
using System.Collections.Generic;

namespace Server01.Models.DB
{
    public partial class Logins
    {
        public Logins()
        {
            Employee = new HashSet<Employee>();
        }

        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
