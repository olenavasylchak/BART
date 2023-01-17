using System;
using AutoMapper;
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

        _applicationContext.Incidents.Add(incident);
        _applicationContext.SaveChanges();

        return incident;
    }
}

