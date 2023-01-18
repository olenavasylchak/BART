using System;

using AutoMapper;

using BART.Exceptions;
using BART.Interfaces;
using BART.Middleware;
using BART.Models.Domain;
using BART.Models.Dto;

using Microsoft.EntityFrameworkCore;

namespace BART.Services;

public class IncidentService : IIncidentService
{
    private readonly IMapper _mapper;

    private readonly ApplicationContext _applicationContext;

    public IncidentService(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }

    public async Task<IncidentDto> CreateIncidentAsync(CreateIncidentDto incidentDto)
    {
        var account = await _applicationContext.Accounts.FirstOrDefaultAsync(x => x.Name == incidentDto.AccountName);

        if (account == null)
        {
            throw new NotFoundException("Account is not found");
        }

        var contact = await _applicationContext.Contacts.Include(c => c.Accounts).FirstOrDefaultAsync(c => c.Email == incidentDto.ContactEmail);

        if (contact == null)
        {
            var newContact = new Contact()
            {
                FirstName = incidentDto.ContactFirstName,
                LastName = incidentDto.ContactLastName,
                Email = incidentDto.ContactEmail
            };

            await _applicationContext.Contacts.AddAsync(newContact);

            account.Contact = newContact;
        }
        else
        {
            if (contact.Accounts.Any(a => a.Name == incidentDto.AccountName))
            {
                contact.FirstName = incidentDto.ContactFirstName;
                contact.LastName = incidentDto.ContactLastName;
            }
            else
            {
                contact.FirstName = incidentDto.ContactFirstName;
                contact.LastName = incidentDto.ContactLastName;
                contact.Accounts.Add(account);
            }
        }

        var incident = _mapper.Map<Incident>(incidentDto);
        incident.Account = account;

        await _applicationContext.Incidents.AddAsync(incident);
        await _applicationContext.SaveChangesAsync();

        var createdIncidentDto = _mapper.Map<IncidentDto>(incident);
        return createdIncidentDto;
    }
}

