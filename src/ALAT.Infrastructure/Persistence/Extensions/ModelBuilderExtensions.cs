using ALAT.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALAT.Infrastructure.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().HasData(
                new State { Id = 1, Name = "Lagos" },
                new State { Id = 2, Name = "Oyo" },
                new State { Id = 3, Name = "Ogun" }
            );
            modelBuilder.Entity<Lga>().HasData(
                new Lga { Id = 1, Name = "Lagos Island", StateId = 1 },
                new Lga { Id = 2, Name = "Lagos Mainland", StateId = 1 },
                new Lga { Id = 3, Name = "Ikorodu", StateId = 1 },
                new Lga { Id = 4, Name = "Saki", StateId = 2 },
                new Lga { Id = 5, Name = "Iseyin", StateId = 2 },
                new Lga { Id = 6, Name = "Oorelope", StateId = 2 },
                new Lga { Id = 7, Name = "Shagamu", StateId = 3 },
                new Lga { Id = 8, Name = "Abeokuta", StateId = 3 }
            );
        }
    }
}
