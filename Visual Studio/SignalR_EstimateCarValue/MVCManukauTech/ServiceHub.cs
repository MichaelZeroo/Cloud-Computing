using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Data.SqlClient;
using System.Security.Principal;

namespace MVCManukauTech
{
    public class ServiceHub: Hub
    {

        //20160813 JPC HOWTO read connectionString in a controller
        private readonly string _connectionString;
        private readonly string _appAccessKey;

        public ServiceHub(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _appAccessKey = configuration.GetSection("AppSettings")["appAccessKey"];
        }

        //Simplest possible app without access check
        public async Task Add(string request)
        {
            string response;
            dynamic messageObject = JsonConvert.DeserializeObject(request);
            double a = (double)messageObject.SelectToken("a");
            double b = (double)messageObject.SelectToken("b");
            double c = a + b;
            response = "{\"response\":" + c + "}";
            await Clients.Caller.SendAsync("XSignal", response);
        }

        public async Task EstimatedValue(string request)
        {
            string response;
            EstimatedValueRequest requestObject
                = JsonConvert.DeserializeObject<EstimatedValueRequest>(request);
            //simple access check
            string accessKey = requestObject.accessKey;
            if (accessKey != _appAccessKey)
            {
                response = "{\"response\": \"Access Denied - contact app owner to check your registration and user status\"}";
                await Clients.Caller.SendAsync("XSignal", response);
                return;
            }

            //extract values out of the JSON request
            double kilometres = requestObject.kilometres;
            int year = requestObject.year;
            string mfrCode = requestObject.mfrCode;

            //process now begins
            int currentYear = DateTime.Now.Year;
            int ageInYears = currentYear - year;
            if (ageInYears > 20)
            {
                ageInYears = 20;
            }

            double mfrRating;
            switch (mfrCode)
            {
                case "ce":
                    mfrRating = 1.6;
                    break;
                case "gd":
                    mfrRating = 1.4;
                    break;
                case "pi":
                    mfrRating = 0.9;
                    break;
                case "tf":
                    mfrRating = 0.7;
                    break;
                default:
                    response = "{\"response\":\"ERROR: unrecognised manufacturer code\"}";
                    await Clients.Caller.SendAsync("XSignal", response);
                    return;
            }

            decimal estValue;
            estValue = Convert.ToDecimal(
                (4000 + 720 * (24 - ageInYears)) * mfrRating * (83000 / kilometres));
            response = "{\"response\":" + estValue + "}";
            await Clients.Caller.SendAsync("XSignal", response);
            return;
        }

        //Helper class to process the request for an Estimated Value
        private class EstimatedValueRequest
        {
            public string accessKey;
            public double kilometres;
            public int year;
            public string mfrCode;
        }

    }
}
