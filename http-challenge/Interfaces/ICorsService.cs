using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace http_challenge
{
    public interface ICorsService
    {
        IEnumerable<string> GetCorsOrigins();
        IEnumerable<string> GetCorsMethods();

        bool CheckRequestOriginHeader(HttpRequest request);
        bool CheckRequestHeadersHeader(HttpRequest request);
        bool CheckRequestMethodsHeader(HttpRequest request);
    }
}