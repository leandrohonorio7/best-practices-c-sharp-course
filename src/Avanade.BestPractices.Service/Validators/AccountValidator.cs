using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Infrestructure.Core.Entities.Constants;
using Avanade.BestPractices.Service.Validators.Core;
using FluentValidation;

namespace Avanade.BestPractices.Service.Validators
{
    public class AccountValidator : EntityValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(EntityConfigutarationValueConstant.StringMaxLength);

            RuleFor(x => x.DateOfBirth)
                .NotEmpty();

            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(18);

            RuleFor(x => x.Documents)
                .NotNull();
        }
    }
}
