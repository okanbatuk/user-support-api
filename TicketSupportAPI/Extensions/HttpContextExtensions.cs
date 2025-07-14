using System.Text.Json;
using Microsoft.AspNetCore.Http;
using TicketSupport.Application.Common;

namespace TicketSupportAPI.Extensions
{
  public static class HttpContextExtensions
  {
    public static async Task WriteApiResponseAsync<T>(this HttpContext context, ApiResponse<T> response)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = response.StatusCode;

      var opt = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

      var json = JsonSerializer.Serialize(response, opt);
      await context.Response.WriteAsync(json);
    }
  }
}
