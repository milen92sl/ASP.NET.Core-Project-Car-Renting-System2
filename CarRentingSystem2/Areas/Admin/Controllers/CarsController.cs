namespace CarRentingSystem2.Areas.Admin.Controllers
{
    using CarRentingSystem2.Services.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static AdminConstants;

    [Area(AreaName)]
    [Authorize(Roles = AdministratorRoleName)]
    public class CarsController : AdminController
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }

        public IActionResult All()
        {
            var cars = this.cars
                .All(publicOnly: false)
                .Cars;

            return View(cars);
        }
    }
}
