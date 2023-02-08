using Avanade.BestPractices.Domain.Entities.Exceptions.Core;

namespace Avanade.BestPractices.Domain.Entities.Exceptions
{
    public static class AccountErrorCode
    {
        private const string Prefix = "A";

        public static HandleErrorCode A001 => new()
        {
            Code = $"{Prefix}-001",
            Description = "Account not found"
        };

        public static HandleErrorCode A002 => new()
        {
            Code = $"{Prefix}-002",
            Description = "Account is not approved"
        };
    }
}
