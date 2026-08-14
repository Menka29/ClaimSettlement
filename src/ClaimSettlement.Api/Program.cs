using ClaimSettlement.Application.Interfaces;
using ClaimSettlement.Application.Services;
using ClaimSettlement.Infrastructure.Clients;
using ClaimSettlement.Infrastructure.Repositories;
using ClaimSettlement.Api.Validators;
using ClaimSettlement.Api.Middleware;
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
/*builder.Services.AddHttpClient<IPolicyAdminClient, PolicyAdminClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["PolicyAdminApi:BaseUrl"]!); // Replace with the actual base URL of the Policy Admin API
});*/


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();

