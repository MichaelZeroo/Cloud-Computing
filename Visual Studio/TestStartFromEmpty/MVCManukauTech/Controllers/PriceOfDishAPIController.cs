using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCManukauTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceOfDishAPIController : ControllerBase
    {
        // GET: api/PriceOfDishAPI
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/PriceOfDishAPI/5
        [HttpGet]
        public string Get(double length, double weight)
        {
            double price;

            if (length < 15)
            {
                price = -1;
            }

            price = (length * 0.2) + (weight * 10);

            return price.ToString();
        }

        // POST: api/PriceOfDishAPI
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/PriceOfDishAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
