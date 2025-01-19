using BankAccountManager.Entities.Exceptions;

namespace BankAccountManager.Entities;

public class Account
{
    public int Number { get; set; }
    public string Holder { get; set; }
    public double Balance { get; set; }
    public double WithDrawLimit { get; set; }

    public Account()
    {
    }

    public Account(int number, string holder, double balance, double withDrawLimit)
    {
        Number = number;
        Holder = holder;
        Balance = balance;
        WithDrawLimit = withDrawLimit;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    public void WithDraw(double amount)
    {
        if (Balance <= 0.00)
        {
            throw new DomainException("Withdraw error: No enough balance!");
        }

        if (amount > WithDrawLimit)
        {
            throw new DomainException("Withdraw error: you have no limit!");
        }

        Balance -= amount;
    }
}