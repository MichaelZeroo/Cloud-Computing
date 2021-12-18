using System;
using System.Collections.Generic;

namespace CatSite.Models.DB
{
    public partial class Member
    {
        public Member()
        {
            Cat = new HashSet<Cat>();
        }

        public int MemberId { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Cat> Cat { get; set; }
    }
}
