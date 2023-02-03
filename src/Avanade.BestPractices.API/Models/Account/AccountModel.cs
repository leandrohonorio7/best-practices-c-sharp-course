using System;
using System.ComponentModel.DataAnnotations;

namespace Avanade.BestPractices.API.Models.Account
{
    public class AccountModel
    {
        [Required]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public string DriverLicense { get; set; }
    }
}
