using System;
using System.ComponentModel.DataAnnotations;

namespace BART.Models.Dto
{
	public class CreateIncidentDto
	{
        public string Description { get; set; }

        [Required]
        public string AccountName { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string ContactEmail { get; set; }

    }
}

