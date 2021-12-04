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
            .WithModelOfType <List<LatestCarServiceModel>>()
            .Passing(m => m.Should().HaveCount(3)));


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
