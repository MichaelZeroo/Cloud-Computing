using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCManukauTech.Models;
using MVCManukauTech.Models.DB;
using Newtonsoft.Json;

namespace MVCManukauTech.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly BankFiction3Context _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TransactionsController(
            BankFiction3Context context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }


        // GET: Transactions
        public IActionResult Index()
        {
            return View();
        }

        //Reservation example
        // Better in production to use POST. Needs GET for early quick testing.
        // GET Transactions/Reservation?MerchantId=Kim@a.a&MerchantPassword=nice.coffee&CardNo=1111&CardType=Visa&CardSecurity=111&CardHolder=Mr%20Tester&CardExpiry=01/12/2014&Amount=1000
        // Comment-out the line below for quick testing = copy/paste the test GET above
        [HttpPost]
        public async Task<string> Reservation(string MerchantId, string MerchantPassword, string CardNo,
            string CardType, string CardSecurity, string CardHolder, string CardExpiry, string Amount)
        {
            //Start with automated login, using code adapted from 
            //the login form handler method "Login" in "AccountController".
            //Input values, output JSON string
            var result = await _signInManager.PasswordSignInAsync(MerchantId, MerchantPassword, false, false);

            if (result != Microsoft.AspNetCore.Identity.SignInResult.Success)
            {
                return "{\"TransactionId\":-1, \"IsReserved\":\"false\",\"Notes\":\"ERROR: Failed Authentication\"}";
            }

            //Supplied CardType needs to start with "V", "M", "A" or "D"
            CardType = CardType.ToUpper().Substring(0, 1);
            if (("VMAD").IndexOf(CardType) == -1)
            {
                return "{\"TransactionId\":-1, \"IsReserved\":\"false\",\"Notes\":\"ERROR: Card needs to be Visa (V), Mastercard (M), American Express (A) or Diners Club (D)\"}";
            }

            //This bank rejects 1 in 3 credit cards at random!
            //20061019 JPC Exception - setup "1111" as a special card number which always passes this test.
            Random rnd = new Random();
            int rndNumber = rnd.Next(1, 4);
            if (rndNumber == 1 && CardNo != "1111")
            {
                return "{\"TransactionId\":-1, \"IsReserved\":\"false\",\"Notes\":\"ERROR: Card Number is not valid\"}";
            }

            if (CardNo.Length >= 14)
            {
                return "{\"TransactionId\":-1, \"IsReserved\":\"false\",\"Notes\":\"ERROR: Card Number is too much like a real one. This is a test system only for test credit card numbers like 1111.\"}";
            }

            //We can now start building the Transaction object
            Transactions transaction = new Transactions();
            transaction.UserName = MerchantId;
            transaction.CardType = CardType;
            transaction.CardHolder = CardHolder;
            transaction.Amount = Convert.ToDecimal(Amount);
            transaction.Notes = "SUCCESS";
            transaction.IsReserved = true;
            transaction.IsFulfilled = false;
            transaction.NumberOfAttempts = 1;
            transaction.DateOfReservation = DateTime.Now;

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            //Now convert object "transaction" to JSON
            string json = JsonConvert.SerializeObject(transaction);
            return json;
        }

        //Fulfillment works by number of parameters - not possible to do an exact test line because Fulfillment
        //needs to follow a Reservation using the TransactionId that came from that Reservation
        // GET /Transactions/Fulfillment?MerchantId=Kim@a.a&MerchantPassword=nice.coffee&TransactionId=COPYPASTETHIS&Amount=1000
        [HttpPost]
        public async Task<string> Fulfillment(string MerchantId, string MerchantPassword, int TransactionId, decimal Amount)
        {
            //Demo Fulfillment method
            var result = await _signInManager.PasswordSignInAsync(MerchantId, MerchantPassword, false, false);

            if (result != Microsoft.AspNetCore.Identity.SignInResult.Success)
            {
                return "{\"IsFulfilled\":\"false\",\"Notes\":\"ERROR: Failed Authentication\"}";
            }
            try
            {
                Transactions transaction = _context.Transactions.Find(TransactionId);
                if (transaction == null)
                {
                    return "{\"IsFulfilled\":\"false\",\"Notes\":\"ERROR: Transaction Id "
                           + TransactionId + " does not match any transactions on record at the Bank of Fiction\"}";
                }
                if (Amount != transaction.Amount)
                {
                    return "{\"IsFulfilled\":\"false\",\"Notes\":\"ERROR: Fulfillment amount "
                           + Amount + " mismatches previously recorded Amount of " + transaction.Amount.ToString() + "\"}";
                }
                transaction.IsFulfilled = true;
                transaction.DateOfFulfillment = DateTime.Now;
                _context.Entry(transaction).State = EntityState.Modified;
                _context.SaveChanges();
                return "{\"IsFulfilled\":\"true\",\"Notes\":\"SUCCESS\"}";
            }
            catch (Exception ex)
            {
                return "{\"IsFulfilled\":\"false\",\"Notes\":\"ERROR:" + ex.Message + "}";
            }
        }

    }
}


