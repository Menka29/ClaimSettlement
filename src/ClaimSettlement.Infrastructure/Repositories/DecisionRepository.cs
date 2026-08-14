using ClaimSettlement.Application.Models;
using ClaimSettlement.Application.Interfaces;

namespace ClaimSettlement.Infrastructure.Repositories
{
    public class DecisionRepository : IDecision
    {
        private readonly List<SettlementDecision> _decisions;

        public DecisionRepository()
        {
            _decisions = new List<SettlementDecision>();
        }

        public Task SaveSettlementDecisionAsync(SettlementDecision decision, CancellationToken cancellationToken = default)
        {
            _decisions.Add(decision);
            return Task.CompletedTask;
        }
    }
}