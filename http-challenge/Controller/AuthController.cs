using System;
using System.Net;
using http_challenge.Builders;
using http_challenge.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace http_challenge
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private ApiResponse _response;

        [HttpGet]
        public ObjectResult Info()
        {
            _response = ApiResponseBuilder
                .CreateBuilder()
                .WithMessage("Welcome to the Auth section. In this section, " +
                             "your role is to send two different token types " +
                             "correctly, the bearer and basic token")
                .ToEndpoint("/auth/basic")
                .WithMethod(HttpMethods.Get);

            return Accepted(_response);
        }

        [HttpGet]
        public ObjectResult Basic()
        {
            string authHeader = Request.Headers?[HttpRequestHeader.Authorization.ToString()];

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith(ApiConstants.Basic))
            {
                _response = ApiResponseBuilder
                    .CreateBuilder()
                    .WithMessage($"Invalid Auth header. What we received is: {authHeader}")
                    .ToEndpoint("/auth/basic")
                    .WithMethod(HttpMethods.Get);

                return StatusCode(401, Json(_response));
            }

            _response = ApiResponseBuilder
                .CreateBuilder()
                .WithMessage("Now try with A Bearer Token")
                .ToEndpoint("/auth/bearer")
                .WithMethod(HttpMethods.Get);

            return Accepted(_response);        }

        [HttpGet]
        public ObjectResult Bearer()
        {
            string authHeader = Request.Headers?[HttpRequestHeader.Authorization.ToString()];

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith(ApiConstants.Bearer))
            {
                _response = ApiResponseBuilder
                    .CreateBuilder()
                    .WithMessage($"Invalid Auth header. What we received is: {authHeader}")
                    .ToEndpoint("/auth/basic")
                    .WithMethod(HttpMethods.Get);

                return StatusCode(401, Json(_response));
            }

            _response = ApiResponseBuilder
                .CreateBuilder()
                .WithMessage("YOU DID IT! You wanna play with CORS now?")
                .ToEndpoint("/cors/info")
                .WithMethod(HttpMethods.Get);

            return Accepted(_response);
        }
    }
}