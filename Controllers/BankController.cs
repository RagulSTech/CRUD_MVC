using CRUDOperationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDOperationMVC.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank

        private static List<BankAccount> accounts = new List<BankAccount>
        {
            new SavingsAccount("9897969594", "Ragul Subramaniam", 10000),
            new CurrentAccount("9893423423", "Abhirami Ganesan", 15000)
        };
        public ActionResult Index()
        {
            return View(accounts);
        }
        public ActionResult Deposit(string accountNumber, double amount)
        {
            var account = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Withdraw(string accountNumber, double amount)
        {
            var account = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                bool success = account.Withdraw(amount);
                if (!success)
                {
                    TempData["Message"] = "Withdrawal failed! Check balance or overdraft limit.";
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult ApplyInterest(string accountNumber)
        {
            var account = accounts.Find(acc => acc.AccountNumber == accountNumber) as SavingsAccount;
            if (account != null)
            {
                account.ApplyInterest();
            }
            return RedirectToAction("Index");
        }
    }
}