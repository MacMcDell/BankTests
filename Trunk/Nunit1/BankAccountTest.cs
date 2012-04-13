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
           
        }


        [Test]
        public void TransferFunds()
        {

        //    source.Deposit(200.00F);
        //    destination.Deposit(150.00F);

            source.TransferFunds(destination, 100.00F);
            Assert.AreEqual(250.00F, destination.Balance);
            Assert.AreEqual(100.00F, source.Balance);
        }

        [Test]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void TransferWithInsufficientFunds()
        {
        //    BankAccount source = new BankAccount();
        //    source.Deposit(250.00F);
       //     BankAccount destination = new BankAccount();
       //     destination.Deposit(150.00F);
            source.TransferFunds(destination, 300.00F);
        }
        [Test]
        public void onePlusOneTest()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void onePlusOneTestA()
        {
            Assert.AreEqual(1, 1);
        }


        [Test]
     // [Ignore("Check the logic of the transfer funds method")]
        public void TransferWithInsufficientFundsAtomicity()
        {
        //    BankAccount source = new BankAccount();
        //    source.Deposit(200.00F);
        //    BankAccount destination = new BankAccount();
        //    destination.Deposit(150.00F);
            try
            {
                source.TransferFunds(destination, 300.00F);
            }
            catch (InsufficientFundsException expected)
            {
            }

            Assert.AreEqual(200.00F, source.Balance);
            Assert.AreEqual(150.00F, destination.Balance);

        }
    }
}