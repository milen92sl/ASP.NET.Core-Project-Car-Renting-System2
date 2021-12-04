namespace CarRentingSystem2.Test.Routing
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using CarRentingSystem2.Controllers;
    using CarRentingSystem2.Models.Dealers;

    public class DealersControllerTest
    {
        [Fact]
        public void RoutTest()
        => MyRouting
            .Configuration()
            .ShouldMap("/Dealers/Become")
            .To<DealersController>(c => c.Become())
            .Which()
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View();

        [Fact]
        public void GetBecomeShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Dealers/Become")
            .To<DealersController>(c => c.Become());

        [Fact]
        public void PostBecomeShouldBeMapped()
           => MyRouting
           .Configuration()
           .ShouldMap(request => request
           .WithPath("/Dealers/Become")
           .WithMethod(HttpMethod.Post))
           .To<DealersController>(c => c.Become(With.Any<BecomeDealerFormModel>()));
    }
}
