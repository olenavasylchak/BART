using System;
using BART.Models.Domain;
using BART.Models.Dto;

namespace BART.Interfaces
{
	public interface IContactService
    {
        Contact Add(ContactDto contact);
    }
}

