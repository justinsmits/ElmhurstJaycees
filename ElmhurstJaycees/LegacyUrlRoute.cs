using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ElmhurstJaycees
{
    public class LegacyUrlRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var request = httpContext.Request;
            var response = httpContext.Response;
            var legacyUrl = request.Url.ToString();
           
            if (legacyUrl.Contains(".php"))
            {
                response.Redirect("~/Home/Index");
            }
            return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext,
                    RouteValueDictionary values)
        {
            return null;
        }
    }

  
}