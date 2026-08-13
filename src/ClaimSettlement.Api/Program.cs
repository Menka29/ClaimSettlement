using ClaimSettlement.Application.Interfaces;
using ClaimSettlement.Application.Services;
using ClaimSettlement.Infrastructure.Clients;
using ClaimSettlement.Infrastructure.Repositories;
using ClaimSettlement.Api.Validators;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClaimSettlementService, ClaimSettlementService>();
builder.Services.AddScoped<ClaimSettlementHandler>();
builder.Services.AddSingleton<IPolicyAdminClient, PolicyAdminClientStub>();
builder.Services.AddSingleton<IDecision, DecisionRepository>();
builder.Services.AddValidatorsFromAssemblyContaining<ClaimRequestValidator>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();

