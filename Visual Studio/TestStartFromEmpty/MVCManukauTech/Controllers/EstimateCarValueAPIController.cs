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
    public class EstimateCarValueAPIController : ControllerBase
    {
        // GET: api/EstimateCarValueAPI
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/EstimateCarValueAPI/5
        [HttpGet]
        public string Get(double Kilometres, int Year, string MfrCode)
        {
            double EstValue;

            int AgeInYears = Year - 2018;

            if (AgeInYears > 20)
            {
                AgeInYears = 20;
            }

            double MfrRating = 0;
            if (MfrCode == "ce")
            {
                MfrRating = 1.6;
            }
            else if (MfrCode == "gd")
            {
                MfrRating = 1.4;
            }
            else if (MfrCode == "pi")
            {
                MfrRating = 0.9;
            }
            else if (MfrCode == "tf")
            {
                MfrRating = 0.7;
            }

            EstValue = (4000 + 720 * (24 - AgeInYears)) * MfrRating * (83000 / Kilometres);

            return EstValue.ToString();
        }

        // POST: api/EstimateCarValueAPI
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/EstimateCarValueAPI/5
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
