using http_challenge.Builders;
using http_challenge.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;

namespace http_challenge
{
    //TODO: Add dynamic routing {controller}/{action}
    public class AuthController : Controller
    {
        private ApiResponse _response;

        [Route("/auth/info")]
        public IActionResult Info()
        {
            _response = ApiResponseBuilder
                .CreateBuilder()
                .WithMessage("Welcome to the Auth section. In this section, " +
                             "your role is to send two different token types " +
                             "correctly, the bearer and basic token")
                .ToEndpoint("/auth/basic")
                .WithMethod(ApiConstants.Get);

            return StatusCode(100, Json(_response));
        }

        [Route("/auth/basic")]
        public IActionResult Basic()
        {
            string authHeader = Request.Headers?[ApiConstants.Authorization];

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith(ApiConstants.Basic))
            {
                _response = ApiResponseBuilder
                    .CreateBuilder()
                    .WithMessage($"Invalid Auth header. What we received is: {authHeader}")
                    .ToEndpoint("/auth/basic")
                    .WithMethod(ApiConstants.Get);

                return StatusCode(401, Json(_response));
            }

            _response = ApiResponseBuilder
                .CreateBuilder()
                .WithMessage("Now try with A Bearer Token")
                .ToEndpoint("/auth/bearer")
                .WithMethod(ApiConstants.Get);

            return StatusCode(100, Json(_response));
        }


        [Route("/auth/bearer")]
        public IActionResult Bearer()
        {
            string authHeader = Request.Headers?[ApiConstants.Authorization];

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith(ApiConstants.Bearer))
            {
                _response = ApiResponseBuilder
                    .CreateBuilder()
                    .WithMessage($"Invalid Auth header. What we received is: {authHeader}")
                    .ToEndpoint("/auth/basic")
                    .WithMethod(ApiConstants.Get);

                return StatusCode(401, Json(_response));
            }

            _response = ApiResponseBuilder
                .CreateBuilder()
                .WithMessage("YOU DID IT! You wanna play with CORS now?")
                .ToEndpoint("/cors/info")
                .WithMethod(ApiConstants.Get);

            return StatusCode(100, Json(_response));
        }
    }
}