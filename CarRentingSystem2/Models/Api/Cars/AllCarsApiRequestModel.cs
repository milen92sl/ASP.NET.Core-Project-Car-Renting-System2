namespace CarRentingSystem2.Models.Api.Cars
{
    using CarRentingSystem2.Models;

    public class AllCarsApiRequestModel
    {
        public string Brand { get; set; }

        public string SearchTerm { get; init; }

        public CarSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int CarsPerPage { get; init; } = 10;

    }
}
