using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Catalog
{
    public partial class ManufacturerNavigationModel : BaseSiteModel
    {
        public ManufacturerNavigationModel()
        {
            this.Manufacturers = new List<ManufacturerBriefInfoModel>();
        }

        public IList<ManufacturerBriefInfoModel> Manufacturers { get; set; }

        public int TotalManufacturers { get; set; }
    }

    public partial class ManufacturerBriefInfoModel : BaseSiteEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }
        
        public bool IsActive { get; set; }
    }
}