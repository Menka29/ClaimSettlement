namespace ClaimSettlement.Api.Controllers
{
    using ClaimSettlement.Application.Models;
    using ClaimSettlement.Application.Services;
    using ClaimSettlement.Application.Exceptions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/claim-settlement")]
    public class ClaimSettlementController : ControllerBase
    {
        private readonly ClaimSettlementHandler _claimSettlementHandler;

        public ClaimSettlementController(ClaimSettlementHandler claimSettlementHandler)
        {
            _claimSettlementHandler = claimSettlementHandler;
        }

        [HttpPost]
        public async Task<IActionResult> SettleClaim(ClaimRequest request, CancellationToken cancellationToken = default)
        {
                var decision = await _claimSettlementHandler.HandleClaimSettlement(request);
                return Ok(decision);

        }
    }
}