using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ComicsStore
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        public int ResourceKey { get; set; }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //User isn't logged in
            if (filterContext.HttpContext.Session["NameUser"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "ADHome", action = "Login", area="Admin" })
                );
            }
            //User is logged in but has no access
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "ADHome", action = "Login", area = "Admin" })
                );
            }
        }

        //Core authentication, called before each action
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isLoggedIn = httpContext.Session["NameUser"] != null;
            //Is user logged in?
            if (isLoggedIn)
                //If user is logged in and we need a custom check:
                //if (ResourceKey != null && OperationKey != null)
                if (ResourceKey != 0)
                    return isAuthorized(int.Parse(httpContext.Session["ADPriority"].ToString()));

            //Returns true or false, meaning allow or deny. False will call HandleUnauthorizedRequest above
            return isLoggedIn;
        }

        private bool isAuthorized(int currentPriority)
        {
            if (currentPriority > 0 && currentPriority <= ResourceKey)
            {
                return true;
            }

            return false;
        }
    }
}