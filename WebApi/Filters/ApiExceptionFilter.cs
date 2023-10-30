using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Abstractions.MicroServiceCore.Abstractions;
using Services.Implementations;
using System.Diagnostics;
using System.Net;

namespace WebApi.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var logService = context.HttpContext.RequestServices.GetService(typeof(IEventLogService)) as IEventLogService;
        string eventMsg = context.Exception.Message;
        if (logService != null)
        {
            eventMsg = string.Join(Environment.NewLine, context.Exception.Message, "StackTrace:", context.Exception.StackTrace);
            try
            {
                logService.AddEventAsync(eventMsg).GetAwaiter().GetResult();
                Console.WriteLine("{0}  ОШИБКА  {1}", DateTime.Now, eventMsg);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Ошибка записи в лог: " + e.Message);
            }
        }
        else
        {
            eventMsg= $"В методе {context.ActionDescriptor.DisplayName} возникло исключение: \n {eventMsg} \n {context.Exception.StackTrace}";
        }
        context.ExceptionHandled = true;
        context.Result = new ContentResult
        {
            Content = eventMsg,
            StatusCode = (int)HttpStatusCode.BadRequest
        };
    }
}
