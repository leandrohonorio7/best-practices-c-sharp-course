namespace Avanade.BestPractices.Infrestructure.Core.Extensions
{
    public static class LongExtensions
    {
        public static decimal ConvertToMoney(this long value)
        {
            return value / 100;
        }
    }
}
