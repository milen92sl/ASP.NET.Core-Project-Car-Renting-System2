
namespace CarRentingSystem2.Test.Controller
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using CarRentingSystem2.Controllers;
    using CarRentingSystem2.Models.Dealers;
    using CarRentingSystem2.Data.Models;
    using System.Linq;

    using static WebConstants;
    using CarRentingSystem2.Models.Cars;

    public class DealersControllerTest
    {
        [Fact]
        public void GetBecomeShouldBeForAuthorizedUsersAndReturnView()
            => MyController<DealersController>
            .Instance()
            .Calling(c => c.Become())
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
            => MyController<DealersController>
            .Instance(controller => controller
            .WithUser())
            .Calling(c => c.Become(new BecomeDealerFormModel
            {
                Name = dealerName,
                PhoneNumber = phoneNumber,
            }))
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
            .TempData(tempData=> tempData
            .ContainingEntryWithKey(GlobalMessageKey))
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("All","Cars");
    }
}
