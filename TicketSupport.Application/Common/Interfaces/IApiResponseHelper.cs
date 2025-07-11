namespace TicketSupport.Application.Common.Interfaces
{
  public interface IApiResponseHelper
  {
    ApiResponse<T> Success<T>(T data, string? message = null, string? responseCode = null, int statusCode = 200);
    ApiResponse<T> Success<T>(string? message = null, string? responseCode = null, int statusCode = 200);
    ApiResponse<T> Fail<T>(string message, string? responseCode = null, int statusCode = 400);
  }
}
