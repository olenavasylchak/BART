using System;
using System.ComponentModel.DataAnnotations;

namespace BART.Models.Dto
{
	public class CreateContactDto
	{
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}

