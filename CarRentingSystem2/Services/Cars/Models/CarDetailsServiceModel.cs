namespace CarRentingSystem2.Services.Cars.Models
{
    public class CarDetailsServiceModel : CarServiceModel
    {
        public int CategoryId { get; init; }

        public int DealerId { get; init; }

        public string DealerName { get; init; }

        public string UserId { get; init; }
    }
}
