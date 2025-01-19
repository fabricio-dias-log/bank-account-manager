using System.Globalization;
using BankAccountManager.Entities;
using BankAccountManager.Entities.Exceptions;

namespace BankAccountManager;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter account data:");

        try
        {
            Console.Write("Number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Holder: ");
            string accountHolder = Console.ReadLine();

            Console.Write("Initial balance: ");
            double accountBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Withdraw limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account account = new Account(accountNumber, accountHolder, accountBalance, withdrawLimit);

            Console.WriteLine();
            Console.Write("Enter amount for withdraw: ");
            double withdrawAmount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            account.WithDraw(withdrawAmount);

            Console.WriteLine($"New balance: {account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        catch (DomainException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Format error: {e.Message}");
        }
    }
}