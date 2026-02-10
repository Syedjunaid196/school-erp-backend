using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Utils;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolManagement.API.Middlewares.ResultResponseMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ResultResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ResultResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var OriginalBodyStream = httpContext.Response.Body;
            var memoryStream = new MemoryStream();
            httpContext.Response.Body = memoryStream;
            await _next(httpContext);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var responseText = await new StreamReader(memoryStream).ReadToEndAsync();

            if (IsJson.IsString(responseText))
            {
                httpContext.Response.Body = OriginalBodyStream;
                var data = JsonSerializer.Deserialize<ResultResponse>(responseText, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                if(data.StatusCode != null)
                {
                    httpContext.Response.StatusCode = data.StatusCode;
                }
                else if(data.ProblemDetails.Status is not null)
                {
                    httpContext.Response.StatusCode = data.ProblemDetails.Status.Value;
                }
                await httpContext.Response.WriteAsJsonAsync(responseText);            


            }
            
            else
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                await memoryStream.CopyToAsync(OriginalBodyStream);
                httpContext.Response.StatusCode = 500;
                httpContext.Response.Body = OriginalBodyStream;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ResultResponseMiddlewareExtensions
    {
        public static IApplicationBuilder UseResultResponseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResultResponseMiddleware>();
        }
    }


    public class ResultResponse
    {
        public object? Value { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public ProblemDetails ProblemDetails { get; set; }

        public bool IsSuccess => ProblemDetails is null;
    }
}
