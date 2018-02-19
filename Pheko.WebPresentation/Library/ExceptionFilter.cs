using Pheko.Common.ErrorLogging;

using System;
using System.ServiceModel;
using System.Web.Mvc;

namespace Pheko.WebPresentation.Library
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                Exception exception = filterContext.Exception;
                var result = new ViewResult();

                result.ViewName = "Error";
                result.ViewBag.ErrorMessageLine1 = exception.Message;
                result.ViewBag.ErrorMessageLine2 = "Please contact admin for further assistance regrading this error.";

                if (!(filterContext.Exception is FaultException))
                {
                    ErrorLogger errorLogger = new ErrorLogger("Pheko.Web", "PhekoSolution");
                    errorLogger.WriteToEventLog(exception);
                }
                if (exception.InnerException != null)
                {
                    result.ViewBag.InnerExceptionMessage = exception.GetType().ToString() + "<br/>" +
                                                           exception.InnerException.Message;
                    result.ViewBag.StackTrace = exception.InnerException.StackTrace;
                }
                else
                {
                    result.ViewBag.InnerExceptionMessage = exception.GetType().ToString();
                    if (exception.StackTrace != null)
                    {
                        result.ViewBag.StackTrace = exception.StackTrace.ToString().TrimStart();
                    }
                }
                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new
                        {
                            error = true,
                            message = "Please contact admin for further assistance regrading this error: " + exception.Message
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    filterContext.Result = result;
                }

                filterContext.ExceptionHandled = true;
            }
        }
    }
}
