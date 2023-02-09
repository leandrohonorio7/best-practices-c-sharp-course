using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Service.Validators.Core;
using FluentValidation;

namespace Avanade.BestPractices.Service.Validators
{
    public class ChargeValidator : EntityValidator<Charge>
    {
        public ChargeValidator()
        {
            RuleFor(x => x.Description)
                .NotNull();

            RuleFor(x => x.GrossValue.Value)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.DiscountValue.Value)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.NetValue.Value)
                .GreaterThanOrEqualTo(0);
        }
    }
}
