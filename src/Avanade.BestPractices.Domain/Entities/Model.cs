using Avanade.BestPractices.Infrestructure.Core.Entities;
using System;

namespace Avanade.BestPractices.Domain.Entities
{
    public class Model : EntityBase
    {
        public Guid ManufactureId { get; set; }
        public Manufacture Manufacture { get; set; }

        public string Name { get; set; }
    }
}
