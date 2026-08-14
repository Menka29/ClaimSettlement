namespace ClaimSettlement.Api.Validators
{
    using ClaimSettlement.Application.Models;
    using FluentValidation; 

    public class ClaimRequestValidator : AbstractValidator<ClaimRequest>
    {
        public ClaimRequestValidator()
        {
            RuleFor(request => request.PolicyNumber)
                .NotEmpty().WithMessage("Policy number is required.");

            RuleFor(request => request.ClaimAmount)
                .GreaterThan(0).WithMessage("Claim amount must be greater than zero.");

            RuleFor(request => request.PropertyAgeYears)
                .GreaterThanOrEqualTo(0).WithMessage("Age must be a positive number.") ;
        }
    }
}