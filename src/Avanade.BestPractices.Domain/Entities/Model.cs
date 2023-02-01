using Avanade.BestPractices.Infrestructure.Core.Entities;
using System;
using System.Collections.Generic;

namespace Avanade.BestPractices.Domain.Entities
{
    public class Model : EntityBase
    {
        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public string Name { get; set; }

        public List<ModelVersion> ModelVersions { get; set; }
    }
}
