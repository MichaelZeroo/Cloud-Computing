using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CatSite.Models.DB;
using Newtonsoft.Json;

namespace CatSite.Controllers
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

        //GET /cats/getusercats?MemberId=10008
        public string GetUserCats(int MemberId)
        {
            //sql would look like 
            //SELECT * FROM Cat WHERE MemberId = <value>
            //LINQ does a shortcut
            var cats = _context.Cat.Where(c => c.MemberId == MemberId).ToList();
            var json = JsonConvert.SerializeObject(cats);
            return json;
        }

        //GET /cats/getcat?CatId=10008
        public string GetCat(int catId)
        {
            //sql would look like 
            //SELECT * FROM Cat WHERE CatId = <value>
            //LINQ does a shortcut
            var cat = _context.Cat.Where(c => c.CatId == catId).SingleOrDefault();
            var json = JsonConvert.SerializeObject(cat);
            return json;
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

        //POST /cats/postupdatecat
        [HttpPost]
        public string PostUpdateCat(string json)
        {
            var cat = JsonConvert.DeserializeObject<Cat>(json);
            _context.Update(cat);
            _context.SaveChanges();
            return "Data Saved.";
        }
    }
}