using System;

using AutoMapper;

using BART.Interfaces;
using BART.Models.Domain;
using BART.Models.Dto;

namespace BART.Services;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;

    private readonly ApplicationContext _applicationContext;

	public AccountService(ApplicationContext applicationContext, IMapper mapper)
	{
		_applicationContext = applicationContext;
        _mapper = mapper;
	}

    public async Task<AccountDto> CreateAccountAsync(CreateAccountDto accountDto)
    {
        var account = _mapper.Map<Account>(accountDto);

        await _applicationContext.Accounts.AddAsync(account);
        await _applicationContext.SaveChangesAsync();

        var createdAccountDto = _mapper.Map<AccountDto>(account);
        return createdAccountDto;
    }
}

