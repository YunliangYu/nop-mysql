using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Club.Web.Framework.Security
{
    public class ApiReqAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 进行验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!SkipAuthorization(actionContext))
            {
                if (actionContext.Request.Headers.Authorization != null)
                {
                    //Authorization: hgh token
                    string authPa = actionContext.Request.Headers.Authorization.Scheme;
                    if (authPa.ToLower().Equals("club"))
                    {
                        //判断认证信息是否正确
                        if (WebApiValidate.ValidateToken(actionContext.Request.Headers.Authorization.Parameter) > 0)
                        {
                            IsAuthorized(actionContext);
                        }
                        else
                        {
                            HandleUnauthorizedRequest(actionContext);
                        }
                    }
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

        /// <summary>
        /// 验证不通过 返回401
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var challengeMsg = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            challengeMsg.Headers.Add("WWW-Authenticate", "Basic");
            throw new System.Web.Http.HttpResponseException(challengeMsg);
        }

    }
}
