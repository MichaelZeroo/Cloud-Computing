using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCManukauTech.ViewModels
{
    public class FishResponseViewModel
    {
        public decimal Price { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
