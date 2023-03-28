using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PracticeCustomValidationOrderEcommerce.CustomValidators
{
    public class MatchBetweenPriceAttribute : ValidationAttribute
    {
        private string _otherProperty { get; set; }

        private string _defaultMessage { get; set; } = "{0} doesn't match with the {1} of the specified products in the order";

        public MatchBetweenPriceAttribute(string otherProperty) 
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(_otherProperty);

            var invoicePrice = Convert.ToDouble(otherProperty!.GetValue(validationContext.ObjectInstance));

            var totalPrice = Convert.ToDouble(value);

            if (invoicePrice != totalPrice)
            {
                return new ValidationResult(string.Format(ErrorMessage ?? _defaultMessage, validationContext.DisplayName, nameof(_otherProperty), invoicePrice, totalPrice), new string[] { nameof(_otherProperty), validationContext.MemberName! });
            }

            return ValidationResult.Success;
        }

    }
}
