using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCManukauTech.Controllers
{
    public class EstimateCarValueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public double EstimateCarValue(double Kilometres, int Year, string MfrCode)
        {
           
            double EstValue;

            int AgeInYears = Year - 2018;

            if(AgeInYears > 20)
            {
                AgeInYears = 20;
            }

            double MfrRating = 0;
            if(MfrCode == "ce")
            {
                MfrRating = 1.6;
            }
            else if (MfrCode == "gd")
            {
                MfrRating = 1.4;
            }
            else if (MfrCode == "pi")
            {
                MfrRating = 0.9;
            }
            else if (MfrCode == "tf")
            {
                MfrRating = 0.7;
            }

            EstValue = (4000 + 720 * (24 - AgeInYears)) * MfrRating *(83000 / Kilometres);

            return EstValue;
        }
    }
}