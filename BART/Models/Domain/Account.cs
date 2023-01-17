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

        public int IncidentId { get; set; }

        [ForeignKey("IncidentId")]
        public Incident? Incident { get; set; }

        public List<Contact> Contacts { get; set; }

        public Account()
        {
            Contacts = new List<Contact>();
        }
    }
}

