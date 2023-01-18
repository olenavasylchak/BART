using System;
using System.Collections.Generic;

using BART.Models.Domain;

using Microsoft.EntityFrameworkCore;

namespace BART
{
	public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}

