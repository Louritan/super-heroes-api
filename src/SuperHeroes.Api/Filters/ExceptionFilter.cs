using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SuperHeroes.Communication.Responses;
using SuperHeroes.Exception.ExceptionsBase;

namespace SuperHeroes.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is SuperHeroesException)
            {
                HandleProjectException(context);
                return;
            }

            ThrowUnknownError(context);
        }

        private void HandleProjectException(ExceptionContext context)
        {
            var superHeroesException = (SuperHeroesException)context.Exception;
            var errorResponse = new ResponseErrorJson(superHeroesException.GetErrors());

            context.HttpContext.Response.StatusCode = superHeroesException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        private void ThrowUnknownError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson("Unknown error");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
