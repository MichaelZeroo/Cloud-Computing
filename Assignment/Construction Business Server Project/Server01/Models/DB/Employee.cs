using System;
using System.Collections.Generic;

namespace Server01.Models.DB
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int LoginId { get; set; }

        public Logins Login { get; set; }
    }
}
