using Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces;
using System;

namespace Avanade.BestPractices.Infrestructure.Core.Entities
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
