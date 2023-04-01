using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SupportTicketSystem.Data.Models;

namespace SupportTicketSystem.Data
{
    public class SupportTicketDbContext : DbContext
    {
        //private readonly IConfiguration _configuration;
        //public SupportTicketDbContext(DbContextOptions options, IConfiguration configuration)
        //: base(options)
        //{
        //    _configuration = configuration;
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SupportTicketDb;Trusted_Connection=True;");
        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
