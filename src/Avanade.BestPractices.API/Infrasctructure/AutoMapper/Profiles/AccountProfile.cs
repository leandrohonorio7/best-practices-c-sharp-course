using AutoMapper;
using Avanade.BestPractices.API.Models.Account;
using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Entities.Enums;
using System.Collections.Generic;

namespace Avanade.BestPractices.API.Infrasctructure.AutoMapper.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountModel, Account>()
                .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => SetDriveLicense(src.DriverLicense)));
        }

        private List<Document> SetDriveLicense(string driverLicense)
        {
            return new List<Document>
            {
                new Document
                {
                    Number = driverLicense,
                    Type = DocumentType.DriverLicense
                }
            };
        }
    }
}
