using Avanade.BestPractices.Infrestructure.Core.Entities;
using System;
using System.Collections.Generic;

namespace Avanade.BestPractices.Domain.Entities
{
    public class Account : EntityBase
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsApproved { get; set; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age))
                    age--;

                return age;
            }
        }

        public List<Document> Documents { get; set; }
        public List<Ride> Rides { get; set; }
    }
}
