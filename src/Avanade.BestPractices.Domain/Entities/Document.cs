using Avanade.BestPractices.Domain.Entities.Enums;
using Avanade.BestPractices.Infrestructure.Core.Entities;
using System;
using System.Collections.Generic;

namespace Avanade.BestPractices.Domain.Entities
{
    public class Document : EntityBase
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public DocumentType Type { get; set; }
        public string Number { get; set; }

        public List<DocumentParameter> DocumentParameters { get; set; }
    }
}
