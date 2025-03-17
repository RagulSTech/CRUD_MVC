using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDOperationMVC.Models
{
    public class SavingsAccount:BankAccount
    {
        private double InterestRate = 5.0;  
        private const double MinimumBalance = 1000;
        public SavingsAccount(string accNumber, string accHolder, double initialBalance)
            : base(accNumber, accHolder, initialBalance) { }

        public void ApplyInterest()
        {
            double interest = Balance * InterestRate / 100;
            Balance += interest;
        }

        public override bool Withdraw(double amount)
        {
            if (Balance - amount >= MinimumBalance) 
            {
                return base.Withdraw(amount);
            }
            return false;
        }
    }
}