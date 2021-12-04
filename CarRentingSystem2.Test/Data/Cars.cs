namespace CarRentingSystem2.Test.Data
{
    using CarRentingSystem2.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public static class Cars
    {
        public static IEnumerable<Car> TenPublicCars()
        => Enumerable.Range(0, 10).Select(i => new Car
        {
            IsPublic = true
        });

    }
}
