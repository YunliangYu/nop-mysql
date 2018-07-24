using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Club.Api.Models.Devices
{
    public class AppVersionModel
    {
        public bool HintUpdate { get; set; }

        public int MainVersion { get; set; }

        public int SubVersion { get; set; }

        public string UpdateContent { get; set; }

        public string DownloadUrl { get; set; }
    }
}