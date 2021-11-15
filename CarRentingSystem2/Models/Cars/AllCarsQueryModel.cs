namespace CarRentingSystem2.Models.Cars
{
    using CarRentingSystem2.Services.Cars;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllCarsQueryModel
    {
        public const int CarsPerPage = 6;

        public string Brand { get; set; }

        [Display(Name = "Search by text:")]
        public string SearchTerm { get; init; }

        public CarSorting Sorting { get; init; }
        
        public int CurrentPage { get; init; } = 1;

        public int TotalCars { get; set; }

        public IEnumerable<string> Brands { get; set; }

        public IEnumerable<CarServiceModel> Cars { get; set; }
    }
}
