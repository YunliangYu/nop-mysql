using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Club.Api.Models.Advertisements
{
    public class AdvertisementModel
    {
        public int id { get; set; }
        public int type { get; set; }
        public string url { get; set; }
        public string imageurl { get; set; }
    }
}