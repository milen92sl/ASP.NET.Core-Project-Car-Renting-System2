namespace CarRentingSystem2.Services.Cars
{
    public class CarDetailsServiceModel : CarServiceModel
    {
        public CarDetailsServiceModel() : base()
        {
        }

        public int DealerId { get; init; }

        public string DealerName { get; init; }

        public int CategoryId { get; init; }

        public string UserId { get; init; }
    }
}
