using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Server01.Models.DB;

namespace Server01.Controllers
{
    public class InventoryServiceController : Controller
    {
        private readonly string _appAccessKey;
        private readonly CDQ3_LouisMichael_ProjectContext _context;

        public InventoryServiceController(IConfiguration configuration, CDQ3_LouisMichael_ProjectContext context)
        {
            _appAccessKey = configuration.GetSection("AppSettings")["appAccessKey"];
            _context = context;
        }

        //GET /inventoryservice/getproduct?productId=7007
        public string GetProduct(int productId)
        {
            var product = _context.Products.Where(c => c.ProductId == productId).SingleOrDefault();
            var json = JsonConvert.SerializeObject(product);
            return json;
        }

        //GET: /inventoryservice/getallproducts
        public string GetAllProducts()
        {
            var products = _context.Products.ToList();
            string json = JsonConvert.SerializeObject(products);
            return json;
        }

        //POST: /inventoryservice/postupdateproduct
        //Updating product
        [HttpPost]
        public string PostUpdateProduct(string json)
        {
            var product = JsonConvert.DeserializeObject<Products>(json);
            _context.Update(product);
            _context.SaveChanges();
            return "Data Saved.";
        }

        //POST: /inventoryservice/postnewproduct
        //New Product
        [HttpPost]
        public string PostNewProduct(string json)
        {
            var product = JsonConvert.DeserializeObject<Products>(json);
            _context.Add(product);
            _context.SaveChanges();
            return "Data Saved.";
        }
    }
}