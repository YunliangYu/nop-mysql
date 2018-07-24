using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Club.Api.Models.Customers
{
    public class CustomerModel
    {
        public string Token { get; set; }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string ImageUrl { get; set; }
    }

    public class MobileRegist
    {
        public string Mobile { get; set; }

        public string Password { get; set; }

        public int Captcha { get; set; }
    }
}