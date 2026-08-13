
using System.Threading;
using System.Threading.Tasks;
using ClaimSettlement.Application.Models;
namespace ClaimSettlement.Application.Interfaces
{
    public interface IPolicyAdminClient
    {
        Task<PolicyDetails> GetPolicyDetailsAsync(string policyNumber, CancellationToken cancellationToken);
    }
}