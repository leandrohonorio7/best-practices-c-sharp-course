using AutoMapper;
using Avanade.BestPractices.API.Models.Charge;
using Avanade.BestPractices.Infrestructure.Core.Payments.Models;
using Avanade.BestPractices.Infrestructure.Core.Payments.Responses;

namespace Avanade.BestPractices.API.Infrasctructure.AutoMapper.Profiles
{
    public class ChargeProfile : Profile
    {
        public ChargeProfile()
        {
            CreateMap<CreditCardModel, CreditCard>();
            
            CreateMap<PaymentResponse, PayResponse>();
        }
    }
}
