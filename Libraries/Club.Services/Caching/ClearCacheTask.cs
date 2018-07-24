using Club.Core.Caching;
using Club.Core.Infrastructure;
using Club.Services.Tasks;

namespace Club.Services.Caching
{
    /// <summary>
    /// Clear cache schedueled task implementation
    /// </summary>
    public partial class ClearCacheTask : ITask
    {
        /// <summary>
        /// Executes a task
        /// </summary>
        public void Execute()
        {
            var cacheManager = EngineContext.Current.ContainerManager.Resolve<ICacheManager>("club_cache_static");
            cacheManager.Clear();
        }
    }
}
