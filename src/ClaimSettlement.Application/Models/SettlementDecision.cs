namespace ClaimSettlement.Application.Models
{   
    public record SettlementDecision
    (
        string PolicyNumber,
        string StatusReason,
        bool IsApproved
    );
}
