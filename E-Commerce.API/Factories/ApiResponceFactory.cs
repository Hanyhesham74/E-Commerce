


using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens.Experimental;
using Shared.ErrorModels;

namespace E_Commerce.API.Factories
{
    public class ApiResponceFactory
    {
        public static IActionResult CustomValidationErrorResponse(ActionContext context) {
            var errors = context.ModelState.
                    Where(error => error.Value?.Errors.Any() == true).Select(error => new Shared.ErrorModels.ValidationError() 
                    {
                        Field=error.Key,
                        Errors=error.Value?.Errors.Select(error=>error.ErrorMessage)??new List<string>()
                    });
            var response = new ValidationErrorResponse()
            {
                Errors=errors,
                StatusCode=StatusCodes.Status404NotFound,
                ErrorMessage="One Or More Validation Error Happened"
            };
            return new BadRequestObjectResult(response);
        }
    }
}
