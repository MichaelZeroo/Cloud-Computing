using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MVCManukauTech.ViewModels;

namespace MVCManukauTech.Controllers
{
    public class CalcController : Controller
    {
        public string Index()
        {
            return "Test Response";
        }

        //Test string
        //GET /Calc/GetFishPrice?length=80&weight=3&typeCode=tu
        public string GetFishPrice(double length, double weight, string typeCode)
        {
            {
                decimal price;
                double typeCodeFactor;
                var fishResponse = new FishResponseViewModel();

                if (length < 15)
                {
                    fishResponse.IsSuccess = false;
                    fishResponse.Message = "ERROR: Fish must be more than 15cm in length, please enter valid length";
                    return JsonConvert.SerializeObject(fishResponse);
                }
                if (typeCode.ToLower() == "sh")
                {
                    typeCodeFactor = 1;
                }
                else if (typeCode.ToLower() == "gp")
                {
                    typeCodeFactor = 0.6;
                }
                else if (typeCode.ToLower() == "tu")
                {
                    typeCodeFactor = 1.3;
                }
                else if (typeCode.ToLower() == "bf")
                {
                    typeCodeFactor = 1.9;
                }
                else
                {
                    fishResponse.IsSuccess = false;
                    fishResponse.Message = "ERROR: We do not recognise that type of fish";
                    return JsonConvert.SerializeObject(fishResponse);
                }

                price = Convert.ToDecimal(((length * 0.2) + (weight * 5)) * typeCodeFactor);

                fishResponse.Price = price;
                fishResponse.IsSuccess = true;
                return JsonConvert.SerializeObject(fishResponse);
            }
        }

    }
}