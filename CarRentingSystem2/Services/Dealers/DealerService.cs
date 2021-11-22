namespace CarRentingSystem2.Services.Dealers
{
    using CarRentingSystem2.Data;
    using System.Linq;

    public class DealerService : IDealerService
    {
        private readonly CarRenting2DbContext data;


        public DealerService(CarRenting2DbContext data) 
            => this.data = data;

        public int IdByUser(string userId)
            => this.data
            .Dealers
                .Where(d => d.UserId ==userId)
                .Select(d => d.Id)
                .FirstOrDefault();
        

        public bool IsDealer(string userId)
            => this.data
            .Dealers
            .Any(d=>d.UserId == userId);   
    }
}
