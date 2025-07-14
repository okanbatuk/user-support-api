using System.Net;
using TicketSupport.Application.Common;
using TicketSupport.Application.Exceptions;
using TicketSupportAPI.Extensions;

namespace TicketSupportAPI.Helpers
{
  public class ExceptionHandler
  {
    private readonly ILogger<ExceptionHandler> _logger;
    private readonly IHostEnvironment _env;
    private static readonly Dictionary<Type, (HttpStatusCode StatusCode, string ResponseCode)> ExceptionMapping = new()
    {
      { typeof(NotFoundException), (HttpStatusCode.NotFound, "NOT_FOUND") },
      { typeof(ConflictException), (HttpStatusCode.Conflict, "CONFLICT") },
      { typeof(ValidationException), (HttpStatusCode.BadRequest, "VALIDATION_ERROR") },
      { typeof(UnauthorizedException), (HttpStatusCode.Unauthorized, "UNAUTHORIZED") }
    };

    public ExceptionHandler(ILogger<ExceptionHandler> logger, IHostEnvironment env)
    {
      _logger = logger;
      _env = env;
    }
    public async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      var type = exception.GetType();

      if (!ExceptionMapping.TryGetValue(type, out var mapping))
      {
        mapping = (HttpStatusCode.InternalServerError, "INTERNAL_SERVER_ERROR");
        _logger.LogError(exception, exception.Message);
      }
      else
      {
        _logger.LogWarning(exception, exception.Message);

        if (exception is ValidationException vex)
          _logger.LogWarning("Validation errors: {@Errors}", vex.Errors);
      }

      string message = exception.Message;
      if (_env.IsDevelopment() && exception.InnerException != null)
      {
        message += $" | Inner Exception: {exception.InnerException.Message}";
      }

      var response = new ApiResponse<object>
      {
        Success = false,
        Message = message,
        ResponseCode = mapping.ResponseCode,
        StatusCode = (int)mapping.StatusCode,
        Data = exception is ValidationException validationEx ? validationEx.Errors : null
      };

      await context.WriteApiResponseAsync(response);
    }
  }
}