using System.Collections.Generic;

namespace Avanade.BestPractices.Domain.ValueObjects
{
    public class Money : Core.ValueObject
    {
        public long Value { get; set; }
        public string Currency { get; set; }

        public Money(long value, string currency)
        {
            Currency = currency;
            Value = value;
        }

        public Money()
        {

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Currency;
            yield return Value;
        }

        public static Money operator *(Money value, int quantity)
        {
            return new Money
            {
                Value = value.Value * quantity,
                Currency = value.Currency
            };
        }

        public static Money operator -(Money a, Money b)
        {
            return new Money
            {
                Value = a.Value - b.Value,
                Currency = a.Currency ?? b.Currency
            };
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money
            {
                Value = a.Value + b.Value,
                Currency = a.Currency ?? b.Currency
            };
        }
    }
}
