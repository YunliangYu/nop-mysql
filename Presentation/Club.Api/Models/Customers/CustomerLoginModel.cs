using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Club.Api.Models.Customers
{
    public class CustomerLoginModel
    {
        public string AppCode { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        public string Nonce { get; set; }

    }
    
}