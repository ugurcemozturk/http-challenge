using System.Threading.Tasks;
using http_challenge.Core.Domain;
using Microsoft.AspNetCore.Http;

//Base interface for all middlewares.
namespace http_challenge
{
    public interface IMiddleware
    {
        ApiResponse Response { get; set; }
        Task InvokeAsync(HttpContext context);
    }
}