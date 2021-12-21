using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.exceptionPath = exceptionDetails.Path;
            ViewBag.exceptionMessage = exceptionDetails.Error.Message;
            ViewBag.stacktrace = exceptionDetails.Error.StackTrace;
            return View("Error");
        }
    }

}
