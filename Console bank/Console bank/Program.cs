using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console Bank
    class User
{
    private static int nextAccountNumber = 0987654321;

    public string FullName { get; }
    public List<Account> Accounts { get; }

    public User(string fullName)
    {
        FullName = fullName;
        Accounts = new List<Account>();
    }

    public void AddAccount(AccountType accountType)
    {
        string accountNumber = GenerateAccountNumber();
        Account account = new(accountNumber, accountType);
        Accounts.Add(account);
    }

    private static string GenerateAccountNumber()
    {
        string accountNumber = nextAccountNumber.ToString().PadLeft(10, '0');
        nextAccountNumber++;
        return accountNumber;
    }
}

class Account
{
    private const int SavingsMinimumBalance = 1000;

    public string AccountNumber { get; }
    public AccountType AccountType { get; }
    public decimal Balance { get; private set; }
    public string Note { get; set; }

    public Account(string accountNumber, AccountType accountType)
    {
        AccountNumber = accountNumber;
        AccountType = accountType;
        Balance = 0;
        Note = "";
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (AccountType == AccountType.Savings && Balance - amount < SavingsMinimumBalance)
        {
            return false; // Insufficient balance for savings account
        }

        Balance -= amount;
        return true;
    }

    public bool Transfer(Account destinationAccount, decimal amount)
    {
        if (Withdraw(amount))
        {
            destinationAccount.Deposit(amount);
            return true;
        }

        return false;
    }
}

enum AccountType
{
    Savings,
    Current
}

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        User user1 = new User("Tobi olaranwaju");
        user1.AddAccount(AccountType.Savings);
        user1.Accounts[0].Deposit(10000);
        user1.Accounts[0].Note = "Gift";

        User user2 = new User("David Bukola");
        user2.AddAccount(AccountType.Current);
        user2.Accounts[0].Deposit(100000);
        user2.Accounts[0].Note = "Food";

        bank.AddUser(user1);
        bank.AddUser(user2);

        bank.DisplayAccounts();



    }
}


}
}
