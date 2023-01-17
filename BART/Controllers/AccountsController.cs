using System;

using BART.Interfaces;
using BART.Models;
using BART.Models.Dto;
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
        public IActionResult Post([FromBody]AccountDto accountDto)
        {
            if (accountDto == null)
            {
                return BadRequest("Account is null.");
            }

            var result = _accountService.Add(accountDto);
            return Ok(result);
        }
    }
}

