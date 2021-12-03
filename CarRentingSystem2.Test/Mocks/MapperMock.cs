namespace CarRentingSystem2.Test.Mocks
{
    using AutoMapper;
    using CarRentingSystem2.Infrastructure;

    public static class MapperMock
    {
        public static IMapper Instance
        {
            get
            {
                var mapperConfiguration = new MapperConfiguration(config =>
                {
                config.AddProfile<MappingProfile>();
                });
                
                return new Mapper(mapperConfiguration);
            }
        }
    }
}
