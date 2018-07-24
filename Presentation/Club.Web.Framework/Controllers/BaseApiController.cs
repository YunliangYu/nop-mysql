using Club.Core;
using Club.Core.Infrastructure;
using Club.Services.Logging;
using Club.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Club.Web.Framework.Controllers
{
    [StoreIpAddress]
    public abstract class BaseApiController : ApiController
    {
        protected virtual int GetLanguageId(HttpContextBase httpContext)
        {

            var languageId = httpContext.Request.Headers["Language"];
            if (String.IsNullOrEmpty(languageId))
                return 1;
            else
                return Convert.ToInt32(languageId);
        }

        /// <summary>
        /// 检查token中的用户信息是否与获取数据的用户id为同一个用户
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        protected virtual bool CheckTokenUser(int customerId)
        {
            //return true;
            var headerCustomerId = WebApiValidate.ValidateToken(Request.Headers.Authorization.Parameter);
            if (headerCustomerId == 0)
                return false;
            else if (headerCustomerId != customerId)
                return false;
            else
                return true;
        }

        protected virtual int GetUserIdByToken()
        {
            //return true;
            var headerCustomerId = WebApiValidate.ValidateToken(Request.Headers.Authorization.Parameter);
            return headerCustomerId;
        }
        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="exc">Exception</param>
        protected virtual void LogException(Exception exc)
        {
            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            var logger = EngineContext.Current.Resolve<ILogger>();

            //var customer = workContext.CurrentCustomer;
            logger.Error(exc.Message, exc, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="statusCode"></param>
        /// <param name="statusMessage"></param>
        /// <returns></returns>
        protected virtual HttpResponseMessage ReturnResult<T>(T value, int statusCode, string statusMessage)
        {
            var newValue = new object();
            if (string.IsNullOrWhiteSpace(value.ToString()))
            {
                var result = new
                {
                    result = newValue,
                    status = statusCode,
                    statusMessage = statusMessage
                };
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                var result = new
                {
                    result = value,
                    status = statusCode,
                    statusMessage = statusMessage
                };
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="statusCode"></param>
        /// <param name="statusMessage"></param>
        /// <returns></returns>
        protected virtual HttpResponseMessage ReturnResultList<T>(List<T> value, int statusCode, string statusMessage)
        {
            var newValue = new List<object>();
            if (value.Count == 0)
            {
                var result = new
                {
                    result = newValue,
                    status = statusCode,
                    statusMessage = statusMessage
                };
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                var result = new
                {
                    result = value,
                    status = statusCode,
                    statusMessage = statusMessage
                };
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }

    }
}
