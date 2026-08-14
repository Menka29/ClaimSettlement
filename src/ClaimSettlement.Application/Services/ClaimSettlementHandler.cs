namespace  ClaimSettlement.Application.Services
{
    using ClaimSettlement.Application.Exceptions;
    using ClaimSettlement.Application.Models;
    using ClaimSettlement.Application.Interfaces;

    public class ClaimSettlementHandler
    {
        private readonly IClaimSettlementService _claimSettlementService;
        private readonly IPolicyAdminClient _policyAdminClient;
        private readonly IDecision _decision;

        public ClaimSettlementHandler(IClaimSettlementService claimSettlementService, IPolicyAdminClient policyAdminClient, IDecision decision)
        {
            _claimSettlementService = claimSettlementService;
            _policyAdminClient = policyAdminClient;
            _decision = decision;
        }

        public async Task<SettlementDecision> HandleClaimSettlement(ClaimRequest request, CancellationToken cancellationToken = default)
        {
            var policy = await _policyAdminClient.GetPolicyDetailsAsync(request.PolicyNumber, cancellationToken);

            if (policy == null)
            {
                throw new PolicyNotFoundException(request.PolicyNumber);
            }

            var decision = _claimSettlementService.TakeSettlementDecision(policy, request);

            await _decision.SaveSettlementDecisionAsync(decision, cancellationToken);

            return decision;
        }
    }
}