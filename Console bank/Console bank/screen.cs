
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_bank
{
    internal class screen
    {
        class Bank
        {
            private List<User> users;

            public Bank()
            {
                users = new List<User>();
            }

            public void AddUser(User user)
            {
                users.Add(user);
            }

            public void DisplayAccounts()
            {

               System. Console.Title = "shege App";
              System.  Console.ForegroundColor = ConsoleColor.Green;
               System. Console.WriteLine("\n\n......................................... Welcome to ShegeBank App........................\n\n\n");
               System. Console.WriteLine("press Enter to print");
               System. Console.ReadLine();
               System. Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|----------|");
                System.Console.WriteLine("|     FULL NAME     |        ACCOUNT NUMBER         |       ACCOUNT TYPE       |       AMOUNT BAL    |   NOTE   |");
               System. Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|----------|");

                foreach (User user in users)
                {
                    foreach (Account account in user.Accounts)
                    {
                      System .Console.WriteLine($"| {user.FullName,-17} | {account.AccountNumber,-29} | {account.AccountType,-24} | {account.Balance.ToString("N0"),-19} | {account.Note,-8} |");
                    }
                   System.Console.WriteLine("|--------------------------------------------------------------------------------------------------------------|");

                }



            }
        }
    }
}
