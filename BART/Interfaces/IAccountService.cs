using System;

using BART.Models.Domain;
using BART.Models.Dto;

namespace BART.Interfaces
{
	public interface IAccountService
	{
        Task<AccountDto> CreateAccountAsync(CreateAccountDto accountDto);
    }
}

