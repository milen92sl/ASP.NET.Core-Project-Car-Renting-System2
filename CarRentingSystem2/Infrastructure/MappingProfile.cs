namespace CarRentingSystem2.Infrastructure
{
    using AutoMapper;
    using CarRentingSystem2.Data.Models;
    using CarRentingSystem2.Models.Cars;
    using CarRentingSystem2.Services.Cars.Models;


    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            this.CreateMap<Car, LatestCarServiceModel>();
            this.CreateMap<CarDetailsServiceModel, CarFormModel>();

            this.CreateMap<Car, CarDetailsServiceModel>()
                .ForMember(c => c.UserId, cfg => cfg.MapFrom(c => c.Dealer.UserId));
        }
    }
}
