using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElmhurstJaycees.CustomAttributes
{
    public class AuthorizeUserAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/AccessDenied/NotAuthorized");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}