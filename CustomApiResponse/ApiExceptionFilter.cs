using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace CustomApiResponse
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //Log exception
            HandleExceptionAsync(filterContext);
            filterContext.ExceptionHandled = true;
        }

        private static void HandleExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is UnauthorizedAccessException)
                SetExceptionResult(context, exception, HttpStatusCode.Unauthorized);
            else if (exception is Exception)
                SetExceptionResult(context, exception, HttpStatusCode.BadRequest);
            else
                SetExceptionResult(context, exception, HttpStatusCode.InternalServerError);
        }

        private static void SetExceptionResult(
        ExceptionContext context,
        Exception exception,
        HttpStatusCode code)
        {
            context.Result = new JsonResult(new ApiResonse
            {
                StatusCode = (int)code,
                ErrorMessage = exception.Message,
                Response = null
            });
        }
    }
}
