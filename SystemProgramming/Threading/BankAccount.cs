using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming.Threading;

public class BankAccount
{
    private decimal _balance;
    private readonly object _locker = new object();
    private bool _blocked = false;

    public void Block()
    {
        lock (_locker)
        {
            _blocked = true;
            Console.WriteLine("Account BLOCKED");
        }
    }

    public void Unblock()
    {
        lock (_locker)
        {
            _blocked = false;
            Console.WriteLine("Account UNBLOCKED");
        }
    }

    public void Deposit(decimal amount)
    {
        lock (_locker)
        {
            if (_blocked)
                return;

            _balance += amount;
            Console.WriteLine($"Deposit {amount}, balance = {_balance}");
        }
    }

    public void Withdraw(decimal amount)
    {
        lock (_locker)
        {
            if (_blocked)
                return;

            if (_balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Withdraw {amount}, balance = {_balance}");
            }
            else
            {
                Console.WriteLine($"Not enough money to withdraw {amount}");
            }
        }
    }
}