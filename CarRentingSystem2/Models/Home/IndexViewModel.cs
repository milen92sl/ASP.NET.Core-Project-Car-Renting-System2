namespace CarRentingSystem2.Models.Home
{
    using CarRentingSystem2.Services.Cars.Models;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public int TotalCars { get; init; }

        public int TotalUsers { get; init; }

        public int TotalRents { get; init; }

        public IList<LatestCarServiceModel> Cars { get; init; }
    }
}
