using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Catalog
{
    public partial class SearchBoxModel : BaseSiteModel
    {
        public bool AutoCompleteEnabled { get; set; }
        public bool ShowProductImagesInSearchAutoComplete { get; set; }
        public int SearchTermMinimumLength { get; set; }
    }
}