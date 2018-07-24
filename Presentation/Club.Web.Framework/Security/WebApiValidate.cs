using Club.Core.Domain.Security;
using Club.Core.Infrastructure;
using Club.Services.Customers;
using Club.Web.Framework.Security.JWT;
using System;
using System.Collections.Generic;

namespace Club.Web.Framework.Security
{
    public static class WebApiValidate
    {
        public static string GetApiValidateToken(int customerId)
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(2000, 1, 1);
            int times = (int)t.TotalDays;
            var payload = new Dictionary<string, object>
            {
                {"iss",customerId},
                {"iat",times}
            };
            var _securitySettings = EngineContext.Current.Resolve<SecuritySettings>();
            string result = JsonWebToken.Encode(payload, _securitySettings.EncryptionKey, JwtHashAlgorithm.HS256);
            return result;
        }


        /// <summary>
        /// 检查用户的Token有效性
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static int ValidateToken(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    var _securitySettings = EngineContext.Current.Resolve<SecuritySettings>();
                    string decodedJwt = JsonWebToken.Decode(token, _securitySettings.EncryptionKey);

                    if (!string.IsNullOrEmpty(decodedJwt))
                    {
                        dynamic decodedPayload = JsonWebToken.DecodeToObject(token, _securitySettings.EncryptionKey, false);
                        int userid = decodedPayload["iss"];
                        int jwtcreated = (int)decodedPayload["iat"];

                        //检查令牌的有效期，100天内有效
                        TimeSpan t = (DateTime.UtcNow - new DateTime(2000, 1, 1));
                        int timestamp = (int)t.TotalDays;
                        if (timestamp - jwtcreated > 100)
                        {
                            return 0;
                        }
                        var customerService = EngineContext.Current.Resolve<ICustomerService>();
                        var customer = customerService.GetCustomerById(userid);
                        if (customer.Active)
                        { return userid; }
                        else
                        {
                            return 0;
                        }
                    }
                    else { return 0; }
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
