using System;
using System.Collections.Generic;

namespace CatSite.Models.DB
{
    public partial class Cat
    {
        public int CatId { get; set; }
        public int MemberId { get; set; }
        public string NameOfCat { get; set; }
        public string Condition { get; set; }
        public double? Weight { get; set; }
        public int? Age { get; set; }

        public Member Member { get; set; }
    }
}
