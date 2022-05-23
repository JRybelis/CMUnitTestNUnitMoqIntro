//  --------------------------------------------------------------------------------------
// UnitTesting.GettingStarted.CreditDecisionService.cs
// 2022/04/23
//  --------------------------------------------------------------------------------------

using System.Threading;

namespace UnitTesting.GettingStarted.Tests.CreditDecision
{
    public class CreditDecisionService : ICreditDecisionService
    {
        public string GetDecision(int creditScore)
        {
            // Simulate a long (2500ms) call to a remote web service:
            Thread.Sleep(2500);

            return creditScore switch
            {
                < 550 => "Declined",
                <= 675 => "Maybe",
                _ => "We look forward to doing business with you!"
            };
        }
    }
}