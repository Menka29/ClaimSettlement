namespace ClaimSettlement.Application.Models
{                   
    public class PolicyDetails
    {
        public string PolicyNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public decimal CoverageLimit { get; set; }
    }
}