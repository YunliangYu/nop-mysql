using Club.Core.Domain.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Services.Advertisements
{
    public partial interface IPlatformService
    {
        void InsertPlatform(Platform platform);
        void UpdatePlatform(Platform platform);
        void DeletePlatform(Platform platform);
        Platform GetPlatformById(int platformId);
        IList<Platform> GetAllPlatformsForUse();
        IList<Platform> GetAllPlatformsForManage();
    }
}
