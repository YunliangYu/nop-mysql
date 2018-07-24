using Club.Core.Domain.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Services.Advertisements
{
    public partial interface IAdvertisementPlatformService
    {

        #region AdvertisementPlatform
        void InsertAdvertisementPlatform(AdvertisementPlatform advertisementPlatform);
        void DeleteAdvertisementPlatform(AdvertisementPlatform advertisementPlatform);
        AdvertisementPlatform GetAdvertisementPlatformById(int advertisementPlatformId);
        IList<AdvertisementPlatform> GetAdvertisementPlatformsByAdvertisementId(int advertisementId);
        AdvertisementPlatform GetAdvertisementPlatformByAdvertisementIdAndPlatformId(int advertisementId, int platformId);
        IList<AdvertisementPlatform> GetAdvertisementPlatformsByPlatformId(int platformId);
        #endregion AdvertPlatform
    }
}
