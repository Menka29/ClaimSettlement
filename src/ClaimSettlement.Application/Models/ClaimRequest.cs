
namespace ClaimSettlement.Application.Models
{
public class ClaimRequest
{   public string PolicyNumber { get; set; } = string.Empty;
    public decimal ClaimAmount { get; set; }
    public int AgeYears { get; set; }
}
}