using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePizza_JD.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePizza_JD.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("error/")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("{statusCode?}/{errorMessage?}", Name = "GetErrorInfo")]
        public IActionResult HandleErrorCode(int? statusCode, string errorMessage)
        {
            //1. data die beschikbaar komt via de error middleware
            //400 request errors
            var statusCodeData = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            //500 server errors
            IExceptionHandlerFeature feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            var reExecuteFeature = feature as ExceptionHandlerFeature; //casting om props te hebben //file errors
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //2. consistent error object
            var exceptionMessage = new ExceptionMessageUser();
            //3. errorhandler
            if (statusCode != null)
            {
                //3a. error handler voor statuscodes (kan ook via if else)
                switch (statusCode)
                {
                    case int n when (statusCode >= 400 && statusCode < 500):
                        exceptionMessage = new ExceptionMessageUser()
                        {
                            Error = "Request Error",
                            Message = $"Jouw request bevat een fout met status code {statusCode}. {errorMessage}",
                            ErrorRoute = (statusCodeData?.OriginalPath != null) ? "Jouw route:" + (statusCodeData?.OriginalPath != null) : null
                        };
                        break;
                    case int n when (statusCode >= 500 && statusCode < 600): //TODO: verder uit te werken exceptionMessage = new ExceptionMessageUser() { Message = "TODO: nog niet geïmplementeerd" };
                        break;
                }
            }
            //JsonResult of StatusCode zorgt voor serialisatie (obj -> string), System.Text.JsonSerialize onnodig
            return StatusCode(statusCode.Value, exceptionMessage);

        }
    }
}
