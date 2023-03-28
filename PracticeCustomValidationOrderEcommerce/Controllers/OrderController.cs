using Microsoft.AspNetCore.Mvc;
using PracticeCustomValidationOrderEcommerce.CustomModelBinders;
using PracticeCustomValidationOrderEcommerce.Models;

namespace PracticeCustomValidationOrderEcommerce.Controllers
{
    public class OrderController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("<h1>Welcome to order pages</h1>", "text/html");
        }

        [Route("/order")]
        //[ModelBinder(BinderType = typeof(OrderModelBinder))]
        public IActionResult GetOrder([FromForm] Order order)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage));

                return BadRequest(errors);
            }

            Random random = new Random();
            order.OrderNo = random.Next(1, 1_000_000);

            return Json(new { orderNumber = order.OrderNo });
        }


    }
}
