namespace CarRentingSystem2.Services.Cars.Models
{
    using System.Collections.Generic;

    public class CarQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int CarsPerPage { get; init; }

        public int TotalCars { get; set; }

        public IEnumerable<CarServiceModel> Cars { get; init; }
    }
}
