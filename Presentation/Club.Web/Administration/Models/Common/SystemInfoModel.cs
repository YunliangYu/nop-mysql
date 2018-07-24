using System;
using System.Collections.Generic;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Common
{
    public partial class SystemInfoModel : BaseSiteModel
    {
        public SystemInfoModel()
        {
            this.ServerVariables = new List<ServerVariableModel>();
            this.LoadedAssemblies = new List<LoadedAssembly>();
        }

        [SiteResourceDisplayName("Admin.System.SystemInfo.ASPNETInfo")]
        public string AspNetInfo { get; set; }

        [SiteResourceDisplayName("Admin.System.SystemInfo.IsFullTrust")]
        public string IsFullTrust { get; set; }

        [SiteResourceDisplayName("Admin.System.SystemInfo.SiteVersion")]
        public string SiteVersion { get; set; }

        [SiteResourceDisplayName("Admin.System.SystemInfo.OperatingSystem")]
        public string OperatingSystem { get; set; }

        [SiteResourceDisplayName("Admin.System.SystemInfo.ServerLocalTime")]
        public DateTime ServerLocalTime { get; set; }

        [SiteResourceDisplayName("Admin.System.SystemInfo.ServerTimeZone")]
        public string ServerTimeZone { get; set; }

        [SiteResourceDisplayName("Admin.System.SystemInfo.UTCTime")]
        public DateTime UtcTime { get; set; }

        [SiteResourceDisplayName("Admin.System.SystemInfo.CurrentUserTime")]
        public DateTime CurrentUserTime { get; set; }

        [SiteResourceDisplayName("Admin.System.SystemInfo.HTTPHOST")]
        public string HttpHost { get; set; }

        [SiteResourceDisplayName("Admin.System.SystemInfo.ServerVariables")]
        public IList<ServerVariableModel> ServerVariables { get; set; }

        [SiteResourceDisplayName("Admin.System.SystemInfo.LoadedAssemblies")]
        public IList<LoadedAssembly> LoadedAssemblies { get; set; }

        public partial class ServerVariableModel : BaseSiteModel
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public partial class LoadedAssembly : BaseSiteModel
        {
            public string FullName { get; set; }
            public string Location { get; set; }
            public bool IsDebug { get; set; }
            public DateTime? BuildDate { get; set; }
        }
    }
}