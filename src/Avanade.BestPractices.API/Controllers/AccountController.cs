using AutoMapper;
using Avanade.BestPractices.API.Models.Account;
using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Interfaces.Services;
using Avanade.BestPractices.Infrestructure.Core.Entities.Exceptions;
using Avanade.BestPractices.Infrestructure.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorCodeResponse),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] AccountModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var account = _mapper.Map<AccountModel, Account>(model);
            await _accountService.AddAsync(account);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(AccountModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorCodeResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (id.IsEmpty())
                return BadRequest();

            var account = await _accountService.GetByIdAsync(id);
            if (account == null)
                return NotFound();

            var model = _mapper.Map<Account, AccountModel>(account);
            return Ok(model);
        }
    }
}
