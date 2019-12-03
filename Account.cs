using System;
using System.Collections;
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
        List<Accounts> myObjects = new List<Accounts>();

        public Account()
        {
            Accounts a = new Accounts
            {
                accountName = "Bob Malay",
                accountNumber = "NL41RABO9224568173",
                date = DateTime.Now,
                balance = 100.00
            };
            myObjects.Add(a);

            Accounts b = new Accounts
            {
                accountName = "Jack Reacher",
                accountNumber = "NL18RABO1588633721",
                date = DateTime.Now,
                balance = 0.00
            };
            myObjects.Add(b);

            //a.accountName = "Liza Young";
            //a.accountNumber = "NL27RABO2187209016";
            //a.date = DateTime.Now;
            //a.balance = 0.0;
            //myObjects.Add(a);

        }
        public void UpdateBalance(string accNo, double total)
        {
            var account = myObjects.First(acc => acc.accountNumber == accNo);
            account.balance += total;
        }
        public Accounts Balance(string accNo)
        {
            Accounts a = myObjects.FirstOrDefault(p => p.accountNumber == accNo);
            return a;
        }
    }
}
