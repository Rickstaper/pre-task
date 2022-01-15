using NUnit.Framework;
using System;

namespace Gcd.Tests
{
    public class TestAlgorithmByEuclidean
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
            return GCD.GetGcdByEuclidean(a, b, out spendTime);
        }

        [Test]
        public void GetGcdWithTwoParameters_ThrowArgumentException() => Assert.Throws<ArgumentException>(() => GCD.GetGcdByEuclidean(0, 0), "Throwed argument exception because method containt zero argument");

        [TestCase(1, 1, 1, ExpectedResult = 1)]
        [TestCase(10, 14, 2, ExpectedResult = 2)]
        [TestCase(55, 70, 55, ExpectedResult = 5)]
        [TestCase(100, -100, 50, ExpectedResult = 50)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        [TestCase(100, 16, 8, ExpectedResult = 4)]
        [TestCase(96, 16, 32, ExpectedResult = 16)]
        [TestCase(-15, 5, 45, ExpectedResult = 5)]
        [TestCase(-100, -16, -8, ExpectedResult = 4)]
        [TestCase(96, -16, 32, ExpectedResult = 16)]
        public int GetGcdWithThreeParameters(int a, int b, int c)
        {
            return GCD.GetGcdByEuclidean(a, b, c);
        }

        [Test]
        public void GetGcdWithThreeParameters_ThrowArgumentException() => Assert.Throws<ArgumentException>(() => GCD.GetGcdByEuclidean(0, 0, 0), "Throwed argument exception because method containt zero argument");

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine($"Method:{this.GetType()}\nSpend time:{this.spendTime}");
        }
    }
}