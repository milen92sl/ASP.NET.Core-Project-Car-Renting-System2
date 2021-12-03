namespace CarRentingSystem2.Test.Controllers
{
    using CarRentingSystem2.Controllers;
    using CarRentingSystem2.Data.Models;
    using CarRentingSystem2.Services.Statistics;
    using CarRentingSystem2.Test.Mocks;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Xunit;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using System.Collections.Generic;
    using CarRentingSystem2.Services.Cars.Models;

    public class HomeControllerTest
    {

        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
        => MyMvc
          .Pipeline()
            .ShouldMap("/")
            .To<HomeController>(c => c.Index())
            .Which(controller => controller
                .WithData(GetCars()))
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<IndexViewModel>()
            .Passing(m => m.Cars.Should().HaveCount(3)));

        [Fact]
        public void IndexShouldReturnViewWithCorrectModel()
        {
            //Arrange
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            var cars = Enumerable
                .Range(0, 10)
                .Select(i => new Car());

            data.Cars.AddRange(cars);
            data.Users.Add(new User());
            data.SaveChanges();

            var carService = new CarService(data, mapper);
            var statisticsService = new StatisticsService(data);

            var homeController = new HomeController(statisticsService, carService);

            //Act 
            var result = homeController.Index();

            //Assert          
            result
                .Should()
                .NotBeNull()
                .And
                .Should()
                .BeAssignableTo<ViewResult>()
                .Which
                .Model
                .As<IndexViewModel>()
                .Invoking(model =>
                {
                    model.Cars.Should().HaveCount(3);
                    model.TotalCars.Should().Be(10);
                    model.TotalUsers.Should().Be(1);

                })
                .Invoke();

        }

        [Fact]
        public void ErrorShouldReturnView()
        {
            //Arrange 
            var homeController = new HomeController(null, null);

            //Act
            var result = homeController.Error();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        private static IEnumerable<Car> GetCars()
        => Enumerable.Range(0, 10).Select(i => new Car());


    }
}
