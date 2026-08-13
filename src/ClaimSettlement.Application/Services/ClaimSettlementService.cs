namespace ClaimSettlement.Application.Services
{
    using ClaimSettlement.Application.Interfaces;
    using ClaimSettlement.Application.Models;
    using System.Threading.Tasks;

    public class ClaimSettlementService : IClaimSettlementService
    { 
        public ClaimSettlementDecision TakeSettlementDecision(PolicyDetails policy, ClaimRequest request)
        {
            // Implementation for taking settlement decision
            decimal threshold = request.AgeYears > 30 ? 1000m : 3000m;
            
            if(!policy.IsActive)
            {
                return new ClaimSettlementDecision
                {
                    PolicyNumber = request.PolicyNumber,
                    Status = "Policy Inactive",
                    IsApproved = false
                };
            }

            if(request.ClaimAmount > policy.CoverageLimit)
            {
                return new ClaimSettlementDecision
                {
                    PolicyNumber = request.PolicyNumber,
                    Status = "Coverage Limit Exceeded",
                    IsApproved = false
                };
            }
            if(request.ClaimAmount > threshold)
            {
                return new ClaimSettlementDecision
                {
                    PolicyNumber = request.PolicyNumber,
                    Status = "Adjuster review Required",
                    IsApproved = false
                };
            }
            return new ClaimSettlementDecision
            {
                PolicyNumber = request.PolicyNumber,
                Status = "Auto-Settled",
                IsApproved = true
            };
        }
    }
}