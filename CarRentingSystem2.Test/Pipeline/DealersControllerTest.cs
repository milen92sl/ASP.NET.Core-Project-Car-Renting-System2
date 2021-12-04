namespace CarRentingSystem2.Test.Pipeline
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using CarRentingSystem2.Controllers;
    using CarRentingSystem2.Models.Dealers;
    using System.Linq;


    using static WebConstants;
    using CarRentingSystem2.Data.Models;

    public class DealersControllerTest
    {
        [Fact]
        public void GetBecomeShouldBeForAuthorizedUsersAndReturnView()
                    => MyPipeline
                    .Configuration()
                    .ShouldMap(request => request
                    .WithPath("/Dealers/Become")
                    .WithUser())
                    .To<DealersController>(c => c.Become())
                    .Which()
                    .ShouldHave()
                    .ActionAttributes(attributes => attributes
                    .RestrictingForAuthorizedRequests())
                    .AndAlso()
                    .ShouldReturn()
                    .View();

        [Theory]
        [InlineData("Dealer", "+35988888888")]
        public void PostBecomeShouldBeForAuthorizedUsersAndReturnRedirectWithValidModel(
            string dealerName,
            string phoneNumber)
            => MyPipeline
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Dealers/Become")
            .WithMethod(HttpMethod.Post)
            .WithFormFields(new
            {
                Name = dealerName,
                PhoneNumber = phoneNumber
            })
            .WithUser()
            .WithAntiForgeryToken())
            .To<DealersController>(c => c.Become(new BecomeDealerFormModel
            {
                Name = dealerName,
                PhoneNumber = phoneNumber,
            }))
            .Which()
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForHttpMethod(HttpMethod.Post)
            .RestrictingForAuthorizedRequests())
            .ValidModelState()
            .Data(data => data.WithSet<Dealer>(dealers => dealers
            .Any(d =>
                d.Name == dealerName &&
                d.PhoneNumber == phoneNumber &&
                d.UserId == TestUser.Identifier)))
            .TempData(tempData => tempData
            .ContainingEntryWithKey(GlobalMessageKey))
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("All", "Cars");
    }
}
