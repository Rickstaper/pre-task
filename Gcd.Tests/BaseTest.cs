using System.Collections.Generic;
using NUnit.Framework;

namespace Gcd.Tests
{
    public abstract class BaseTest
    {
        protected List<Data> data = new List<Data>();

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            GCD.CrateJsonData(data);
        }
    }
}
