using Autofac;
using Autofac.Core;
using Club.Core.Caching;
using Club.Core.Configuration;
using Club.Core.Infrastructure;
using Club.Core.Infrastructure.DependencyManagement;
using Club.Web.Controllers;
using Club.Web.Factories;
using Club.Web.Infrastructure.Installation;

namespace Club.Web.Infrastructure
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
            //installation localization service
            builder.RegisterType<InstallationLocalizationService>().As<IInstallationLocalizationService>().InstancePerLifetimeScope();




            //controllers (we cache some data between HTTP requests)
            builder.RegisterType<ProductController>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"));
            builder.RegisterType<ShoppingCartController>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"));




            //factories (we cache presentation models between HTTP requests)
            builder.RegisterType<AddressModelFactory>().As<IAddressModelFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogModelFactory>().As<IBlogModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();

            builder.RegisterType<CatalogModelFactory>().As<ICatalogModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();

            builder.RegisterType<CheckoutModelFactory>().As<ICheckoutModelFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommonModelFactory>().As<ICommonModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();

            builder.RegisterType<CountryModelFactory>().As<ICountryModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerModelFactory>().As<ICustomerModelFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ForumModelFactory>().As<IForumModelFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExternalAuthenticationModelFactory>().As<IExternalAuthenticationModelFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<NewsModelFactory>().As<INewsModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();

            builder.RegisterType<NewsletterModelFactory>().As<INewsletterModelFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderModelFactory>().As<IOrderModelFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PollModelFactory>().As<IPollModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();

            builder.RegisterType<PrivateMessagesModelFactory>().As<IPrivateMessagesModelFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductModelFactory>().As<IProductModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();

            builder.RegisterType<ProfileModelFactory>().As<IProfileModelFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ReturnRequestModelFactory>().As<IReturnRequestModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();

            builder.RegisterType<ShoppingCartModelFactory>().As<IShoppingCartModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();

            builder.RegisterType<TopicModelFactory>().As<ITopicModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();

            builder.RegisterType<VendorModelFactory>().As<IVendorModelFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<WidgetModelFactory>().As<IWidgetModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("club_cache_static"))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 2; }
        }
    }
}