namespace CarRentingSystem2.Controllers
{
    using CarRentingSystem2.Data;
    using CarRentingSystem2.Models.Home;
    using CarRentingSystem2.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly CarRenting2DbContext data;
        private readonly IStatisticsService  statistics;


        public HomeController(IStatisticsService statistics,
            CarRenting2DbContext data)
        {
            this.statistics= statistics;
            this.data = data;
        }

        public IActionResult Index()
        {

            var cars = this.data
                .Cars
                .OrderByDescending(c => c.Id)
                .Select(c => new CarIndexViewModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    ImageUrl = c.ImageUrl,
                    Description = c.Description
                })
                .Take(3)
                .ToList();

            var totalStatistics = this.statistics.Total();
            return View(new IndexViewModel
            {
                TotalCars = totalStatistics.TotalCars,
                TotalUsers = totalStatistics.TotalUsers,
                Cars = cars,
                
            });
        }

        public IActionResult Error() => View();
    }
}
