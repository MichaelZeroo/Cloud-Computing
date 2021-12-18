using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCManukauTech.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            string homeMessageString;
            homeMessageString =
            "Home Page for this test service app.\n" 
            + "This app is for transfer of data between machines\n" 
            + "and it is therefore designed to be machine-friendly\n" 
            + "rather than human user-friendly.";

            return homeMessageString;
        }
    }
}