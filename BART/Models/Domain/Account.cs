using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace BART.Models.Domain
{
    [Index(nameof(Name), IsUnique = true)]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Incident> Incidents { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}

