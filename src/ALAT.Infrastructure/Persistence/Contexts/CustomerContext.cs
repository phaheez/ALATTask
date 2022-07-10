using ALAT.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALAT.Infrastructure.Persistence.Contexts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Otp> Otps { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Lga> Lgas { get; set; }
    }
}
