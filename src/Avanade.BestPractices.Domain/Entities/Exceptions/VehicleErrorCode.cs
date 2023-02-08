using Avanade.BestPractices.Domain.Entities.Exceptions.Core;

namespace Avanade.BestPractices.Domain.Entities.Exceptions
{
    public class VehicleErrorCode
    {
        private const string Prefix = "V";

        public static HandleErrorCode V001 => new()
        {
            Code = $"{Prefix}-001",
            Description = "Vehicle not found"
        };

        public static HandleErrorCode V002 => new()
        {
            Code = $"{Prefix}-002",
            Description = "Vehicle is unavailable"
        };
    }
}
