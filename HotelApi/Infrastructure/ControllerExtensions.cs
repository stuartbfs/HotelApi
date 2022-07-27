using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Infrastructure
{
    public static class ControllerExtensions
    {
        public static async Task<IActionResult> Handle(this ControllerBase controller, Func<Task<IActionResult>> controllerAction)
        {
            try
            {
                return await controllerAction();
            }
            catch (ValidationException)
            {
                return controller.BadRequest();
            }
        }
    }
}
