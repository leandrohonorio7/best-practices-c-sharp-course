using AutoMapper;
using Avanade.BestPractices.API.Models.Account;
using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Entities.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.BestPractices.API.Infrasctructure.AutoMapper.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountModel, Account>()
                .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => SetDriverLicense(src.DriverLicense)));

            CreateMap<Account, AccountModel>()
                .ForMember(dest => dest.DriverLicense, opt => opt.MapFrom(src => GetDriverLicense(src.Documents)));
        }

        private List<Document> SetDriverLicense(string driverLicense)
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

        private string GetDriverLicense(List<Document> documents)
        {
            return documents?.FirstOrDefault(x => x.Type == DocumentType.DriverLicense)?.Number;
        }
    }
}
