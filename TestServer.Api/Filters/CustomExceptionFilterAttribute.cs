using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Net.Mime;
using TestServer.Core.Exceptions;

namespace TestServer.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;

            string message = context.Exception.Message;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (context.Exception is NotFoundException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                message = string.Format("{0} was not found.", message);
            }
            else if (context.Exception is ValidationException)
                message = string.Format("Validations failed: {0}.", message);
            else
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Result = new JsonResult(new
            {
                message
            });
        }
    }
}
