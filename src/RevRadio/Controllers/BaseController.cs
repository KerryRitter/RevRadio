using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RevRadio.Data.Interfaces;

namespace RevRadio.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewData["CurrentUser"] = context.HttpContext.User;

            base.OnActionExecuting(context);
        }
    }
}