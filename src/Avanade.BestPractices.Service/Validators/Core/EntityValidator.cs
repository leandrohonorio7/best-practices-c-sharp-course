using Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces;
using FluentValidation;

namespace Avanade.BestPractices.Service.Validators.Core
{
    public class EntityValidator<T> : AbstractValidator<T> where T : IEntity
    {

    }
}
