using System.ComponentModel.DataAnnotations;

namespace PracticeCustomValidationOrderEcommerce.Models
{
    public class Product
    {
        [Display(Name = "Product Code")]
        [Required(ErrorMessage = "{0} must be supplied")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public int ProductCode { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "{0} must be supplied")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public double Price { get; set; }

        [Display(Name = "Product Quantity")]
        [Required(ErrorMessage = "{0} must be supplied")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public int Quantity { get; set; }
    }
}
