using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankTestProjects
{
    public class BankAccount
    {
        public float Balance
        { get; set; }

        public float MinimumBalance
        { get; set; }

        public void Deposit(float Amount)
        {
            Balance += Amount;
        }

        public void Withdraw(float Amount)
        {
            Balance -= Amount;
        }

        public void TransferFunds(BankAccount destination, float amount)
        {
            destination.Deposit(amount);
            if (Balance - amount < MinimumBalance)
                throw new InsufficientFundsException();

            Withdraw(amount);
        }



    }

    public class InsufficientFundsException : ApplicationException
    {
    
    
    }
}