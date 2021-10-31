namespace CarRentingSystem2.Controllers
{
    using CarRentingSystem2.Models.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddCarFormModel car) => View(car);
    }
}
