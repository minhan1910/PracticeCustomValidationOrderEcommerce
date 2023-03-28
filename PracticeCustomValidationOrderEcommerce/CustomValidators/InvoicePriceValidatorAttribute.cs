using PracticeCustomValidationOrderEcommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PracticeCustomValidationOrderEcommerce.CustomValidators
{
    public class InvoicePriceValidatorAttribute : ValidationAttribute
    {
        private string DefaultErrorMessage { get; set; } = "{0} should be equal to the total cost of all products (i.e. {1}) in the order.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            // get 'Products' reference by Reflection
            PropertyInfo? OtherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));

            if (OtherProperty == null) 
                return null;

            // Get value of 'Products'
            List<Product> products = (List<Product>) OtherProperty.GetValue(validationContext.ObjectInstance)!;

            double totalPrice = CalculateTotalPrice(products),
                    actualPrice = (double)value;
            
            if (totalPrice > 0)
            {
                if (totalPrice != actualPrice)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, validationContext.DisplayName, totalPrice), new string[] { nameof(validationContext.MemberName) });
                }

                return ValidationResult.Success;
            }
            
            //return model error is no products found
            return new ValidationResult("No products found to validate invoice price", new string[] { nameof(validationContext.MemberName) });
        }

        private double CalculateTotalPrice(List<Product> products)
            => products.Sum(product => product.Quantity * product.Price);
    }
}
