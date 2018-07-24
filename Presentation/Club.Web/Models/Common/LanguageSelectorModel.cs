using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Common
{
    public partial class LanguageSelectorModel : BaseSiteModel
    {
        public LanguageSelectorModel()
        {
            AvailableLanguages = new List<LanguageModel>();
        }

        public IList<LanguageModel> AvailableLanguages { get; set; }

        public int CurrentLanguageId { get; set; }

        public bool UseImages { get; set; }
    }
}