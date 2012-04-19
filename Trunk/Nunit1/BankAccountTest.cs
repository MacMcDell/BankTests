using System;



namespace BankTestProjects
{
    using NUnit.Framework;
    [TestFixture]

    public class BankAccountTest
    {
        BankAccount source;
        BankAccount destination;

        [SetUp]
        public void Init()
        {
            source = new BankAccount();
            source.Deposit(200.00F);
            destination = new BankAccount();
            destination.Deposit(150.00F);
            destination.MinimumBalance = 100.00F;
            source.MinimumBalance = 50.00F;

           
        }


        [Test]
        public void TransferFunds()
        {

        //    source.Deposit(200.00F);
        //    destination.Deposit(150.00F);

        Assert.AreEqual(source.TransferFunds(destination, 100.00F,source),1);
            Assert.AreEqual(250.00F, destination.Balance);
            Assert.AreEqual(100.00F, source.Balance);


        }

        [Test]
       // [ExpectedException(typeof(InsufficientFundsException))]
        public void TransferWithInsufficientFunds()
        {
        //    BankAccount source = new BankAccount();
        //    source.Deposit(250.00F);
       //     BankAccount destination = new BankAccount();
       //     destination.Deposit(150.00F);
        Assert.AreEqual(source.TransferFunds(destination, 300.00F, source), 0);
        Assert.AreEqual(source.TransferFunds(destination, 150.00F, source), 1);
        }
     

        [Test]
   //   [Ignore("Check the logic of the transfer funds method")]
        public void TransferWithInsufficientFundsAtomicity()
        {
        //    BankAccount source = new BankAccount();
        //    source.Deposit(200.00F);
        //    BankAccount destination = new BankAccount();
        //    destination.Deposit(150.00F);
            try
            {
            source.TransferFunds(destination, 300.00F, source);
            }
            catch (InsufficientFundsException expected)
                {
                int Val = expected.InF();
                Assert.AreEqual(Val,0);
            }

            Assert.AreEqual(200.00F, source.Balance);
            Assert.AreEqual(150.00F, destination.Balance);
           

        }

        

    }
}