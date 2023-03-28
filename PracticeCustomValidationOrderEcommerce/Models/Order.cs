using Microsoft.AspNetCore.Mvc.ModelBinding;
using PracticeCustomValidationOrderEcommerce.CustomValidators;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PracticeCustomValidationOrderEcommerce.Models
{
    public class Order
    {
        [BindNever]
        [Display(Name = "Order Number")]
        public int? OrderNo { get; set; }

        [Display(Name = "Order Date")]
        [Required(ErrorMessage = "{0} can't be blank")]
        [OrderDateValidator(2000, 1, 1, ErrorMessage = "{0} must be greater than or euqal to {3}/{2}/{1}")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Invoice price")]
        [InvoicePriceValidator]
        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public double InvoicePrice { get; set; }

        //[BindNever]
        //[Display(Name = "Total Cost")]
        //[MatchBetweenPrice("InvoicePrice")]
        //public double TotalPrice { get; set; }

        [Display(Name = "Products")]
        [Required(ErrorMessage = "{0} should be supplied")]
        [MinLength(1, ErrorMessage = "{0} should be supplied")]
        public List<Product> Products { get; set; } = new List<Product>();
       
        //public double CalculateInvoicePrice()
        //{
        //    return Products.Sum(product => product.Quantity * product.Price);
        //}
    }
}
