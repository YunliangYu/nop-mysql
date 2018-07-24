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
    public partial class PlatformService : IPlatformService
    {
        #region Fields
        private readonly IRepository<Platform> _platformRepository;
        private readonly IEventPublisher _eventPubisher;
        #endregion Fields

        #region Ctor
        public PlatformService
            (
            IRepository<Platform> platformRepository,
            IEventPublisher eventPublisher
            )
        {
            this._platformRepository = platformRepository;
            this._eventPubisher = eventPublisher;
        }
        #endregion Ctor
        #region Methods
       
        /// <summary>
        /// 插入平台
        /// </summary>
        /// <param name="platform">实体</param>
        public void InsertPlatform(Platform platform)
        {
            if (platform == null)
                throw new ArgumentNullException("platform");
            _platformRepository.Insert(platform);
            _eventPubisher.EntityInserted(platform);
        }

        /// <summary>
        /// 更新平台
        /// </summary>
        /// <param name="platform">实体</param>
        public void UpdatePlatform(Platform platform)
        {
            if (platform == null)
                throw new ArgumentNullException("platform");
            _platformRepository.Update(platform);
            _eventPubisher.EntityUpdated(platform);
        }

        /// <summary>
        /// 删除平台
        /// </summary>
        /// <param name="platform">实体</param>
        public void DeletePlatform(Platform platform)
        {
            if (platform == null)
                throw new ArgumentNullException("platform");
            platform.Deleted = true;
            _platformRepository.Update(platform);
            _eventPubisher.EntityUpdated(platform);
        }

        /// <summary>
        /// 通过Id获取平台
        /// </summary>
        /// <param name="platformId">平台Id</param>
        /// <returns>平台实体</returns>
        public Platform GetPlatformById(int platformId)
        {
            if (platformId == 0)
                return null;
            return _platformRepository.GetById(platformId);
        }

        /// <summary>
        /// 获取所有平台（不包含逻辑删除的），用于维护平台管理
        /// </summary>
        /// <returns>平台实体集合</returns>
        public IList<Platform> GetAllPlatformsForManage()
        {
            var query = _platformRepository.Table;
            query = query.Where(pf => !pf.Deleted);
            return query.ToList();
        }
        /// <summary>
        /// 获取所有平台（不包含逻辑删除的,也不包含未发布的），用于和广告关联映射
        /// </summary>
        /// <returns>平台实体集合</returns>
        public IList<Platform> GetAllPlatformsForUse()
        {
            var query = _platformRepository.Table;
            query = query.Where(pf => !pf.Deleted).Where(pf => pf.Published);
            return query.ToList();
        }

        #endregion Methods
    }
}
