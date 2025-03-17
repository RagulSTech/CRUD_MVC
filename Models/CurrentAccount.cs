using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDOperationMVC.Models
{
    public class CurrentAccount : BankAccount
    {
        private double OverdraftLimit = 1000;   

        public CurrentAccount(string accNumber, string accHolder, double initialBalance)
            : base(accNumber, accHolder, initialBalance) { }

        public override bool Withdraw(double amount)
        {
            if (amount > 0 && (Balance - amount) >= -OverdraftLimit)    
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}