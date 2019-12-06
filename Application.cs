using System;
using System.Collections;

namespace TheFuture
{
    public class Application
    {
        Deposit deposit = new Deposit();
        Account account = new Account();

        void menu()
        {
            Console.WriteLine(" The FutureBank");
            Console.WriteLine("|------------------------\n");
            Console.WriteLine(" Select Menu\r");
            Console.WriteLine("|------------------------\n");
            Console.WriteLine("Press a to List account");
            Console.WriteLine("Press d to Deposit");
            Console.WriteLine("Press t to Transfer money");
            Console.WriteLine("Press x to Exit");
        }

        void doCommand(string cmd)
        {
            switch (cmd)
            {
                case "a":           
                    Console.WriteLine();
                    foreach (Accounts aPart in account.accObject)
                    {
                        Console.WriteLine($"Acc No: " + aPart.accountNumber + "  " + $"Acc Balance: " + aPart.balance);
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
                        
                        account.UpdateBalance(accId, total);
                        Console.WriteLine($"Balance : " + account.Balance(accId).balance);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid account id : " + accId);
                    }
                    break;
                case "t":
                    Console.WriteLine($"From account id: ");
                    var transferFrom = Console.ReadLine();
                    Console.WriteLine($"Amount : ");
                    var amountToTransfer = Console.ReadLine();

                    Console.WriteLine($"To account id: ");
                    var transferTo = Console.ReadLine();

                    if (account.IsExists(transferFrom) && account.IsExists(transferTo) && (!transferFrom.Equals(transferTo)))
                    {                      
                        account.AdjustBalance(transferFrom, Double.Parse(amountToTransfer));
                        account.UpdateBalance(transferTo, Double.Parse(amountToTransfer));
                    }
                    Console.WriteLine($"Something went wrong when transfer ");
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
    }
}
