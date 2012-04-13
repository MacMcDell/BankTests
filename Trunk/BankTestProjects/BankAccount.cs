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

        public int TransferFunds(BankAccount destination, float amount, BankAccount source)
            {
            if (source.Balance < amount) return 0; // throw new InsufficientFundsException(); 
 if (source.Balance - amount < MinimumBalance) return 0; // throw new InsufficientFundsException();
           
           
 destination.Deposit(amount);
            Withdraw(amount);
            return 1;

            }



        }

    public class InsufficientFundsException : ApplicationException
        {
        public int InF()
        { return 0; }
        }
    }