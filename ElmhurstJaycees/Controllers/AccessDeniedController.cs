using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElmhurstJaycees.Controllers
{
    public class AccessDeniedController : Controller
    {
        public ViewResult NotAuthorized()
        {
            Models.AccessDeniedModel model = new Models.AccessDeniedModel();
            model.ErrorMessage = "You do not have permission to perform this action. Please Login to edit content.";
            return View(model);
        }
    }
}