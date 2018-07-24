using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Common
{
    public partial class StoreThemeSelectorModel : BaseSiteModel
    {
        public StoreThemeSelectorModel()
        {
            AvailableStoreThemes = new List<StoreThemeModel>();
        }

        public IList<StoreThemeModel> AvailableStoreThemes { get; set; }

        public StoreThemeModel CurrentStoreTheme { get; set; }
    }
}