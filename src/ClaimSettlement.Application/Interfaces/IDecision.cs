
using ClaimSettlement.Application.Models;

namespace ClaimSettlement.Application.Interfaces
{
    public interface IDecision
    {
        Task SaveSettlementDecisionAsync(SettlementDecision decision, CancellationToken cancellationToken = default);
    }
}
