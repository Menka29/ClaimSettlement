namespace ClaimSettlement.Application.Services
{
    using ClaimSettlement.Application.Models;   

    public interface IClaimSettlementService
    {
        SettlementDecision TakeSettlementDecision(PolicyDetails policy, ClaimRequest request);
    }
}

