using System.Net;
using System.Text.Json;
using TicketSupport.Application.Common;

namespace TicketSupportAPI.Middlewares
{
  public class ExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
      _env = env;
      _logger = logger;
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, ex.Message);
        await HandleExceptionAsync(context, ex);
      }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      string message = "An error occurred while processing your request.";
      string? details = null;

      if (_env.IsDevelopment())
      {
        message = ex.Message;
        if (ex.InnerException != null)
        {
          details = ex.InnerException.Message;
          message += $" | Inner: {details}";
        }
      }

      var response = new ApiResponse<object>
      {
        Success = false,
        Message = message,
        ResponseCode = "INTERNAL_SERVER_ERROR",
        StatusCode = context.Response.StatusCode,
        Data = null
      };
      var opt = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
      var json = JsonSerializer.Serialize(response, opt);
      await context.Response.WriteAsync(json);
    }
  }
}