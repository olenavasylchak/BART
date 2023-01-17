using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace BART.Models.Domain
{
    [Index(nameof(Email), IsUnique = true)]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account? Account { get; set; }
    }
}
