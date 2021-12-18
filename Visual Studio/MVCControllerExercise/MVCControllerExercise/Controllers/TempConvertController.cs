using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCControllerExercise.Controllers
{
    public class TempConvertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string TempConvert(double f)
        {
            double c = (f - 32) * 100 / 180;
            return c.ToString();
        }
    }
}