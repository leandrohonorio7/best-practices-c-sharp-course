using Avanade.BestPractices.Infrestructure.Core.Entities;
using System;
using System.Collections.Generic;

namespace Avanade.BestPractices.Domain.Entities
{
    public class ModelVersion : EntityBase
    {
        public Guid ModelId { get; set; }
        public Model Model { get; set; }

        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
