namespace ClaimSettlement.Application.Services
{
    using ClaimSettlement.Application.Models;   

    public interface IClaimSettlementService
    {
        ClaimSettlementDecision TakeSettlementDecision(PolicyDetails policy, ClaimRequest request);
    }
}

