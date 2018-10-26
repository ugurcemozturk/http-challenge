using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace http_challenge.Service
{
    public class CorsService : ICorsService
    {
        private StringValues _corsHeader;

        //TODO: Consider to use Code Contracts for null check
        //TODO: Add this shit as a resource.
        public IEnumerable<string> GetCorsOrigins() => new List<string>
        {
            "http://demo.com",
            "https://demo.com"
        };

        public IEnumerable<string> GetCorsMethods() => new List<string>
        {
            HttpMethods.Get,
            HttpMethods.Post,
            HttpMethods.Options
        };

        public bool CheckRequestOriginHeader(HttpRequest request)
        {
            request.Headers.TryGetValue(CorsConstants.Origin, out _corsHeader);

            return _corsHeader.Any() && GetCorsOrigins().Contains(_corsHeader[0]);
        }

        public bool CheckRequestMethodsHeader(HttpRequest request)
        {
            request.Headers.TryGetValue(CorsConstants.AccessControlRequestMethod, out _corsHeader);

            return _corsHeader.Any() && GetCorsMethods().Contains(_corsHeader[0]);
        }


        public bool CheckRequestHeadersHeader(HttpRequest request)
        {
            request.Headers.TryGetValue(CorsConstants.Origin, out _corsHeader);

            return _corsHeader.Any() && GetCorsOrigins().Contains(_corsHeader[0]);
        }
    }
}