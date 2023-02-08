using AutoMapper;
using Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago.Models;
using Avanade.BestPractices.Infrestructure.Core.Extensions;
using Avanade.BestPractices.Infrestructure.Core.Payments;
using Avanade.BestPractices.Infrestructure.Core.Payments.Models;
using Avanade.BestPractices.Infrestructure.Core.Payments.Requests;
using Avanade.BestPractices.Infrestructure.Core.Payments.Responses;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago.AutoMapper.Profiles
{
    public class MercadoPagoProfile : Profile
    {
        public MercadoPagoProfile()
        {
            CreateMap<PaymentRequest<CreditCard>, Payment>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Value.ConvertToMoney()));

            CreateMap<MercadoPagoPaymentResponse, PaymentResponse>()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => GetProviderName()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => GetPaymentStatus(src.Status)));
        }

        private string GetProviderName()
        {
            return PaymentProviderName.MercadoPago;
        }

        private PaymentStatus GetPaymentStatus(string status)
        {
            return status switch
            {
                MercadoPagoStatus.Approved => PaymentStatus.Approved,
                MercadoPagoStatus.Declined => PaymentStatus.Denied,
                _ => PaymentStatus.Unknown,
            };
        }
    }
}
