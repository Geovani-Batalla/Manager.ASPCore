using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ASPCore.Session
{
    class SessionProcess: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Convert.ToInt32(filterContext.HttpContext.Session.GetInt32("Id")) == 0)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Session",
                    action = "Login"
                }));
            }
        }
    }
}
