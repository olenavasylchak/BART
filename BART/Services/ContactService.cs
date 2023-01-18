using System;
using AutoMapper;
using BART.Interfaces;
using BART.Models.Domain;
using BART.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace BART.Services;

	public class ContactService : IContactService
	{
    private readonly IMapper _mapper;

    private readonly ApplicationContext _applicationContext;

    public ContactService(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }

    public async Task<ContactDto> CreateContactAsync(ContactDto contactDto)
    {
        var contact = _mapper.Map<Contact>(contactDto);
        await _applicationContext.Contacts.AddAsync(contact);
        await _applicationContext.SaveChangesAsync();
        var createdContactDto = _mapper.Map<ContactDto>(contact);
        return createdContactDto;
    }
}

