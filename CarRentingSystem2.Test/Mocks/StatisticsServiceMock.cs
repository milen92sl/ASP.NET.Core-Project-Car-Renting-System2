namespace CarRentingSystem2.Test.Moq
{
    using CarRentingSystem2.Services.Statistics;
    using global::Moq;

    public static class StatisticsServiceMock
    {
        public static IStatisticsService Instance
        {
            get
            {
               var statisticsServiceMock = new Mock<IStatisticsService>();

                statisticsServiceMock
                    .Setup(s=>s.Total())
                    .Returns(new StatisticsServiceModel
                    {
                        TotalCars = 5,
                        TotalRents = 10, 
                        TotalUsers = 15
                    });

                return statisticsServiceMock.Object;
            }
        }
    }
}
