using System;
using Club.Core.Configuration;
using Club.Core.Infrastructure.DependencyManagement;

namespace Club.Core.Infrastructure
{
    /// <summary>
    /// Classes implementing this interface can serve as a portal for the 
    /// various services composing the Club engine. Edit functionality, modules
    /// and implementations access most Club functionality through this 
    /// interface.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Container manager
        /// </summary>
        ContainerManager ContainerManager { get; }

        /// <summary>
        /// Initialize components and plugins in the Club environment.
        /// </summary>
        /// <param name="config">Config</param>
        void Initialize(SiteConfig config);

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;

        /// <summary>
        ///  Resolve dependency
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        T[] ResolveAll<T>();
    }
}
