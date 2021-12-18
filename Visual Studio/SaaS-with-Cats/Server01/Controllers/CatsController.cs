using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Server01.Controllers
{
    //20180820 JPC
    //This is a standard MVC controller used for remote web service methods (webpages)

    public class CatsController : Controller
    {
        //GET /cats/test
        public string Test()
        {
            return "Testing .. result from method Test";
        }

        //POST /cats/postnewcat
        [HttpPost]
        public string PostNewCat(string json)
        {
            return "Server confirms that Post Data is Received";
        }
    }
}