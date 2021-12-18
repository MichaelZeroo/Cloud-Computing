using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCManukauTech.Controllers
{
    public class DangerousAnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public double dangerousAnimals(double length, double weight, int yearOfBirth, string speciesCode)
        {
            double dangerScore;
            double speciesFactor=0;

            if(speciesCode == "sn")
            {
                speciesFactor = 6;
            }

            if (speciesCode == "ti")
            {
                speciesFactor = 5;
            }

            if (speciesCode == "li")
            {
                speciesFactor = 4.3;
            }

             if (speciesCode == "me")
            {
                speciesFactor = 3.7;
            }

             if(speciesCode == "ki")
            {
                speciesFactor = 12.4;
            }      

            int age = yearOfBirth - 2018;

            dangerScore = ((weight / length) * 5) + ((age / weight) * speciesFactor);

            return dangerScore;


        }
    }
}