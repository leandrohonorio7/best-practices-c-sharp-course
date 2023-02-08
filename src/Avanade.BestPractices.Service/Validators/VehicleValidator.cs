using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Service.Validators.Core;
using FluentValidation;

namespace Avanade.BestPractices.Service.Validators
{
    public class VehicleValidator : EntityValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(x => x.ModelVersionId)
                .NotEmpty();

            RuleFor(x => x.Plate)
                .NotNull();

            RuleFor(x => x.Color)
                .NotNull();

            RuleFor(x => x.Year)
                .NotEmpty();
        }
    }
}
