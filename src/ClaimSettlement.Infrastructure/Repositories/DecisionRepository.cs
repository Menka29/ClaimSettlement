using ClaimSettlement.Application.Models;
using ClaimSettlement.Application.Interfaces;

namespace ClaimSettlement.Infrastructure.Repositories
{
    public class DecisionRepository : IDecision
    {
        private readonly List<ClaimSettlementDecision> _decisions;

        public DecisionRepository()
        {
            _decisions = new List<ClaimSettlementDecision>();
        }

        public Task SaveSettlementDecisionAsync(ClaimSettlementDecision decision, CancellationToken cancellationToken = default)
        {
            _decisions.Add(decision);
            return Task.CompletedTask;
        }
    }
}