using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Service.Validators.Core;
using FluentValidation;

namespace Avanade.BestPractices.Service.Validators
{
    public class RideValidator : EntityValidator<Ride>
    {
        public RideValidator()
        {
            RuleFor(x => x.VehicleId)
                .NotEmpty();

            RuleFor(x => x.AccountId)
                .NotEmpty();

            RuleFor(x => x.StartAt) 
                .NotEmpty();
        }
    }
}
