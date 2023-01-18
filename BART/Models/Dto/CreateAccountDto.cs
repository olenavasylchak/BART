using System;
using System.ComponentModel.DataAnnotations;

namespace BART.Models.Dto
{
	public class CreateAccountDto
	{
        public string Name { get; set; }

        [Required]
        public CreateContactDto Contact { get; set; }
    }
}

