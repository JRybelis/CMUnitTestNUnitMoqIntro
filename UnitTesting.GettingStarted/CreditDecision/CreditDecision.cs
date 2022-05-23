//  --------------------------------------------------------------------------------------
// UnitTesting.GettingStarted.CreditDecision.cs
// 2022/05/23
//  --------------------------------------------------------------------------------------

namespace UnitTesting.GettingStarted.Tests.CreditDecision
{
    public class CreditDecision
    {
        private readonly ICreditDecisionService _creditDecisionService;

        public CreditDecision(ICreditDecisionService creditDecisionService)
        {
            _creditDecisionService = creditDecisionService;
        }

        public string MakeCreditDecision(int creditScore)
        {
            return _creditDecisionService.GetDecision(creditScore);
        }
    }
}