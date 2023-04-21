using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Net;
using System.Web.Http.Results;

using vosplzen.sem2h1.Data;
using vosplzen.sem2h1.Services.Interfaces;

namespace vosplzen.sem2h1.Filters
{
    public class IdentityFilter : Attribute, IResourceFilter
    {

        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            IIdentityService _identityService;
            var service = context.HttpContext.RequestServices.GetService(typeof(IIdentityService));

            if (service != null)
            {

                _identityService = (IIdentityService)service;

                var token = context.HttpContext.Request.Headers
                    .Where(x => x.Key == "Security-Identifer"
                    ).FirstOrDefault();

                var result = _identityService.TokenisValid(token.Value.ToString());


                if(result)
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };

                }

            }
            else
            {
                context.Result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

            }

        }
    }
}
