using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using CorsService = http_challenge.Service.CorsService;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
public class CustomCorsPolicyAttribute : Attribute, ICorsPolicyProvider
{
    private  CorsPolicy _policy;

    public CustomCorsPolicyAttribute()
    {
        //Is it possible to inject in an attribute?
        var corsService = new CorsService();

        _policy = new CorsPolicy()
        {
            //TODO: Add this shit as a resource.
            Origins =
            {
                string.Join(",", corsService.GetCorsOrigins())
            },

            Methods =
            {
                string.Join(",", corsService.GetCorsMethods())
            }
        };
    }

    public Task<CorsPolicy> GetPolicyAsync(HttpContext context, string policyName)
    {
        return Task.FromResult(_policy);
    }
}