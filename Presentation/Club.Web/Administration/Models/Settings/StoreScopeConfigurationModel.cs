using System.Collections.Generic;
using Club.Admin.Models.Stores;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Settings
{
    public partial class StoreScopeConfigurationModel : BaseSiteModel
    {
        public StoreScopeConfigurationModel()
        {
            Stores = new List<StoreModel>();
        }

        public int StoreId { get; set; }
        public IList<StoreModel> Stores { get; set; }
    }
}