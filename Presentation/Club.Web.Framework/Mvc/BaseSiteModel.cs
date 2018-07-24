using System.Collections.Generic;
using System.Web.Mvc;

namespace Club.Web.Framework.Mvc
{
    /// <summary>
    /// Base Club model
    /// </summary>
    [ModelBinder(typeof(SiteModelBinder))]
    public partial class BaseSiteModel
    {
        public BaseSiteModel()
        {
            this.CustomProperties = new Dictionary<string, object>();
            PostInitialize();
        }

        public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }

        /// <summary>
        /// Use this property to store any custom value for your models. 
        /// </summary>
        public Dictionary<string, object> CustomProperties { get; set; }
    }

    /// <summary>
    /// Base Club entity model
    /// </summary>
    public partial class BaseSiteEntityModel : BaseSiteModel
    {
        public virtual int Id { get; set; }
    }
}
