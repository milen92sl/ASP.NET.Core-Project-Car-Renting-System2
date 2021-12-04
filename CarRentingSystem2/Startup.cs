namespace CarRentingSystem2
{
    using CarRentingSystem2.Data;
    using CarRentingSystem2.Data.Models;
    using CarRentingSystem2.Infrastructure;
    using CarRentingSystem2.Services.Cars;
    using CarRentingSystem2.Services.Cars.Models;
    using CarRentingSystem2.Services.Dealers;
    using CarRentingSystem2.Services.Statistics;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarRenting2DbContext>(options => options
            .UseSqlServer(this.Configuration
            .GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<CarRenting2DbContext>();


            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.SuppressModelStateInvalidFilter = true;
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddMemoryCache();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IDealerService, DealerService>();
            services.AddTransient<IStatisticsService, StatisticsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection()
               .UseStaticFiles()
               .UseRouting()
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
                 {
                     endpoints.MapDefaultAreaRoute();

                     endpoints.MapControllerRoute(
                         name: "Car Details",
                         pattern: "/Cars/Details/{id}/{information}",
                         defaults: new { controler = "Cars", action = "Details" });

                     endpoints.MapDefaultControllerRoute();
                     endpoints.MapRazorPages();
                 });
        }
    }
}
