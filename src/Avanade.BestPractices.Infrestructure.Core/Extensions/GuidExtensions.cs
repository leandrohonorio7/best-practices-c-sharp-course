using System;

namespace Avanade.BestPractices.Infrestructure.Core.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid id)
        {
            return id == Guid.Empty;
        }
    }
}
