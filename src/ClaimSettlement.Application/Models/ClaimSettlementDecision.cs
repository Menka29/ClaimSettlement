namespace ClaimSettlement.Application.Models
{   
    public class ClaimSettlementDecision
    {
        public string PolicyNumber { get; set; }
        public string Status { get; set; }
        public bool IsApproved { get; set; }
    }
}
