namespace CarRentingSystem2.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarRentingSystem2.Data;
    using CarRentingSystem2.Models.Home;
    using CarRentingSystem2.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly CarRenting2DbContext data;
        private readonly IConfigurationProvider mapper;
        private readonly IStatisticsService  statistics;


        public HomeController(
            IStatisticsService statistics, 
            IMapper mapper,
            CarRenting2DbContext data)
        {

            this.statistics= statistics;
            this.mapper = mapper.ConfigurationProvider;
            this.data = data;
        }

        public IActionResult Index()
        {

            var cars = this.data
                .Cars
                .OrderByDescending(c => c.Id)
                .ProjectTo<CarIndexViewModel>(mapper)
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
