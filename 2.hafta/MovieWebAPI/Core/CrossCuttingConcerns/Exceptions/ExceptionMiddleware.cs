using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                if (exception is BusinessException)
                {
                    ProblemDetails details = new ProblemDetails();
                    details.Title = "Business Rule Violation";
                    details.Detail = exception.Message;
                    details.Type = "Business Exception";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(details));


                }
                else if (exception is ValidationException)
                {

                    ValidationException validationException = (ValidationException)exception;
                    ValidationProblemDetails validationProblemDetails = new ValidationProblemDetails(validationException.Errors.ToList());

                    await context.Response.WriteAsync(JsonSerializer.Serialize(validationProblemDetails));



                }

                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Bilinmedik hata");
                }

            }
        }
    }
}
