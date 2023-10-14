using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System.Diagnostics;
using System.Net;

namespace UserService.API.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(
            ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                ProblemDetails problemDetails;
                if (exception is HttpResponseException httpResponseException)
                {
                    problemDetails = CreateProblemDetails(context, httpResponseException);

                    context.Response.StatusCode = (int)httpResponseException.StatusCode;
                }
                else if (exception is BadRequestException badRequestException)
                {
                    problemDetails = CreateProblemDetails(context, badRequestException);

                    context.Response.StatusCode = (int)badRequestException.StatusCode;
                }
                else if (exception is UserNotFoundException userNotFoundException)
                {
                    problemDetails = CreateProblemDetails(context, userNotFoundException);

                    context.Response.StatusCode = (int)userNotFoundException.StatusCode;
                }
                else
                {
                    const string defaultInternalServerErrorTitle = "Internal server error";
                    const string defaultInternalServerErrorDetail = "An error occurred.";

                    problemDetails = new ProblemDetails
                    {
                        Title = defaultInternalServerErrorTitle,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Detail = defaultInternalServerErrorDetail,
                        Instance = context.Request.Path
                    };

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }

                _logger.LogError(exception, exception.Message);

                await context.Response.WriteAsJsonAsync(problemDetails);

            }
        }

        private ProblemDetails CreateProblemDetails(HttpContext context, HttpResponseException exception)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = exception.StatusCode.GetDisplayName(),
                Status = (int)exception.StatusCode,
                Detail = exception.Message,
                Instance = context.Request.Path
            };

            const string traceIdKey = "traceId";
            problemDetails.Extensions.TryAdd(traceIdKey, Activity.Current?.RootId);

            return problemDetails;
        }
    }
}
