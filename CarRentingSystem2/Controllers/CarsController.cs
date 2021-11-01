namespace CarRentingSystem2.Controllers
{
    using CarRentingSystem2.Data;
    using CarRentingSystem2.Data.Models;
    using CarRentingSystem2.Models.Cars;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly CarRenting2DbContext data;

        public CarsController(CarRenting2DbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View(new AddCarFormModel
        {
            Categories = this.GetCarCategories()
        });

        [HttpPost]
        public IActionResult Add(AddCarFormModel car)
        {
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
                CategoryId = car.CategoryId
            };

            this.data.Cars.Add(carData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

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
