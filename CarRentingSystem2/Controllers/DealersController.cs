namespace CarRentingSystem2.Controllers
{
    using CarRentingSystem2.Data;
    using CarRentingSystem2.Data.Models;
    using CarRentingSystem2.Infrastructure;
    using CarRentingSystem2.Models.Dealers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class DealersController : Controller
    {
        private readonly CarRenting2DbContext data;

        public DealersController(CarRenting2DbContext data) => 
            this.data = data;

        [Authorize]
        public IActionResult Become() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeDealerFormModel dealer)
        {
            var userId = this.User.Id();

            var userIsAlreadyADealer = this.data
                .Dealers
                .Any(d => d.UserId == userId);

            if (userIsAlreadyADealer)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(dealer);
            }

            var dealerData = new Dealer
            {
               Name = dealer.Name,
               PhoneNumber = dealer.PhoneNumber,
               UserId = userId,
            };

            this.data.Dealers.Add(dealerData);
            this.data.SaveChanges();


            return RedirectToAction(nameof(CarsController.All), "Cars");
        }
    }
}
