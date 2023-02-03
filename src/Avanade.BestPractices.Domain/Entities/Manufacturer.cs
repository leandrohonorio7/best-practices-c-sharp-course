using Avanade.BestPractices.Infrestructure.Core.Entities;
using System.Collections.Generic;

namespace Avanade.BestPractices.Domain.Entities
{
    public class Manufacturer : EntityBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public List<Model> Models { get; set; }
    }
}
