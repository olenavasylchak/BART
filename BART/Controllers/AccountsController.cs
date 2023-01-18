using System;
using System.Net;
using BART.Interfaces;
using BART.Models;
using BART.Models.Dto;
using BART.Services;
using Microsoft.AspNetCore.Mvc;

namespace BART.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AccountDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AccountDto>> Post([FromBody] AccountDto accountDto)
        {
            var result = await _accountService.CreateAccountAsync(accountDto);
            return Ok(result);
        }
    }
}

