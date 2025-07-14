using TicketSupportAPI.Middlewares;

namespace TicketSupportAPI.Extensions
{
  public static class MiddlewareExtensions
  {
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
    {
      app.UseMiddleware<ExceptionMiddleware>();
      return app;
    }
  }
}