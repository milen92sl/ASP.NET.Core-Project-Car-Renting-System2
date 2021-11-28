namespace CarRentingSystem2.Models.Cars
{
    using CarRentingSystem2.Services.Cars;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Car;

    public class CarFormModel
    {
        public int Id { get; init; }
        [Required]
        [StringLength(BrandMaxLength, MinimumLength = BrandMinLength)]
        public string Brand { get; init; }

        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; init; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = DescriptionMinLength, ErrorMessage = "The field Description must contain a text with a minimum length of {2}!")]
        public string Description { get; init; }

        [Display(Name = "Image URL")]
        [Url]
        [Required]
        public string ImageUrl { get; init; }

        [Range(YearMinValue, YearMaxValue)]
        public int Year { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<CarCategoryServiceModel> Categories { get; set; }
    }
}
