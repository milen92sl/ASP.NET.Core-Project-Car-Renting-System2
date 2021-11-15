namespace CarRentingSystem2.Controllers.Api
{
    using CarRentingSystem2.Models.Api.Cars;
    using CarRentingSystem2.Services.Cars;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/cars")]
    public class CarsApiController : ControllerBase
    {
        private readonly ICarService cars;

        public CarsApiController(ICarService cars) => 
            this.cars = cars;

        [HttpGet]
        public CarQueryServiceModel All([FromQuery] AllCarsApiRequestModel query) 
            => this.cars.All(
               query.Brand,
               query.SearchTerm,
               query.Sorting,
               query.CurrentPage,
               query.CarsPerPage);

    }
}
