using Microsoft.AspNetCore.Mvc.ModelBinding;
using PracticeCustomValidationOrderEcommerce.Models;

namespace PracticeCustomValidationOrderEcommerce.CustomModelBinders
{
    public class OrderModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Order order = new Order();

            //if (bindingContext.ValueProvider.GetValue(""))

            return null;
        }
    }
}
