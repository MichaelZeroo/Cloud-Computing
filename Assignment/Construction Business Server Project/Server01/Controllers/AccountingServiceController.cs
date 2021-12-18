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
    public class AccountingServiceController : Controller
    {
        private readonly string _appAccessKey;
        private readonly CDQ3_LouisMichael_ProjectContext _context;

        public AccountingServiceController(IConfiguration configuration, CDQ3_LouisMichael_ProjectContext context)
        {
            _appAccessKey = configuration.GetSection("AppSettings")["appAccessKey"];
            _context = context;
        }

        //GET /accountingservice/getorderdetail?orderDetailId=8552
        public string GetOrderDetail(int orderDetailId)
        {
            var orderDetail = _context.OrderDetails.Where(c => c.OrderDetailsId == orderDetailId).SingleOrDefault();
            var json = JsonConvert.SerializeObject(orderDetail);
            return json;
        }

        //GET: /accountingservice/getallorderdetails
        public string GetAllOrderDetails()
        {
            var orderDetails = _context.OrderDetails.ToList();
            string json = JsonConvert.SerializeObject(orderDetails);
            return json;
        }

        //POST: /accountingservice/postupdateorder
        [HttpPost]
        public string PostUpdateOrderDetail(string json)
        {
            var orderDetail = JsonConvert.DeserializeObject<OrderDetails>(json);
            _context.Update(orderDetail);
            _context.SaveChanges();
            return "Data Saved.";
        }

        //GET /accountingservice/getorder?orderId=12500
        public string GetOrder(int orderId)
        {
            var order = _context.Orders.Where(c => c.OrderId == orderId).SingleOrDefault();
            var json = JsonConvert.SerializeObject(order);
            return json;
        }

        //GET: /accountingservice/getallorders
        public string GetAllOrders()
        {
            var orders = _context.Orders.ToList();
            string json = JsonConvert.SerializeObject(orders);
            return json;
        }

        //POST: /accountingservice/postupdateorder
        [HttpPost]
        public string PostUpdateOrder(string json)
        {
            var order = JsonConvert.DeserializeObject<Orders>(json);
            _context.Update(order);
            _context.SaveChanges();
            return "Data Saved.";
        }

        //GET /accountingservice/getsupplier?supplierId=501
        public string GetSupplier(int supplierId)
        {
            var supplier = _context.Supplier.Where(c => c.SupplierId == supplierId).SingleOrDefault();
            var json = JsonConvert.SerializeObject(supplier);
            return json;
        }

        //GET: /accountingservice/getallsupplier
        public string GetAllSupplier()
        {
            var suppliers = _context.Supplier.ToList();
            string json = JsonConvert.SerializeObject(suppliers);
            return json;
        }

        //GET /accountingservice/getcustomer?customerId=4002
        public string GetCustomer(int customerId)
        {
            var customer = _context.Customer.Where(c => c.CustomerId == customerId).SingleOrDefault();
            var json = JsonConvert.SerializeObject(customer);
            return json;
        }

        //GET: /accountingservice/getallcustomer
        public string GetAllCustomer()
        {
            var customers = _context.Customer.ToList();
            string json = JsonConvert.SerializeObject(customers);
            return json;
        }
    }
}