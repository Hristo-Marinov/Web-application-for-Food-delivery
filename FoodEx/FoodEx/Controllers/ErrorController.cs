using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FoodEx.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult StatusCodeHandler(int statusCode)
        {
            ViewData["StatusCode"] = statusCode;
            return View("Status");
        }

        [Route("Error/Exception")]
        public IActionResult ExceptionHandler()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewData["ErrorMessage"] = exceptionFeature?.Error.Message;
            ViewData["Path"] = exceptionFeature?.Path;
            return View("Exception");
        }
    }
}
