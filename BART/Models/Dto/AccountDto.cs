using System;

namespace BART.Models.Dto
{
	public class AccountDto
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ContactDto> Contacts { get; set; }
    }
}

