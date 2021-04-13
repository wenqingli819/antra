using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using ApplicationCore.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Hosting;
using Serilog.Sinks.Email;

namespace MovieShopMVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SerilogMiddleware
    {
        private readonly ILogger<SerilogMiddleware> _logger;
        private readonly RequestDelegate _next;


        public SerilogMiddleware(RequestDelegate next, ILogger<SerilogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            try
            {
                await _next(httpContext);

            }
            catch (Exception ex)
            {
                Log.Information("Serilog Middleware is catching exception");
                await HandleExceptionAsync(httpContext, ex);
            }

        }


        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            // get all the information you wanna log and use Serilog or NLog to log exceptions to text/json files
            Log.Information("Starting Logging for exception");

            // TODO: serilog to log info
            Log.Error("Error message: {}", ex.Message);
            Log.Error("Exception stacktrace: {}", ex.StackTrace);
            Log.Error("Exception message: {}", ex.InnerException?.Message);

            switch (ex)
            {
                case ConflictException conflictException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                case NotFoundException notFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UnauthorizedAccessException unauthorized:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case Exception exception:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }


           


            // redirect to error page
            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;


        }


    }
}
