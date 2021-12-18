using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCManukauTech.Controllers
{
    public class CalcController : Controller
    {
        public string Index()
        {
            return "Hello Mars";
        }

        public string Add(double a, double b)
        {
            double c = a + b;
            return c.ToString();
        }

        public string LightCheck(double LEDpower)
        {
            double bulbPower = 0;
            bulbPower = LEDpower * 9;
            return bulbPower.ToString();
        }

        //GET /Calc/EstimatedValue?kilometres=114383&year=2002&mfrCode=pi  
        public decimal EstimatedValue(double kilometres, int year, string mfrCode)
        {
            int currentYear = DateTime.Now.Year;
            int ageInYears = currentYear - year;
            if (ageInYears > 20)
            {
                ageInYears = 20;
            }

            double mfrRating;
            switch(mfrCode)
            {
                case "ce":
                    mfrRating = 1.6;
                    break;
                case "gd":
                    mfrRating = 1.4;
                    break;
                case "pi":
                    mfrRating = 0.9;
                    break;
                case "tf":
                    mfrRating = 0.7;
                    break;
                default:
                    return Convert.ToDecimal(-1.0);
            }

            decimal estValue;      
            estValue = Convert.ToDecimal(
                (4000 + 720 * (24 - ageInYears)) * mfrRating
                * (83000 / kilometres));
            return estValue;
        }



    }
}