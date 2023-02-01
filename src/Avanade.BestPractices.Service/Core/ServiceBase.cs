using Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces;

namespace Avanade.BestPractices.Service.Core
{
    public class ServiceBase<T> : IService<T> where T : IEntity
    {

    }
}
