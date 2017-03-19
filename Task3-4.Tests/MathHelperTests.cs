using System;
using NUnit.Framework;

namespace Task3_4.Tests
{
    public class MathHelperTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int NextBiggerNumber_NextBiggerNumberOfNumberDigits(int number)
        {
            return MathHelper.NextBiggerNumber(number);
        }

        [TestCase(-3)]
        [TestCase(0)]
        [TestCase(-12)]
        [TestCase(-23456)]
        public void NextBiggerNumber_ThrowsArgumentNullException(int number)
        {
            Assert.Throws<ArgumentException>(() => MathHelper.NextBiggerNumber(number));
        }
    
        [TestCase(4, 2, ExpectedResult = 2)]
        [TestCase(254803968, 5, 0.00000000001, ExpectedResult = 48)]
        [TestCase(39.0625, 4, 0.00000001, ExpectedResult = 2.5)]
        [TestCase(35.937, 3, 0.00000000001, ExpectedResult = 3.3)]
        public double SqrtN_RootOfRootDegreeOfNumber(double number, int rootDegree, double eps = 0.0001)
        {
            return MathHelper.SqrtN(number, rootDegree, eps);
        }

        [TestCase(-5432, 4)]
        [TestCase(-5432, -3)]
        [TestCase(444, -4)]
        [TestCase(843, 0)]
        [TestCase(0, 0)]
        [TestCase(25, 3, 1)]
        [TestCase(-25, 3, 0)]
        [TestCase(25, -3, -1)]
        [TestCase(25, 3, 231)]
        public void SqrtN_ThrowsArgumentException(double number, int rootDegree, double eps = 0.0001)
        {
            Assert.Throws<ArgumentException>(() => MathHelper.SqrtN(number, rootDegree, eps));
        }
    }
}