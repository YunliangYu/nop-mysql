using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Club.Api.Models.Devices
{
    public class InstallDeviceModel
    {
        public int CustomerId { get; set; }

        public string AppCode { get; set; }

        public string DeviceCode { get; set; }

        public int AppType { get; set; }

        public string MobileBrand { get; set; }

        public string SystemVersion { get; set; }

        public string AppVersion { get; set; }

        public bool Notify { get; set; }
    }
}