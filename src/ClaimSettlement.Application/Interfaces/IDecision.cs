using System.Threading;
using System.Threading.Tasks;
using ClaimSettlement.Application.Models;

namespace ClaimSettlement.Application.Interfaces
{
    public interface IDecision
    {
        Task SaveSettlementDecisionAsync(ClaimSettlementDecision decision, CancellationToken cancellationToken = default);
    }
}
