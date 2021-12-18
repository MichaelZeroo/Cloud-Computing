using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
//HomeController configured to start a loosely-coupled app 
//using AJAX  rather than classic form submit
namespace MusicServer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("~/Index.html");
        }
    }
}
