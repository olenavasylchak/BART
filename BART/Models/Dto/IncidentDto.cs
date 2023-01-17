using System;
namespace BART.Models.Dto
{
	public class IncidentDto
	{
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<AccountDto> Accounts { get; set; }
    }
}

