using System.Collections.Generic;
using Club.Admin.Models.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Common
{
    public partial class LanguageSelectorModel : BaseSiteModel
    {
        public LanguageSelectorModel()
        {
            AvailableLanguages = new List<LanguageModel>();
        }

        public IList<LanguageModel> AvailableLanguages { get; set; }

        public LanguageModel CurrentLanguage { get; set; }
    }
}