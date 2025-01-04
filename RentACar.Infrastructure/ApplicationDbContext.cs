﻿using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Abstractions;

namespace RentACar.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
