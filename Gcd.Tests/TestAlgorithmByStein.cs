using NUnit.Framework;
using System;

namespace Gcd.Tests
{
    public class TestAlgorithmByStein : BaseTest
    {
        private TimeSpan spendTime;

        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(10, 14, ExpectedResult = 2)]
        [TestCase(55, 70, ExpectedResult = 5)]
        [TestCase(1400, 2222, ExpectedResult = 2)]
        [TestCase(20, 44, ExpectedResult = 4)]
        [TestCase(100, 16, ExpectedResult = 4)]
        [TestCase(96, 16, ExpectedResult = 16)]
        [TestCase(-20, 44, ExpectedResult = 4)]
        [TestCase(-100, -16, ExpectedResult = 4)]
        [TestCase(96, -16, ExpectedResult = 16)]
        public int GetGcdWithTwoParameters(int a, int b)
        {
            return GCD.GetGcdByStein(a, b, out spendTime);
        }

        [TearDown]
        public void TearDown()
        {
            data.Add(new Data(this.GetType().ToString(), this.spendTime.ToString()));

            Console.WriteLine($"Method:{this.GetType()}\nSpend time:{this.spendTime}");
        }
    }
}
