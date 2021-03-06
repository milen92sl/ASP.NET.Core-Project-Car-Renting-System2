namespace CarRentingSystem2.Infrastructure.Extensions
{
    using CarRentingSystem2.Services.Cars.Models;

    public static class ModelExtensions
    {
        public static string GetInformation(this ICarModel car)
        => car.Brand + "-" + @car.Model + "-" + @car.Year;
    }
}
