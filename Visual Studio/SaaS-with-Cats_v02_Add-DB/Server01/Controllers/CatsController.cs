using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Server01.Models.DB;
using Newtonsoft.Json;

namespace Server01.Controllers
{
    //20180820 JPC
    //This is a standard MVC controller used for remote web service methods (webpages)

    public class CatsController : Controller
    {
        //20160813 JPC HOWTO read configuration data and connectionString in a controller
        private readonly string _appAccessKey;
        private readonly CatBabysittingContext _context;

        public CatsController(IConfiguration configuration, CatBabysittingContext context)
        {
            _appAccessKey = configuration.GetSection("AppSettings")["appAccessKey"];
            _context = context;
        }

        //POST /cats/postnewcat
        [HttpPost]
        public string PostNewCat(string json)
        {
            var cat = JsonConvert.DeserializeObject<Cat>(json);
            _context.Add(cat);
            _context.SaveChanges();
            return "Data Saved.";
        }
    }
}