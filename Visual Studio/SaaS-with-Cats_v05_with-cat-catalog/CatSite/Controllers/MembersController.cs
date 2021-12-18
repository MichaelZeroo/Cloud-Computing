using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CatSite.Models.DB;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace CatSite.Controllers
{
    public class MembersController : Controller
    {
        //20160813 JPC HOWTO read configuration data and connectionString in a controller
        private readonly string _appAccessKey;
        private readonly CatBabysittingContext _context;

        public MembersController(IConfiguration configuration, CatBabysittingContext context)
        {
            _appAccessKey = configuration.GetSection("AppSettings")["appAccessKey"];
            _context = context;
        }

        [HttpPost]
        public string Login(string json)
        {
            dynamic jsonObject = JsonConvert.DeserializeObject(json);
            string username = (string)jsonObject.SelectToken("Username");
            string password = (string)jsonObject.SelectToken("Password");
            string xPassword = GetHash(password);
            string sql = "SELECT * FROM Member WHERE Email = @p0 AND Password = @p1";
            var member = _context.Member.FromSql(sql, username, xPassword).ToList();
            var loginResponse = new LoginResponse();
            //Success is when there is 1 matching row for this username/password
            if(member.Count == 1)
            {
                loginResponse.issuccess = true;
                loginResponse.response = "SUCCESS with login";
                loginResponse.userid = member[0].MemberId;
            }
            else
            {
                loginResponse.issuccess = false;
                loginResponse.response = "Login unsuccessful";
                loginResponse.userid = -1;
            }
            string response = JsonConvert.SerializeObject(loginResponse);
            return response;
        }

        //POST /members/register
        [HttpPost]
        public string Register(string json)
        {
            var member = JsonConvert.DeserializeObject<Member>(json);
            _context.Add(member);
            _context.SaveChanges();
            return "SUCCESS with registration. You can now login with your Email and Password.";
        }

        public class LoginResponse
        {
            public bool issuccess;
            public string response;
            public int userid;
        }

        private string GetHash(string textToEncrypt)
        {
            //Attribution - thanks to Mike Lopez for advice on one-way encryption 
            var sp = new System.Security.Cryptography.SHA512Managed();
            var enc = new System.Text.UTF8Encoding();
            byte[] hashIn;
            byte[] hashOut;
            //Change the text to encrypt into a byte array of ASCII codes
            //e.g. "A" needs to change to 65
            hashIn = enc.GetBytes(textToEncrypt);
            //We are now ready to encrypt
            hashOut = sp.ComputeHash(hashIn);
            //The result is still in bytes! We need to change back to string
            return Convert.ToBase64String(hashOut);
        }

    }
}