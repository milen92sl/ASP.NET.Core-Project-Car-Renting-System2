namespace CarRentingSystem2.Services.Cars
{
    using CarRentingSystem2.Models;
    using System.Collections.Generic;

    public interface ICarService
    {
        CarQueryServiceModel All(string brand,
            string searchTerm,
            CarSorting sorting,
            int currentPage,
            int carsPerPage);

        IEnumerable<string> AllCarBrands();
        
    }
}
