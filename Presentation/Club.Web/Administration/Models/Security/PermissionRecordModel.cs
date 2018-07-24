using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Security
{
    public partial class PermissionRecordModel : BaseSiteModel
    {
        public string Name { get; set; }
        public string SystemName { get; set; }
    }
}