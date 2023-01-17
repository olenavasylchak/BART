using System;

using BART.Interfaces;
using BART.Models.Domain;
using BART.Models.Dto;

namespace BART.Services;

	public class ContactService : IContactService
	{
    private readonly ApplicationContext _applicationContext;

    public ContactService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public Contact Add(ContactDto contactDto)
    {
        var contact = new Contact()
        {
            Id = contactDto.Id,
            FirstName = contactDto.FirstName,
            LastName = contactDto.LastName,
            Email = contactDto.Email
        };

        _applicationContext.Contacts.Add(contact);
        _applicationContext.SaveChanges();

        return contact;
    }
}

