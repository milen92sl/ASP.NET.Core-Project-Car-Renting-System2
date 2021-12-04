namespace CarRentingSystem2.Test.Controller
{
    using CarRentingSystem2.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using System.Collections.Generic;
    using CarRentingSystem2.Services.Cars.Models;

    using static Data.Cars;
    using static WebConstants.Cache;
    using System;

    public class HomeControllerTest
    {

        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
        => MyMvc
          .Pipeline()
            .ShouldMap("/")
            .To<HomeController>(c => c.Index())
            .Which(controller => controller
                .WithData(TenPublicCars()))
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<List<LatestCarServiceModel>>()
            .Passing(m => m.Should().HaveCount(10)));


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

        [Fact]
        public void ErrorShouldReturnView2()
        => MyMvc
            .Pipeline()
            .ShouldMap("/Home/Error")
            .To<HomeController>(c => c.Error())
            .Which()
            .ShouldReturn()
            .View();


        [Fact]
         public void ErrorShouldReturnView3()
         => MyController<HomeController>
         .Instance()
         .Calling(c => c.Error())
         .ShouldReturn()
         .View();

        [Fact]
        public void IndexActionShouldReturnCorrectViewWithModel()
        => MyController<HomeController>
        .Instance(instance => instance
            .WithData(TenPublicCars()))
        .Calling(c => c.Index())
        .ShouldHave()
        .MemoryCache(cache => cache
        .ContainingEntry(entry => entry
        .WithKey(LatestCarsCacheKey)
        .WithAbsoluteExpirationRelativeToNow(TimeSpan.FromMinutes(5))
        .WithValueOfType<List<LatestCarServiceModel>>()))
        .AndAlso()
        .ShouldReturn()
        .View(view => view
        .WithModelOfType<List<LatestCarServiceModel>>()
        .Passing(m => m.Should().HaveCount(10)));
            
    }
}
