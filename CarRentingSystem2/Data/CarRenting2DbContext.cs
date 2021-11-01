﻿namespace CarRentingSystem2.Data
{
    using CarRentingSystem2.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CarRenting2DbContext : IdentityDbContext
    {
        public CarRenting2DbContext(DbContextOptions<CarRenting2DbContext> options)
                    : base(options)
        {
        }

        public DbSet<Car> Cars { get; init; }

        public DbSet<Category> Categories { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasOne(c=>c.Category)
                .WithMany(c=>c.Cars)
                .HasForeignKey(c=>c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}