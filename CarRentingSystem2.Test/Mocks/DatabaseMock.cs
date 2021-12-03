using CarRentingSystem2.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarRentingSystem2.Test.Mocks
{


    public static class DatabaseMock
    {
        public static CarRenting2DbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<CarRenting2DbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new CarRenting2DbContext(dbContextOptions);
            }

        }
    }
}
