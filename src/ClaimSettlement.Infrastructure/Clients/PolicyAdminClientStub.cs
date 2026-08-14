using ClaimSettlement.Application.Models;
using ClaimSettlement.Application.Interfaces;

namespace ClaimSettlement.Infrastructure.Clients
{
    public class PolicyAdminClientStub : IPolicyAdminClient
    {
        public Task<PolicyDetails?> GetPolicyDetailsAsync(string policyNumber, CancellationToken cancellationToken = default)
        {
            // Simulate an API call to get policy details
            return Task.FromResult<PolicyDetails?>(new PolicyDetails(true, 10000m));
            //return Task.FromResult<PolicyDetails?>(null);
        }
    }
}