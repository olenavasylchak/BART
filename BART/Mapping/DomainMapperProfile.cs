using System;

using AutoMapper;

using BART.Models.Domain;
using BART.Models.Dto;

namespace BART.Mapping
{
	public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            CreateMap<CreateContactDto, Contact>();
               
            CreateMap<ContactDto, Contact>();

            CreateMap<Contact, ContactDto>();


            CreateMap<CreateAccountDto, Account>();

            CreateMap<AccountDto, Account>();

            CreateMap<Account, AccountDto>();


            CreateMap<CreateIncidentDto, Incident>();

            CreateMap<IncidentDto, Incident>();

            CreateMap<Incident, IncidentDto>();
        }
    }
}

