namespace CarRentingSystem2.Controllers
{
    using CarRentingSystem2.Data;
    using CarRentingSystem2.Data.Models;
    using CarRentingSystem2.Infrastructure;
    using CarRentingSystem2.Models.Cars;
    using CarRentingSystem2.Services.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly CarRenting2DbContext data;
        private readonly ICarService cars;

        public CarsController(CarRenting2DbContext data, ICarService cars)
        {
            this.data = data;
            this.cars = cars;
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!this.UserIsDealer())
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            return View(new AddCarFormModel
            {
                Categories = this.GetCarCategories()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCarFormModel car)
        {
            var dealerId = this.data
                .Dealers
                .Where(d=>d.UserId == this.User.GetId())
                .Select(d=>d.Id)
                .FirstOrDefault();

            if (dealerId == 0)
            {               
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            if (!this.data.Categories.Any(c => c.Id == car.CategoryId))
            {
                this.ModelState.AddModelError(nameof(car.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                car.Categories = this.GetCarCategories();

                return View(car);
            }

            var carData = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Year = car.Year,
                CategoryId = car.CategoryId,
                DealerId = dealerId
               
            };

            this.data.Cars.Add(carData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        public IActionResult All([FromQuery] AllCarsQueryModel query)
        {
            var queryResult = this.cars.All(
                query.Brand,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarsQueryModel.CarsPerPage);

            var carBrands = this.cars.AllCarBrands();

            query.Brands = carBrands;
            query.TotalCars = queryResult.TotalCars;
            query.Cars = queryResult.Cars;

            return View(query);
        }

        private bool UserIsDealer()
            => this.data
                .Dealers
                .Any(d => d.UserId == User.GetId());


        private IEnumerable<CarCategoryViewModel> GetCarCategories()
        => this.data
            .Categories
            .Select(x => new CarCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();
    }
}
