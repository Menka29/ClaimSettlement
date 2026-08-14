namespace ClaimSettlement.Application.Models
{                   
    public record PolicyDetails
    (
        bool IsActive,
        decimal CoverageLimit
    );
}