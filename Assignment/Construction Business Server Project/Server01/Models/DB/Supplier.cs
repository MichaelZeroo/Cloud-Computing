using System;
using System.Collections.Generic;

namespace Server01.Models.DB
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Products>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
