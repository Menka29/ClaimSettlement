namespace ClaimSettlement.Application.Services
{
    using ClaimSettlement.Application.Interfaces;
    using ClaimSettlement.Application.Models;
    using System.Threading.Tasks;

    public class ClaimSettlementService : IClaimSettlementService
    { 
        public SettlementDecision TakeSettlementDecision(PolicyDetails policy, ClaimRequest request)
        {
            // Implementation for taking settlement decision
            decimal threshold = request.PropertyAgeYears > 30 ? 1000m : 3000m;
            
            if(!policy.IsActive)
            {
                return new SettlementDecision
                (
                    request.PolicyNumber,
                    "Policy Inactive",
                    false
                );
            }

            if(request.ClaimAmount > policy.CoverageLimit)
            {
                return new SettlementDecision
                (
                    request.PolicyNumber,
                    "Coverage Limit Exceeded",
                    false
                );
            }
            if(request.ClaimAmount > threshold)
            {
                return new SettlementDecision (
                    request.PolicyNumber,
                    "Adjuster Review Required",
                    false
                );
            }
            return new SettlementDecision
            (
                request.PolicyNumber,
                "Auto-Settled",
                true
            );
        }
    }
}