using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccounts
{
    internal class BankAccount
    {
        public string AccNumber { get; }
        string AccName;
        public string Currency { get; }
        public static List<string> AccNumbers { get; set; } = new List<string>();
        public double balance { get; set; }

        public BankAccount(string accNumber, string accName, int currency)
        {
            this.AccNumber = accNumber;
            this.AccName = accName;
            this.Currency = currency == 1 ? "LEK" : (currency == 2 ? "USD" : (currency == 3 ? "EUR" : "GBP"));
            AccNumbers.Add(accNumber);
        }

        public void deposit(int amount)
        {
            balance += amount;
        }

        public bool withdraw(int amount)
        {
            if (amount > balance)
            {
                return false;
            }

            balance -= amount;

            return true;
        }
    }
}
