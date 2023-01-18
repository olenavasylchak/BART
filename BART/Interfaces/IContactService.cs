using System;
using BART.Models.Domain;
using BART.Models.Dto;

namespace BART.Interfaces
{
	public interface IContactService
    {
        Task<ContactDto> CreateContactAsync(ContactDto contactDto);
    }
}

