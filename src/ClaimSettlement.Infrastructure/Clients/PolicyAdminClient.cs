namespace ClaimSettlement.Infrastructure.Clients
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using ClaimSettlement.Application.Models;
    using ClaimSettlement.Application.Interfaces;
    using ClaimSettlement.Application.Exceptions;

    public class PolicyAdminClient : IPolicyAdminClient
    {
        private readonly HttpClient _httpClient;

        public PolicyAdminClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PolicyDetails?> GetPolicyDetailsAsync(string policyNumber, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetAsync($"policies/{policyNumber}", cancellationToken);
            
                if (response.IsSuccessStatusCode)
                {
                    var policy = await response.Content.ReadFromJsonAsync<PolicyDetails>(cancellationToken: cancellationToken);
                    if(policy is null)
                        throw new PolicyDependencyException();
                    return policy;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new PolicyDependencyException();
                }
            }
            catch (HttpRequestException)
            {
                throw new PolicyDependencyException();
            }
        }  
    }
}