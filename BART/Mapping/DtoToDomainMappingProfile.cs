using System;
using AutoMapper;
using BART.Models.Domain;
using BART.Models.Dto;

namespace BART.Mapping
{
	public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<ContactDto, Contact>();
            CreateMap<AccountDto, Account>();
        }
    }
}

