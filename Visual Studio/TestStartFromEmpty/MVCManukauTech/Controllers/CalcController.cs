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


        // GET: /Calc/GetShippingCost?Weight=6&CountryCodeFrom=NZ&CountryCodeTo=US
        
        public string GetShippingCost(double Weight, string CountryCodeFrom, string CountryCodeTo)
        {
            Decimal cost = -1;
            //allow for reasonable variation in user behaviour
            CountryCodeFrom = CountryCodeFrom.ToUpper();
            CountryCodeTo = CountryCodeTo.ToUpper();
            if (CountryCodeFrom == "USA") CountryCodeFrom = "US";
            if (CountryCodeTo == "USA") CountryCodeTo = "US";
            if (CountryCodeFrom == "AUS") CountryCodeFrom = "AU";
            if (CountryCodeTo == "AUS") CountryCodeTo = "AU";
            //end of variation handling

            //Validation checking.  NZ, AU and US are the only acceptable country codes.  
            //Check for negative weights.
            if (!(CountryCodeFrom == "NZ" || CountryCodeFrom == "US" || CountryCodeFrom == "AU"))
            {
                return "ERROR: Country sent from needs to be NZ, US or AU";
            }
            if (!(CountryCodeTo == "NZ" || CountryCodeTo == "US" || CountryCodeTo == "AU"))
            {
                return "ERROR: Country sent To needs to be NZ, US or AU";
            }
            if (Weight < 0)
            {
                return "ERROR: Weight needs to be 0 or greater.";
            }

            //US to NZ or NZ to US
            if ((CountryCodeFrom == "US" && CountryCodeTo == "NZ")
                || (CountryCodeFrom == "NZ" && CountryCodeTo == "US"))
            {
                if (Weight < 5)
                {
                    cost = Convert.ToDecimal(45);
                }
                else if (Weight <= 10)
                {
                    cost = Convert.ToDecimal(50);
                }
                else
                {
                    cost = Convert.ToDecimal(55);
                }
            }

            //AU to NZ or NZ to AU
            else if ((CountryCodeFrom == "AU" && CountryCodeTo == "NZ")
                || (CountryCodeFrom == "NZ" && CountryCodeTo == "AU"))
            {
                if (Weight < 5)
                {
                    cost = Convert.ToDecimal(10);
                }
                else if (Weight <= 10)
                {
                    cost = Convert.ToDecimal(15);
                }
                else
                {
                    cost = Convert.ToDecimal(20);
                }
            }

            //AU to US or US to AU
            else if ((CountryCodeFrom == "AU" && CountryCodeTo == "US")
                || (CountryCodeFrom == "US" && CountryCodeTo == "AU"))
            {
                if (Weight < 5)
                {
                    cost = Convert.ToDecimal(30);
                }
                else if (Weight <= 10)
                {
                    cost = Convert.ToDecimal(35);
                }
                else
                {
                    cost = Convert.ToDecimal(40);
                }
            }

            //Flat rate of 7.50 to send within the same country.
            else if (CountryCodeFrom == CountryCodeTo)
            {
                cost = Convert.ToDecimal(7.5);
            }


            return cost.ToString();
        }



    }
}