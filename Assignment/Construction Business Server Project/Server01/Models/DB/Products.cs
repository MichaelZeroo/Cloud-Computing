using System;
using System.Collections.Generic;

namespace Server01.Models.DB
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int? StockQuantity { get; set; }
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
