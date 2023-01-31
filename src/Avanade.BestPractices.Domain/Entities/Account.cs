using Avanade.BestPractices.Infrestructure.Core.Entities;
using System;

namespace Avanade.BestPractices.Domain.Entities
{
    public class Account : EntityBase
    {
        public string Name { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public int DriverLicense { get; set; }
    }
}
