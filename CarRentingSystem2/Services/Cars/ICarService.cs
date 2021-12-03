namespace CarRentingSystem2.Services.Cars
{
    using CarRentingSystem2.Models;
    using CarRentingSystem2.Services.Cars.Models;
    using System.Collections.Generic;

    public interface ICarService
    {
        CarQueryServiceModel All(string brand,
            string searchTerm,
            CarSorting sorting,
            int currentPage,
            int carsPerPage);

        IEnumerable<LatestCarServiceModel> Latest();
        CarDetailsServiceModel Details(int carId);

        int Create(string brand,
                string model,
                string description,
                string imageUrl,
                int year,
                int categoryId,
                int dealerId);

        bool Edit(
            int carId,
            string brand,
            string model,
            string description,
            string imageUrl,
            int year,
            int categoryId);

        IEnumerable<CarServiceModel> ByUser(string userId);

        bool IsByDealer(int carId, int dealerId);

        IEnumerable<string> AllBrands();

        IEnumerable<CarCategoryServiceModel> AllCategories();

        bool CategoryExists(int categoryId);
    }
}
