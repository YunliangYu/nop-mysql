using Autofac;
using Club.Core.Caching;
using Club.Core.Configuration;
using Club.Core.Infrastructure;
using Club.Core.Infrastructure.DependencyManagement;

namespace Club.Services.Tests
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, SiteConfig config)
        {
            //cache managers
           builder.RegisterType<SiteNullCache>().As<ICacheManager>().Named<ICacheManager>("club_cache_static").SingleInstance();

        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }

}
