using System;
using System.Collections;

namespace TheFuture
{
    public class Application
    {
        Deposit deposit = new Deposit();
        Account account = new Account();
        //AccountManager aManager = new AccountManager();    

        void menu()
        {
            Console.WriteLine("|------------------------\n");
            Console.WriteLine(" The FutureBank");
            Console.WriteLine("|------------------------\n");
            Console.WriteLine(" Select Menu\r");
            Console.WriteLine("|------------------------\n");
            Console.WriteLine("Press a to List account");
            Console.WriteLine("Press d to Deposit");
            Console.WriteLine("Press t to Transfer money");
            Console.WriteLine("Press x to Exit");
            Console.WriteLine("|------------------------\n");
        }

        void doCommand(string cmd)
        {
            switch (cmd)
            {
                case "a":           
                    Console.WriteLine();
                    foreach (Accounts aPart in account.myObject)
                    {
                        Console.WriteLine($"Acc No: " + aPart.accountNumber + $"Acc Balance: " + aPart.balance);
                    }
                    break;
                case "d":
                    Console.WriteLine($"Account Id : ");
                    var accId = Console.ReadLine();
                    Console.WriteLine($"Amount : ");
                    var amount = Console.ReadLine();

                    if (account.IsExists(accId))
                    {
                        var total = deposit.Total(Double.Parse(amount));
                        //update balance
                        account.UpdateBalance(accId, total);
                        Console.WriteLine($"Balance : " + account.Balance(accId).balance);
                    }
                    else
                    {
                        Console.WriteLine($"Don't Account: " + accId);
                    }
                    break;
                case "t":
                    Console.WriteLine($"From account id: ");
                    var transferFrom = Console.ReadLine();
                    Console.WriteLine($"Amount : ");
                    var amountToTransfer = Console.ReadLine();

                    Console.WriteLine($"To account id: ");
                    var transferTo = Console.ReadLine();

                    if (account.IsExists(transferFrom) && account.IsExists(transferTo))
                    {                      
                        account.Reduct(transferFrom, Double.Parse(amountToTransfer));
                        account.UpdateBalance(transferTo, Double.Parse(amountToTransfer));
                    }
                    else
                    {
                        Console.WriteLine($"Don't Account: ");
                    }


                    Console.WriteLine($"Your result:");
                    break;
                default:
                    Console.WriteLine("Invalid command: " + cmd);
                    break;
            }
        }

        public void run()
        {
            string cmd;
            menu();
            while ((cmd = Console.ReadLine()) != "x")
            {
                doCommand(cmd);
                menu();
            }
        }

        void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }
    }
}
