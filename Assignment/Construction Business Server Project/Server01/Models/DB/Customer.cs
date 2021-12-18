using System;
using System.Collections.Generic;

namespace Server01.Models.DB
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? PostCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
