//  --------------------------------------------------------------------------------------
// UnitTesting.GettingStarted.ICreditDecisionService.cs
// 2022/05/23
//  --------------------------------------------------------------------------------------

namespace UnitTesting.GettingStarted.Tests.CreditDecision
{
    public interface ICreditDecisionService
    {
        string GetDecision(int creditScore);
    }
}