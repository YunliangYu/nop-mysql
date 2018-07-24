using Club.Core.Domain.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Services.Advertisements
{
    public partial interface IAdvertisementService
    {
        #region Advertisement
        void InsertAdvertisement(Advertisement advertisement);
        void UpdateAdvertisement(Advertisement advertisement);
        void DeleteAdvertisement(Advertisement advertisement);
        Advertisement GetAdvertisementById(int advertId);
        IList<Advertisement> GetAllAdvertisements();
        IList<Advertisement> SearchAdvertisements(int publishedState, int platformId);
        IList<Advertisement> GetAdvertisementsToShow(int platformId, int count);
        #endregion Advertisement

        #region AdvertisementView
        void InsertAdvertisementView(AdvertisementView advertisementView);
        #endregion AdvertisementView
    }
}
