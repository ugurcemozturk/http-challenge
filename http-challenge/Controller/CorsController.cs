using http_challenge.Builders;
using http_challenge.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace http_challenge
{
    [Route("[controller]/[action]")]
    [CustomCorsPolicy]
    public class CorsController : Controller
    {
        private ApiResponse _response;
        private readonly ICorsService _corsService;

        public CorsController(ICorsService corsService)
        {
            _corsService = corsService;
        }

        // GET
        public ObjectResult Index()
        {
            _response = ApiResponseBuilder
                .CreateBuilder()
                .WithMessage("Welcome to the CORS section. In this section, " +
                             "your role is to send your origin and +" +
                             "verify which HTTP methods are allowed. But first + " +
                             "do you remember the one request method that send before" +
                             "the real request method. Throw it to the given endpoint")
                .ToEndpoint("/cors/start")
                .WithMethod(HttpMethods.Get);

            return Accepted(_response);
        }

        // GET
        public ObjectResult Origin()
        {
            if (_corsService.CheckRequestOriginHeader(Request))
            {
                _response = ApiResponseBuilder
                    .CreateBuilder()
                    .WithMessage("")
                    .ToEndpoint("/cors/origin")
                    .WithMethod(HttpMethods.Get);

                return StatusCode(401, Json(_response));
            }

            _response = ApiResponseBuilder
                .CreateBuilder()
                .WithMessage("YOU DID IT A G A I N! You wanna play with XXX now?")
                .ToEndpoint("/")
                .WithMethod(HttpMethods.Get);

            return Accepted(_response);
        }

        // GET
        public ObjectResult Methods()
        {
            if (Request.Method.Equals(HttpMethod.Options.ToString()))
            {
                _response = ApiResponseBuilder
                    .CreateBuilder()
                    .WithMessage("Welcome to the CORS section. In this section, " +
                                 "your role is to send your origin and +" +
                                 "verify which HTTP methods are allowed. But first + " +
                                 "do you remember the one request method that send before" +
                                 "the real request method. Throw it to the given endpoint")
                    .ToEndpoint("/cors/start")
                    .WithMethod(HttpMethods.Get);

                return Accepted(_response);
            }

            _response = ApiResponseBuilder
                .CreateBuilder()
                .WithMessage("asdasdas" +
                             "the real request method. Throw it to the given endpoint")
                .ToEndpoint("/cors/start")
                .WithMethod(HttpMethods.Get);

            return Accepted(_response);
        }

        [Route("cors/start")]
        public ObjectResult Preflight()
        {
            return Accepted(_response);
        }
    }
}