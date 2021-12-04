namespace CarRentingSystem2.Services.Statistics
{
    using CarRentingSystem2.Data;
    using System.Linq;

    public class StatisticsService : IStatisticsService
    {
        private readonly CarRenting2DbContext data;

        public StatisticsService(CarRenting2DbContext data) 
            => this.data = data;

        public StatisticsServiceModel Total()
        {
            var totalCars = this.data.Cars.Count(c=>c.IsPublic);
            var totalUsers = this.data.Users.Count();

            return new StatisticsServiceModel
            {
                TotalCars = totalCars,
                TotalUsers = totalUsers,
            };
        }
    }
}
