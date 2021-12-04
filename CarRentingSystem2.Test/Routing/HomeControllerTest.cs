namespace CarRentingSystem2.Test.Routing
{
    using CarRentingSystem2.Controllers;
    using Xunit;
    using MyTested.AspNetCore.Mvc;

    public class HomeControllerTest
    {

        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
        => MyRouting
            .Configuration()
            .ShouldMap("/")
            .To<HomeController>(c => c.Index());

        [Fact]
        public void ErrorShouldReturnViewWithCorrectModelAndData()
        => MyRouting
            .Configuration()
            .ShouldMap("/Home/Error")
            .To<HomeController>(c=>c.Error());            
    }
}
