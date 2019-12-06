using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFuture
{
    public class Accounts
    {
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public DateTime date { get; set; }
        public double balance { get; set; }
    }

    public class Account
    {
        public List<Accounts> accObject = new List<Accounts>();

        public Account()
        {
            Accounts a = new Accounts
            {
                accountName = "Bob Malay",
                accountNumber = "NL41RABO9224568173",
                date = DateTime.Now,
                balance = 100.00
            };
            accObject.Add(a);

            Accounts b = new Accounts
            {
                accountName = "Jack Reacher",
                accountNumber = "NL18RABO1588633721",
                date = DateTime.Now,
                balance = 0.00
            };
            accObject.Add(b);

            Accounts c = new Accounts
            {
                accountName = "Liza Young",
                accountNumber = "NL27RABO2187209016",
                date = DateTime.Now,
                balance = 0.00
            };
            accObject.Add(c);
        }

        public void UpdateBalance(string accNo, double total)
        {
            var account = accObject.First(acc => acc.accountNumber == accNo);
            account.balance += total;
        }
        public Accounts Balance(string accNo)
        {
            return accObject.FirstOrDefault(p => p.accountNumber == accNo);
        }
        public Accounts AdjustBalance(string accNo, double amount)
        {
            Accounts a = accObject.FirstOrDefault(p => p.accountNumber == accNo);
            if ((a.balance >= amount) && (amount > 0))
            {
                a.balance = a.balance - amount;
            }
            else if(amount < 0)
            {
                Console.WriteLine($"Amount must be more than 0");
            }
            else { Console.WriteLine($"Your account balance is not enought"); }

            return a;
        }
        public bool IsExists(string accId)
        {
            return accObject.Exists(x => x.accountNumber == accId);
        }
    }
}
