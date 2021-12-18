using System;
using System.Collections.Generic;

namespace Server01.Models.DB
{
    public partial class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? OrderQuantity { get; set; }

        public Orders Order { get; set; }
        public Products Product { get; set; }
    }
}
