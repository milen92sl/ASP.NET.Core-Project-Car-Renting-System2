namespace CarRentingSystem2.Test.Services
{
    using CarRentingSystem2.Data.Models;
    using CarRentingSystem2.Services.Dealers;
    using CarRentingSystem2.Test.Mocks;
    using Xunit;
    public class DealerServiceTest
    {
        private const string userId = "TestUserId";
        [Fact]
        public void IsDealerShouldReturnTrueWhenUserIsDealer()
        {
            //Arrange
            var dealerService = GetDealerService();

            //Act
            var result = dealerService.IsDealer(userId);

            //Assert    
            Assert.True(result);
        }

        [Fact]
        public void IsDealerShouldReturnFalseWhenUserIsNotDealer()
        {
            //Arrange
            var dealerService = GetDealerService();

            //Act
            var result = dealerService.IsDealer("AnotherUserId");

            //Assert    
            Assert.False(result);
        }

        private static IDealerService GetDealerService()
        {
            var data = DatabaseMock.Instance;

            data.Dealers.Add(new Dealer { UserId = userId });
            data.SaveChanges();

            return new DealerService(data);

        }
    }
}
