using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Club.Web.Framework.Security;
using System.Web.Http.Routing;

namespace Club.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ApiReqAuthorizeAttribute());
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional },
               constraints: new { id = @"\d+" }
           );

            config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}");
            config.Routes.MapHttpRoute("DefaultApiGet", "Api/{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
            config.Routes.MapHttpRoute("DefaultApiPost", "Api/{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
        }
    }
}
