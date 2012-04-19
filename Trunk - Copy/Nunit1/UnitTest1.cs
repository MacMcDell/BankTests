using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace Nunit1
{
    using NUnit.Framework;

    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
