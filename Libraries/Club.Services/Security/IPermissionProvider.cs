using System.Collections.Generic;
using Club.Core.Domain.Security;

namespace Club.Services.Security
{
    /// <summary>
    /// Permission provider
    /// </summary>
    public interface IPermissionProvider
    {
        /// <summary>
        /// Get permissions
        /// </summary>
        /// <returns>Permissions</returns>
        IEnumerable<PermissionRecord> GetPermissions();

        /// <summary>
        /// Get default permissions
        /// </summary>
        /// <returns>Default permissions</returns>
        IEnumerable<DefaultPermissionRecord> GetDefaultPermissions();
    }
}
