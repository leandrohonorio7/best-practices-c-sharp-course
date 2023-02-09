using AutoMapper;
using Avanade.BestPractices.API.Models.Charge;
using Avanade.BestPractices.Infrestructure.Core.Entities.Exceptions;
using Avanade.BestPractices.Infrestructure.Core.Payments;
using Avanade.BestPractices.Infrestructure.Core.Payments.Models;
using Avanade.BestPractices.Infrestructure.Core.Payments.Requests;
using Avanade.BestPractices.Infrestructure.Core.Payments.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.BestPractices.API.Controllers
{
    [ApiController]
    [Route("charges")]
    public class ChargeController : ControllerBase
    {
        private readonly IPaymentProvider _paymentProviderMercadoPago;
        private readonly IPaymentProvider _paymentProviderPayPal;
        private readonly IMapper _mapper;

        public ChargeController(PaymentProviderResolver paymentProviderResolver,
            IMapper mapper)
        {
            _paymentProviderMercadoPago = paymentProviderResolver(PaymentProviderName.MercadoPago);
            _paymentProviderPayPal = paymentProviderResolver(PaymentProviderName.PayPal);
            _mapper = mapper;
        }

        [HttpPost("pay")]
        [ProducesResponseType(typeof(PayResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorCodeResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Pay([FromBody] PayRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var creditCard = _mapper.Map<CreditCardModel, CreditCard>(request.CreditCard);
            var payment = new PaymentRequest<CreditCard>
            {
                Currency = "BRL",
                Items = new List<PaymentItem>()
                {
                    new PaymentItem
                    {
                        Description = "Corrida realizada",
                        Quantity = 1,
                        Total = 10000
                    }
                },
                StoreReferenceId = Guid.NewGuid().ToString(),
                Data = creditCard
            };

            var paymentResponse = await MakePaymentAsync(request.PaymentProvider, payment);
            var response = _mapper.Map<PaymentResponse, PayResponse>(paymentResponse);
            return Ok(response);
        }

        private Task<PaymentResponse> MakePaymentAsync(string provider, PaymentRequest<CreditCard> payment)
        {
            return provider switch
            {
                PaymentProviderName.MercadoPago => _paymentProviderMercadoPago.MakePaymentAsync(payment),
                PaymentProviderName.PayPal => _paymentProviderPayPal.MakePaymentAsync(payment),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
