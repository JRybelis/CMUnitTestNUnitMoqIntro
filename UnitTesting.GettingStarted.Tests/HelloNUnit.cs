//  --------------------------------------------------------------------------------------
// UnitTesting.GettingStarted.Tests.HelloNunit.cs
// 2022/05/23
//  --------------------------------------------------------------------------------------

using NUnit.Framework;

namespace UnitTesting.GettingStarted.Tests
{
    [TestFixture]
    public class HelloNUnit
    {
        [Test]
        public void TestHelloNUnit()
        {
            Assert.That(true, Is.False);
        }
    }
}