using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDOperationMVC.Models
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public double Balance { get; protected  set; }
        public BankAccount(string accNumber, string accHolder, double initialBalance)
        {
            AccountNumber = accNumber;
            AccountHolder = accHolder;
            Balance = initialBalance;
        }

        public virtual void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}