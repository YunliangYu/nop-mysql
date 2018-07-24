using Club.Core.Data;
using Club.Core.Domain.Advertisements;
using Club.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Services.Advertisements
{
    public partial class AdvertisementPlatformService : IAdvertisementPlatformService
    { 
        #region Fields
        private readonly IRepository<AdvertisementPlatform> _advertisementPlatformRepository;
        private readonly IEventPublisher _eventPubisher;
        #endregion Fields

        #region Ctor
        public AdvertisementPlatformService
            (
            IRepository<AdvertisementPlatform> advertisementPlatformRepository,
            IEventPublisher eventPublisher
            )
        {
            this._advertisementPlatformRepository = advertisementPlatformRepository;
            this._eventPubisher = eventPublisher;
        }
        #endregion Ctor

        #region Methods
        /// <summary>
        /// 插入广告平台
        /// </summary>
        /// <param name="advertisementPlatform">实体</param>
        public void InsertAdvertisementPlatform(AdvertisementPlatform advertisementPlatform)
        {
            if (advertisementPlatform == null)
                throw new ArgumentNullException("advertisementPlatform");
            _advertisementPlatformRepository.Insert(advertisementPlatform);
            _eventPubisher.EntityInserted(advertisementPlatform);
        }

        /// <summary>
        /// 删除广告平台
        /// </summary>
        /// <param name="advertisementPlatform">实体</param>
        public void DeleteAdvertisementPlatform(AdvertisementPlatform advertisementPlatform)
        {
            if (advertisementPlatform == null)
                throw new ArgumentNullException("advertisementPlatform");
            _advertisementPlatformRepository.Delete(advertisementPlatform);
            _eventPubisher.EntityDeleted(advertisementPlatform);
        }

        /// <summary>
        /// 通过广告平台Id获取广告平台
        /// </summary>
        /// <param name="advertisementPlatformId">广告平台Id</param>
        /// <returns>实体</returns>
        public AdvertisementPlatform GetAdvertisementPlatformById(int advertisementPlatformId)
        {
            if (advertisementPlatformId == 0)
                return null;
            return _advertisementPlatformRepository.GetById(advertisementPlatformId);
        }

        /// <summary>
        /// 通过广告Id获取广告平台实体集合
        /// </summary>
        /// <param name="advertId">广告Id</param>
        /// <returns>广告平台实体集合</returns>
        public IList<AdvertisementPlatform> GetAdvertisementPlatformsByAdvertisementId(int advertisementId)
        {
            if (advertisementId == 0)
                return null;
            var query = _advertisementPlatformRepository.Table;
            query = query.Where(ap => ap.AdvertisementId == advertisementId);
            return query.ToList();
        }

        /// <summary>
        /// 根据广告Id和平台Id获取唯一广告平台实体
        /// </summary>
        /// <param name="advertId">广告Id</param>
        /// <param name="platformId">平台Id</param>
        /// <returns>广告平台实体</returns>
        public AdvertisementPlatform GetAdvertisementPlatformByAdvertisementIdAndPlatformId(int advertisementId, int platformId)
        {
            if (advertisementId == 0 || platformId == 0)
                return null;
            var query = _advertisementPlatformRepository.Table;
            query = query.Where(ap => ap.AdvertisementId == advertisementId).Where(ap => ap.PlatformId == platformId);
            if (query.Count() == 0)
                return null;
            return query.Single();
        }

        /// <summary>
        /// 通过平台Id获取广告平台实体集合
        /// </summary>
        /// <param name="platformId">平台Id</param>
        /// <returns>广告平台实体集合</returns>
        public IList<AdvertisementPlatform> GetAdvertisementPlatformsByPlatformId(int platformId)
        {
            if (platformId == 0)
                return null;
            var query = _advertisementPlatformRepository.Table;
            query = query.Where(ap => ap.PlatformId == platformId);
            return query.ToList();
        }
        #endregion Methods
    }
}
