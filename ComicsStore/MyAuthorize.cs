using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ComicsStore
{
    public class MyAuthorize : AuthorizeAttribute
    {
        public int ResourceKey { get; set; }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //User isn't logged in
            if (filterContext.HttpContext.Session["NameCus"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "LoginUser", action = "Login" })
                );
            }
            //User is logged in but has no access
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "LoginUser", action = "NotAuthorized" })
                );
            }
        }

        //Core authentication, called before each action
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isLoggedIn = httpContext.Session["NameCus"] != null;
            //Is user logged in?
            if (isLoggedIn)
                //If user is logged in and we need a custom check:
                //if (ResourceKey != null && OperationKey != null)
                if (ResourceKey != 0)
                    return isAuthorized(int.Parse(httpContext.Session["Priority"].ToString()));

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