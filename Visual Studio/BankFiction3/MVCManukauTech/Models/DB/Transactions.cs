using System;
using System.Collections.Generic;

namespace MVCManukauTech.Models.DB
{
    public partial class Transactions
    {
        public int TransactionId { get; set; }
        public string UserName { get; set; }
        public string CardType { get; set; }
        public string CardHolder { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsReserved { get; set; }
        public string Notes { get; set; }
        public bool? IsFulfilled { get; set; }
        public int? NumberOfAttempts { get; set; }
        public DateTime? DateOfReservation { get; set; }
        public DateTime? DateOfFulfillment { get; set; }
    }
}
