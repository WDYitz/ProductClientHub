using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHubAPI.ExceptionsBase;
using ProductClientHubAPI.Http.Responses;

namespace ProductClientHubAPI.Filters;

public class ExceptionFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context)
  {
    if (context.Exception is ProductClientHubException productClientHubException)
    {
      context.HttpContext.Response.StatusCode = (int)productClientHubException.GetHttpStatusCode();
      context.Result = new ObjectResult(new ResponseErrorMessageJson(productClientHubException.GetErrors()));
    }
    else
    {
      ThrowUnknownError(context);
    }
  }

  private void ThrowUnknownError(ExceptionContext context)
  {
    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
    context.Result = new ObjectResult(new ResponseErrorMessageJson("Unknown Error"));
  }
}