namespace  ClaimSettlement.Application.Exceptions
{
    using System;

    public class PolicyNotFoundException : Exception
    {
        public PolicyNotFoundException(string policyNumber)
            : base($"Policy with number '{policyNumber}' was not found.")
        {
        }
    }
}