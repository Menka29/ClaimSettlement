
namespace ClaimSettlement.Application.Models
{
public record ClaimRequest
(   string PolicyNumber,
     decimal ClaimAmount,
     int PropertyAgeYears
);

}