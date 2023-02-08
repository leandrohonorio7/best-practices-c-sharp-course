using Avanade.BestPractices.Domain.Entities.Exceptions.Core;

namespace Avanade.BestPractices.Domain.Entities.Exceptions
{
    public static class RideErrorCode
    {
        private const string Prefix = "R";

        public static HandleErrorCode R001 => new()
        {
            Code = $"{Prefix}-001",
            Description = "Ride not found"
        };

        public static HandleErrorCode R002 => new()
        {
            Code = $"{Prefix}-002",
            Description = "Ride in progress yet"
        };

        public static HandleErrorCode R003 => new()
        {
            Code = $"{Prefix}-002",
            Description = "Ride already finished"
        };
    }
}
