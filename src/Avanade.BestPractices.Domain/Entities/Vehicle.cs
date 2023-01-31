﻿using Avanade.BestPractices.Infrestructure.Core.Entities;
using System;

namespace Avanade.BestPractices.Domain.Entities
{
    public class Vehicle : EntityBase
    {
        public Guid ModelVersionId { get; set; }
        public ModelVersion ModelVersion { get; set; }

        public string Plate { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }
}
