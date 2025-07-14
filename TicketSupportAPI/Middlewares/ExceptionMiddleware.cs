using System.Net;
using System.Text.Json;
using TicketSupportAPI.Helpers;

namespace TicketSupportAPI.Middlewares
{
  public class ExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ExceptionHandler _exceptionHelper;

    public ExceptionMiddleware(RequestDelegate next, ExceptionHandler exceptionHelper)
    {
      _next = next;
      _exceptionHelper = exceptionHelper;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        await _exceptionHelper.HandleExceptionAsync(context, ex);
      }
    }
  }
}