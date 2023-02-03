using AutoMapper;
using Avanade.BestPractices.API.Models.Account;
using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Avanade.BestPractices.API.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService,
            IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var account = _mapper.Map<AccountModel, Account>(model);
            await _accountService.AddAsync(account);

            return Ok();
        }
    }
}
