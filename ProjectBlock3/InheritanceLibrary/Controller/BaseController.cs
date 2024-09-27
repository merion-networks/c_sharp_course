using Microsoft.AspNetCore.Mvc;

namespace InheritanceLibrary.Controller
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleException(Exception exception)
        {
            return new BadRequestResult();
        }
    }
}
