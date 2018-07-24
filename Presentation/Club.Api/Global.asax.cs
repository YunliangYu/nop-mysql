using Club.Core;
using Club.Core.Domain.Common;
using Club.Core.Infrastructure;
using Club.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Club.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //most of API providers require TLS 1.2 nowadays
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //disable "X-AspNetMvc-Version" header name
            MvcHandler.DisableMvcResponseHeader = true;

            //initialize engine context
            EngineContext.Initialize(false);



            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //log application start
            try
            {
                //log
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Information("Api Application started", null, null);
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //we don't do it in Application_BeginRequest because a user is not authenticated yet
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            //log error
            LogException(exception);
        }


        protected void LogException(Exception exc)
        {
            if (exc == null)
                return;

            //ignore 404 HTTP errors
            var httpException = exc as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404 &&
                !EngineContext.Current.Resolve<CommonSettings>().Log404Errors)
                return;

            try
            {
                //log
                var logger = EngineContext.Current.Resolve<ILogger>();
                var workContext = EngineContext.Current.Resolve<IWorkContext>();

                //需要从header 中获取用户信息，并读取用户的id，设备信息，版本编号。
                logger.Error(exc.Message, exc, workContext.CurrentCustomer);
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }
    }
}
