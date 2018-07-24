using System.Data.Entity.ModelConfiguration;

namespace Club.Data.Mapping
{
    public abstract class SiteEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected SiteEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }
    }
}