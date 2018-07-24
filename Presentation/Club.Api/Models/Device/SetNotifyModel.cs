using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Club.Api.Models.Devices
{
    public class SetNotifyModel
    {
        public bool On { get; set; }

        public int CustomerId { get; set; }

        public string DeviceCode { get; set; }
    }
}