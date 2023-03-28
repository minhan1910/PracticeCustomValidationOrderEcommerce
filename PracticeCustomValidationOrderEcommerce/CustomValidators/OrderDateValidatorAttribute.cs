using System.ComponentModel.DataAnnotations;

namespace PracticeCustomValidationOrderEcommerce.CustomValidators
{
    public class OrderDateValidatorAttribute : ValidationAttribute
    {

        private int _year { get; set; }
        private int _month { get; set; }
        private int _day { get; set; }

        private DateTime _constrainOrderDate { get; set; }
        public OrderDateValidatorAttribute(int year, int month, int day) 
        {
            _year = year;
            _month = month;
            _day = day;
            _constrainOrderDate = new DateTime(_year, _month, _day);
        }

        // 2000-01-01 is valid
        public OrderDateValidatorAttribute(string dateTime)
        {
            _constrainOrderDate = Convert.ToDateTime(dateTime);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }

            var orderDate = Convert.ToDateTime(value.ToString());

            if (orderDate.CompareTo(_constrainOrderDate) < 0)
            {
                return new ValidationResult(string.Format(ErrorMessage!, validationContext.DisplayName, _year, _month, _day), new string[] { "OrderDate" });
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
    }
}
