using ClaimSettlement.Application.Services;
using ClaimSettlement.Application.Models;
using FluentAssertions;

namespace ClaimSettlement.Tests;

public class ClaimSettlementServiceTests
{
    [Fact]
    public void AutoSettled_Path()
    {
        var service = new ClaimSettlementService();

        var result = service.TakeSettlementDecision(
            new PolicyDetails( true, 10000),
            new ClaimRequest("POL1", 2500, 10)
        );

        result.IsApproved.Should().BeTrue();
        result.StatusReason.Should().Be("Auto-Settled");


    }

    [Fact]
    public void CoverageLimit_Exceeded_Path()
    {
        var service = new ClaimSettlementService();

        var result = service.TakeSettlementDecision(
            new PolicyDetails (true, 1000),
            new ClaimRequest("POL2", 1500, 10)
        );

        result.IsApproved.Should().BeFalse();
        result.StatusReason.Should().Be("Coverage Limit Exceeded");
    }
}
