﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BART.Models.Domain
{
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Account> Accounts { get; set; }

        public Incident()
        {
            Accounts = new List<Account>();
        }
    }
}

