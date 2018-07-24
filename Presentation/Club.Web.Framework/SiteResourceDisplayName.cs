using Club.Core;
using Club.Core.Infrastructure;
using Club.Services.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Web.Framework
{
    public class SiteResourceDisplayName : System.ComponentModel.DisplayNameAttribute, IModelAttribute
    {
        private string _resourceValue = string.Empty;
        //private bool _resourceValueRetrived;

        public SiteResourceDisplayName(string resourceKey)
            : base(resourceKey)
        {
            ResourceKey = resourceKey;
        }

        public string ResourceKey { get; set; }

        public override string DisplayName
        {
            get
            {
                //do not cache resources because it causes issues when you have multiple languages
                //if (!_resourceValueRetrived)
                //{
                var langId = EngineContext.Current.Resolve<IWorkContext>().WorkingLanguage.Id;
                    _resourceValue = EngineContext.Current
                        .Resolve<ILocalizationService>()
                        .GetResource(ResourceKey, langId, true, ResourceKey);
                //    _resourceValueRetrived = true;
                //}
                return _resourceValue;
            }
        }

        public string Name
        {
            get { return "NopResourceDisplayName"; }
        }
    }
}
