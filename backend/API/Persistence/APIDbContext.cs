using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Persistence
{
    public class APIDbContext : DbContext 
    {    
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        public DbSet<Client>? Client { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<Client>(e => 
            {
                e.HasKey(of => of.IdClient);

                e.Property(of => of.Email);
                
                e.Property(of => of.Password);
            });
        }
    }
}