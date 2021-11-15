namespace CarRentingSystem2.Controllers.Api
{
    using CarRentingSystem2.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        public readonly IStatisticsService statistics;

        public StatisticsApiController(IStatisticsService statistics)
        {
            this.statistics = statistics;
        }

        [HttpGet]
        public StatisticsServiceModel GetStatistics()
        => this.statistics.Total();     
    }
}
