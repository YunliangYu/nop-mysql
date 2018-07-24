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
    public partial class AdvertisementService : IAdvertisementService
    {
        #region Fields
        private readonly IRepository<Advertisement> _advertisementRepository;
        private readonly IRepository<AdvertisementPlatform> _advertisementPlatformRepository;
        private readonly IRepository<AdvertisementView> _advertisementViewRepository;
        private readonly IEventPublisher _eventPubisher;
        #endregion Fields
        #region Ctor
        public AdvertisementService
            (IRepository<Advertisement> advertRepository,
            IRepository<AdvertisementPlatform> advertisementPlatformRepository,
            IRepository<AdvertisementView> advertisementViewRepository,
            IEventPublisher eventPublisher
            )
        {
            this._advertisementRepository = advertRepository;
            this._advertisementPlatformRepository = advertisementPlatformRepository;
            this._advertisementViewRepository = advertisementViewRepository;
            this._eventPubisher = eventPublisher;
        }
        #endregion Ctor
        #region Methods
        /// <summary>
        /// 插入广告
        /// </summary>
        /// <param name="advertisement">实体</param>
        public void InsertAdvertisement(Advertisement advertisement)
        {
            if (advertisement == null)
                throw new ArgumentNullException("Advertisement");
            _advertisementRepository.Insert(advertisement);
            _eventPubisher.EntityInserted(advertisement);

        }

        /// <summary>
        /// 更新广告
        /// </summary>
        /// <param name="advert">实体</param>
        public void UpdateAdvertisement(Advertisement advertisement)
        {
            if (advertisement == null)
                throw new ArgumentNullException("advertisement");
            _advertisementRepository.Update(advertisement);
            _eventPubisher.EntityUpdated(advertisement);
        }

        /// <summary>
        /// 逻辑删除广告
        /// </summary>
        /// <param name="advertisement">实体</param>
        public void DeleteAdvertisement(Advertisement advertisement)
        {
            if (advertisement == null)
                throw new ArgumentNullException("advertisement");
            advertisement.Deleted = true;
            _advertisementRepository.Update(advertisement);
            _eventPubisher.EntityUpdated(advertisement);
        }

        /// <summary>
        /// 通过Id查找广告
        /// </summary>
        /// <param name="advertId">广告Id</param>
        /// <returns>实体</returns>
        public Advertisement GetAdvertisementById(int advertisementId)
        {
            if (advertisementId == 0)
                return null;
            return _advertisementRepository.GetById(advertisementId);
        }

        /// <summary>
        /// 获取所有广告（不包含被逻辑删除的）
        /// </summary>
        /// <returns>广告实体集合</returns>
        public IList<Advertisement> GetAllAdvertisements()
        {
            var query = _advertisementRepository.Table;
            query = query.Where(a => !a.Deleted);
            query = query.OrderBy(a => a.DisplayOrder);
            return query.ToList();
        }


        public IList<Advertisement> SearchAdvertisements(int publishedState, int platformId)
        {
            var query = _advertisementRepository.Table;
            query = query.Where(a => !a.Deleted);
            if (publishedState == 1)
                query = query.Where(a => a.Published);
            else if (publishedState == 2)
                query = query.Where(a => !a.Published);
            if (platformId != 0)
            {
                var querySub = _advertisementPlatformRepository.Table;
                querySub = querySub.Where(ap => ap.PlatformId == platformId);
                if (querySub != null && querySub.Count() > 0)
                {
                    var advertisementIds = querySub.Select(ap => ap.AdvertisementId);
                    query = query.Where(a => advertisementIds.Contains(a.Id));
                }
            }
            return query.ToList();
        }

        /// <summary>
        /// 各平台上获取自己需要的广告实体集合
        /// </summary>
        /// <param name="platformId">平台Id</param>
        /// <param name="count">需要的广告数量（等于0时则不限制数量）</param>
        /// <returns>广告实体集合</returns>
        public IList<Advertisement> GetAdvertisementsToShow(int platformId, int count)
        {
            var queryAdvertPlatform = _advertisementPlatformRepository.Table;
            queryAdvertPlatform = queryAdvertPlatform.Where(ap => ap.PlatformId == platformId);
            int[] advertIds = queryAdvertPlatform.Select(ap => ap.Id).ToArray();
            var queryAdvert = _advertisementRepository.Table;
            queryAdvert = queryAdvert.Where(a => advertIds.Contains(a.Id));//只保留属于该平台的产品
            queryAdvert = queryAdvert.Where(a => !a.Deleted);//去掉没有被逻辑删除的产品
            queryAdvert = queryAdvert.Where(a => a.Published);//只保留已发布的产品
            queryAdvert = queryAdvert.OrderBy(a => a.DisplayOrder);//按照广告顺序升序排列
            if (count != 0 && queryAdvert.Count() >= count)//判断是否满足条件数量
                queryAdvert = queryAdvert.Take(count);
            return queryAdvert.ToList();
        }

        /// <summary>
        /// 插入广告浏览记录
        /// </summary>
        /// <param name="advertView">实体</param>
        public void InsertAdvertisementView(AdvertisementView advertisementView)
        {
            if (advertisementView == null)
                throw new ArgumentNullException("advertisementView");
            _advertisementViewRepository.Insert(advertisementView);
            _eventPubisher.EntityInserted(advertisementView);

        }
        #endregion Methods
    }
}
