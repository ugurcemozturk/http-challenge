using http_challenge.Core.Domain;

namespace http_challenge.Builders
{
    public static class ApiResponseBuilder
    {
        public static ApiResponse CreateBuilder()
        {
            return new ApiResponse();
        }

        public static ApiResponse WithMessage(this ApiResponse response, string message)
        {
            response.Message = message;
            return response;
        }

        public static ApiResponse ToEndpoint(this ApiResponse response, string endpoint)
        {
            response.Next = endpoint;
            return response;
        }

        public static ApiResponse WithMethod(this ApiResponse response, string method)
        {
            response.Method = method;
            return response;
        }
    }
}