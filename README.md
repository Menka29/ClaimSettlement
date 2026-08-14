Claim Settlement Decision API

## Overview 
Implements ASP.Net Core web API that evaluates home insurance claims for automatic settlement based on policy details and business rules

## Technology
- ASP.NET Core Web API
- C#
- FluentAssertions
- FluentValidations

## Solution structure

ClaimSettlement Api - HTTP API, validation, Middleware, configuration
ClaimSettlement Application - Business Rules, Models, Interfaces, Services
ClaimSettlement Infrastructure - External dependency and Repository implementations
ClaimSettlement.Tests - Unit tests

## How To Run
1. Clone the repository - git clone
2. Open the solution - cd ClaimSettlement
3. Restore NuGet Packages - dotnet restore
4. Run the application - dotnet run --project src/ClaimSettlement.Api

## API Endpoint
POST /api/claim-settlement

## Design Decisions
1. clean Sepeartion of Domian/Application/Infrastructure
2. External dependency hidden behind interface and is simulated via test double.
3. Decision recording abstracted behind repository
4. FluentValidation for Request validation
5. Full cancellation token propogation

## Assumptions

1. Policy Not found returns HTTP 404
2. Policy dependency failures return HTTP 400 Bad Request 
3. Policy Admin System is simulated through test double and is not implemented as sepearte service.




