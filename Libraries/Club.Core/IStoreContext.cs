using Club.Core.Domain.Stores;

namespace Club.Core
{
    /// <summary>
    /// Store context
    /// </summary>
    public interface IStoreContext
    {
        /// <summary>
        /// Gets or sets the current store
        /// </summary>
        Store CurrentStore { get; }
    }
}
