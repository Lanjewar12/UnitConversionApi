using Microsoft.AspNetCore.Mvc;
using UnitConversion.Application.Exceptions;

namespace UnitConversion.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidConversionException ex)
            {
                context.Response.StatusCode =
                    StatusCodes.Status400BadRequest;

                await context.Response.WriteAsJsonAsync(
                    new ProblemDetails
                    {
                        Title = "Invalid Conversion Request",
                        Detail = ex.Message,
                        Status = StatusCodes.Status400BadRequest,
                        Instance = context.Request.Path
                    });
            }
            catch (Exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(
                    new ProblemDetails
                    {
                        Title = "Internal Server Error",
                        Detail = "An unexpected error occurred.",
                        Status = StatusCodes.Status500InternalServerError,
                        Instance = context.Request.Path
                    });
            }
        }
    }
}
