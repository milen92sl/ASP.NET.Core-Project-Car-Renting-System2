namespace CarRentingSystem2.Controllers
{
    using CarRentingSystem2.Models.Home;
    using CarRentingSystem2.Services.Cars;
    using CarRentingSystem2.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly ICarService cars;
        private readonly IStatisticsService  statistics;


        public HomeController(
            IStatisticsService statistics,
            ICarService cars)
        {

            this.statistics = statistics;
            this.cars = cars;
        }

        public IActionResult Index()
        {

            var latestCars = this.cars
                .Latest()
                .ToList();

            var totalStatistics = this.statistics.Total();

            return View(latestCars);
        }

        public IActionResult Error() => View();
    }
}
