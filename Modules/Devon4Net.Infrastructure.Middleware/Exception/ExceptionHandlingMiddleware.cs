using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Devon4Net.Infrastructure.Common.Exceptions;
using Devon4Net.Infrastructure.Common.Options.KillSwitch;
using Devon4Net.Infrastructure.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Devon4Net.Infrastructure.Middleware.Exception
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IOptionsMonitor<KillSwitchOptions> killSwitch)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            try
            {
                if (killSwitch?.CurrentValue.UseKillSwitch == true)
                {
                    if (killSwitch.CurrentValue != null && killSwitch.CurrentValue.EnableRequests)
                    {
                        await _next(context).ConfigureAwait(false);
                    }
                    else
                    {
                        context.Response.Headers.Clear();
                        context.Response.StatusCode = killSwitch.CurrentValue.HttpStatusCode > 0 ? killSwitch.CurrentValue.HttpStatusCode : 403;
                        await context.Response.WriteAsync(string.Empty).ConfigureAwait(false);
                    }
                }
                else
                {
                    await _next(context).ConfigureAwait(false);
                }
            }
#pragma warning disable CA1031 // #warning directive
            catch (System.Exception ex)
#pragma warning restore CA1031 // #warning directive
            {
                await HandleException(ref context, ref ex).ConfigureAwait(false);
            }
        }

        private Task HandleException(ref HttpContext context, ref System.Exception exception)
        {
            Devon4NetLogger.Error(exception);

            var exceptionTypeValue = exception.GetType();
            var exceptionInterfaces = exceptionTypeValue.GetInterfaces().Select(i => i.Name).ToList();
            exceptionInterfaces.Add(exceptionTypeValue.Name);

            return exceptionInterfaces switch
            {
                { } exceptionType when exceptionType.Contains("InvalidDataException") => HandleContext(ref context,
                    StatusCodes.Status422UnprocessableEntity),
                { } exceptionType when exceptionType.Contains("ArgumentException") ||
                                       exceptionType.Contains("ArgumentNullException") ||
                                       exceptionType.Contains("NotFoundException") ||
                                       exceptionType.Contains("FileNotFoundException") => HandleContext(ref context,
                    StatusCodes.Status400BadRequest),
                { } exceptionType when exceptionType.Contains("IWebApiException") => HandleContext(ref context,
                    ((IWebApiException) exception).StatusCode, exception.Message,
                    ((IWebApiException) exception).ShowMessage),
                _ => HandleContext(ref context, StatusCodes.Status500InternalServerError, exception.Message,true)
            };
        }

        private static Task HandleContext(ref HttpContext context, int? statusCode = null, string errorMessage = null, bool showMessage = false)
        {
            context.Response.Headers.Clear();
            context.Response.StatusCode = statusCode ?? StatusCodes.Status500InternalServerError;

            if (!showMessage  || statusCode == StatusCodes.Status204NoContent || string.IsNullOrEmpty(errorMessage) ) return Task.CompletedTask;
            
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(new { error = errorMessage }));
        }
    }
}
