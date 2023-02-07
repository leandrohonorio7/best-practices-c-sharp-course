using AutoMapper;
using Avanade.BestPractices.API.Models.Charge;
using Avanade.BestPractices.Infrestructure.Core.Payments;
using Avanade.BestPractices.Infrestructure.Core.Payments.Models;
using Avanade.BestPractices.Infrestructure.Core.Payments.Requests;
using Avanade.BestPractices.Infrestructure.Core.Payments.Responses;
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
        private readonly IPaymentProvider _paymentProvider;
        private readonly IMapper _mapper;

        public ChargeController(IPaymentProvider paymentProvider,
            IMapper mapper)
        {
            _paymentProvider = paymentProvider;
            _mapper = mapper;
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay([FromBody] CreditCardModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var creditCard = _mapper.Map<CreditCardModel, CreditCard>(model);

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

            var paymentResponse = await _paymentProvider.MakePaymentAsync(payment);
            var response = _mapper.Map<PaymentResponse, PaymentModel>(paymentResponse);
            return Ok(response);
        }
    }
}
