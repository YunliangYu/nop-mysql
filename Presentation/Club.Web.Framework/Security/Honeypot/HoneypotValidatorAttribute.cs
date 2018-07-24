﻿using System;
using System.Web.Mvc;
using Club.Core;
using Club.Core.Domain.Security;
using Club.Core.Infrastructure;
using Club.Services.Logging;

namespace Club.Web.Framework.Security.Honeypot
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class HoneypotValidatorAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            var securitySettings = EngineContext.Current.Resolve<SecuritySettings>();
            if (securitySettings.HoneypotEnabled)
            {
                string inputValue = filterContext.HttpContext.Request.Form[securitySettings.HoneypotInputName];

                var isBot = !String.IsNullOrWhiteSpace(inputValue);
                if (isBot)
                {
                    var logger = EngineContext.Current.Resolve<ILogger>();
                    logger.Warning("A bot detected. Honeypot.");

                    //filterContext.Result = new HttpUnauthorizedResult();
                    var webHelper = EngineContext.Current.Resolve<IWebHelper>();
                    string url = webHelper.GetThisPageUrl(true);
                    filterContext.Result = new RedirectResult(url);
                }
            }
        }
    }
}