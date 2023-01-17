using System;

using AutoMapper;

using BART.Exceptions;
using BART.Interfaces;
using BART.Middleware;
using BART.Models.Domain;
using BART.Models.Dto;

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

    public Incident Add(IncidentDto incidentDto)
    {
        var incident = new Incident()
        {
            Description = incidentDto.Description,
            Accounts = _mapper.Map<List<Account>>(incidentDto.Accounts)
        };

        if (incident.Accounts != null && incident.Accounts.Count != 0)
        {
            foreach (var account in incident.Accounts)
            {
                if (!_applicationContext.Accounts.Any(a => a.Name == account.Name))
                {
                    throw new NotFoundException();
                }

                foreach (var contact in account.Contacts)
                {
                    if (_applicationContext.Contacts.Any(c => c.Email == contact.Email))
                    {
                        var contactToUpdate = _applicationContext.Contacts.FirstOrDefault(c => c.Email == contact.Email);

                        //Link contact to account

                        _applicationContext.SaveChanges();
                    }
                }
            }
        }

        _applicationContext.Incidents.Add(incident);
        _applicationContext.SaveChanges();

        return incident;
    }
}

