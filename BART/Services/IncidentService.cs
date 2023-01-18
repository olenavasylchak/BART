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

    public async Task<IncidentDto> CreateIncidentAsync(IncidentDto incidentDto)
    {
        var incident = _mapper.Map<Incident>(incidentDto);

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

        await _applicationContext.Incidents.AddAsync(incident);
        await _applicationContext.SaveChangesAsync();
        var createdIncidentDto = _mapper.Map<IncidentDto>(incident);
        return createdIncidentDto;
    }
}

