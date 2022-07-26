﻿using HotelDomain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using ValidationException = FluentValidation.ValidationException;

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
            catch (NotFoundException ex)
            {
                return controller.NotFound(ex.Message);
            }
            catch (HotelDomain.Exceptions.ValidationException ex)
            {
                return controller.BadRequest(ex.Message);
            }
            catch (ValidationException ex)
            {
                return controller.BadRequest(ex.Errors);
            }
            catch (BadRequestException ex)
            {
                return controller.BadRequest(new { Error = ex.Message });
            }
        }
    }
}
