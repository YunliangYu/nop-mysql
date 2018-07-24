using System;
using System.Web.Mvc;
using Club.Core;
using Club.Core.Data;
using Club.Core.Domain.Customers;
using Club.Core.Infrastructure;

namespace Club.Web.Framework.Controllers
{
    /// <summary>
    /// Attribute to ensure that users with "Vendor" customer role has appropriate vendor account associated (and active)
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited=true, AllowMultiple=true)]
    public class AdminVendorValidation : FilterAttribute, IAuthorizationFilter
    {
        private readonly bool _ignore;

        public AdminVendorValidation(bool ignore = false)
        {
            this._ignore = ignore;
        }

        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (_ignore)
                return;

            //don't apply filter to child methods
            if (filterContext.IsChildAction)
                return;

            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            if (!workContext.CurrentCustomer.IsVendor())
                return;

            //ensure that this user has active vendor record associated
            if (workContext.CurrentVendor == null)
                filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
