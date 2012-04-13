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

        public int TransferFunds(BankAccount destination, float amount)
        {
            destination.Deposit(amount);
            if (Balance - amount < MinimumBalance)
                {
               
                return 0; 
                throw new InsufficientFundsException();
                }

            Withdraw(amount);
            return 1;
        }



    }

    public class InsufficientFundsException : ApplicationException
    {
        
    }
}