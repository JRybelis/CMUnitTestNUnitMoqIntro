//  --------------------------------------------------------------------------------------
// UnitTesting.GettingStarted.Tests.CreditDecisionTests.cs
// 2022/05/23
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using UnitTesting.GettingStarted.Tests.CreditDecision;

namespace UnitTesting.GettingStarted.Tests.CreditDecisionTests
{
    [TestFixture]
    public class CreditDecisionTests
    {
        public static IEnumerable<TestCaseData> CreditDecisionTestData
        {
            get
            {
                yield return new TestCaseData(100, "Declined");
                yield return new TestCaseData(549, "Declined");
                yield return new TestCaseData(550, "Maybe");
                yield return new TestCaseData(674, "Maybe");
                yield return new TestCaseData(675, "We look forward to doing business with you!");
            }
        }
        Mock<ICreditDecisionService> mockCreditDecisionService;
        private CreditDecision.CreditDecision systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            mockCreditDecisionService = new Mock<ICreditDecisionService>(MockBehavior.Strict);
        }

        [TestCaseSource(typeof(CreditDecisionTests), nameof(CreditDecisionTestData))]
        public void MakeCreditDecision_Always_ReturnsExpectedResult(int creditScore, string expectedResult)
        {
            mockCreditDecisionService.Setup(p => p.GetDecision(creditScore)).Returns(expectedResult);

            systemUnderTest = new CreditDecision.CreditDecision(mockCreditDecisionService.Object);
            var result = systemUnderTest.MakeCreditDecision(creditScore);
            
            Assert.That(result, Is.EqualTo(expectedResult));
            
            mockCreditDecisionService.VerifyAll();
        }
    }
}