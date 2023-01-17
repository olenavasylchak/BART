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

    public Account Add(AccountDto accountDto)
    {
        var account = new Account()
        {
            Id = accountDto.Id,
            Name = accountDto.Name,
            Contacts = _mapper.Map<List<Contact>>(accountDto.Contacts)
        };

        _applicationContext.Accounts.Add(account);
        _applicationContext.SaveChanges();

        return account;
    }
}

