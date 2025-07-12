using TicketSupport.Application.Common.Interfaces;

namespace TicketSupport.Application.Common.Helpers
{
  public class ApiResponseHelper : IApiResponseHelper
  {
    public ApiResponse<T> Success<T>(T data, string? message = null, string? responseCode = "SUCCESS", int statusCode = 200)
    {
      return new ApiResponse<T>
      {
        Success = true,
        Data = data,
        Message = message ?? "Success",
        ResponseCode = responseCode,
        StatusCode = statusCode
      };
    }

    public ApiResponse<T> Success<T>(string? message = null, string? responseCode = "SUCCESS", int statusCode = 200)
    {
      return new ApiResponse<T>
      {
        Success = true,
        Message = message ?? "Success",
        ResponseCode = responseCode,
        StatusCode = statusCode,
        Data = default
      };
    }

    public ApiResponse<T> Fail<T>(string message = "Failed", string? responseCode = "BAD_REQUEST", int statusCode = 400)
    {
      return new ApiResponse<T>
      {
        Success = false,
        Message = message ?? "Failed",
        ResponseCode = responseCode,
        StatusCode = statusCode,
        Data = default
      };
    }
  }
}