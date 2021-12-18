using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCManukauTech.Controllers
{
    public class PriceOfFishController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public double priceOfFish(double length, double weight)
        {
            double price;

            if(length < 15)
            {
                price = -1;
            }

            price = (length * 0.2) + (weight * 10);

            return price;
        }
    }
}