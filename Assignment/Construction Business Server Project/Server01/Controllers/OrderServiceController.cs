using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Server01.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Server01.Controllers
{
    public class OrderServiceController : Controller
    {
        private readonly string _appAccessKey;
        private readonly CDQ3_LouisMichael_ProjectContext _context;

        public OrderServiceController(IConfiguration configuration, CDQ3_LouisMichael_ProjectContext context)
        {
            _appAccessKey = configuration.GetSection("AppSettings")["appAccessKey"];
            _context = context;
        }

        //Login Method is similar to JPC's Example
        [HttpPost]
        public string Login(string json)
        {
            dynamic jsonObject = JsonConvert.DeserializeObject(json);

            string username = (string)jsonObject.SelectToken("Username");

            string password = (string)jsonObject.SelectToken("Password");

            string xPassword = GetHasher(password);

            string sql = "SELECT * FROM Logins WHERE Username = @p0 AND Password = @p1";

            var login = _context.Logins.FromSql(sql, username, xPassword).ToList();

            var loginResponse = new LoginResponse();

            if (login.Count == 1)
            {
                loginResponse.issuccess = true;
                loginResponse.response = "SUCCESS with login";
                loginResponse.userid = login[0].LoginId;
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

        //Hash Function similar to JPC's Example
        private string GetHasher(string textToEncrypt)
        {
            var ad = new System.Security.Cryptography.SHA512Managed();
            var encry = new System.Text.UTF8Encoding();
            byte[] hashIn;
            byte[] hashOut;
            hashIn = encry.GetBytes(textToEncrypt);
            hashOut = ad.ComputeHash(hashIn);
            return Convert.ToBase64String(hashOut);
        }

        public class LoginResponse
        {
            public bool issuccess;
            public string response;
            public int userid;
        }

        //Calculating total price of ordered item 
        public string TotalPrice(int productId, int quantity)
        {
            var product = _context.Products.Where(p => p.ProductId == productId);
            var price = product.Where(p => p.ProductPrice >= 0).ToString();
            var price2 = int.Parse(price);
            var total = (price2 * quantity).ToString();
            string json = JsonConvert.SerializeObject(total);
            return json;

        }

        //POST new order
        [HttpPost]
        public string PostNewOrder(string json)
        {
            var order = JsonConvert.DeserializeObject<Orders>(json);
            _context.Add(order);
            _context.SaveChanges();
            return "Data Saved.";
        }

        //POST new orderdetail
        [HttpPost]
        public string PostNewOrderDetail(string json)
        {
            var orderDetail = JsonConvert.DeserializeObject<OrderDetails>(json);
            _context.Add(orderDetail);
            _context.SaveChanges();
            return "Data Saved.";
        }

        //GET /orderservice/getproduct?productId=7007
        public string GetProduct(int productId)
        {
            var product = _context.Products.Where(c => c.ProductId == productId).SingleOrDefault();
            var json = JsonConvert.SerializeObject(product);
            return json;
        }

        //GET: /orderservice/getallproducts
        public string GetAllProducts()
        {
            var products = _context.Products.ToList();
            string json = JsonConvert.SerializeObject(products);
            return json;
        }
    }
}