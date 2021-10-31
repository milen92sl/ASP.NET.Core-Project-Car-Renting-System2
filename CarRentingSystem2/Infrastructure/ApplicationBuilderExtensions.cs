﻿namespace CarRentingSystem2.Infrastructure
{
    using CarRentingSystem2.Data;
    using CarRentingSystem2.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<CarRenting2DbContext>();

            data.Database.Migrate();

           SeedCategories(data);

            return app;
        }

        private static void SeedCategories(CarRenting2DbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }
            data.Categories.AddRange(new[]
            {
                new Category { Name = "Mini"},
                new Category { Name = "Economy"},
                new Category { Name = "Midsize"},
                new Category { Name = "Large"},
                new Category { Name = "SUV"},
                new Category { Name = "Vans"},
                new Category { Name = "Luxury"},
            });

            data.SaveChanges();
        }
    }
}
