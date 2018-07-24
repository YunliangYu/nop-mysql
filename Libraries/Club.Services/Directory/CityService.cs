using Club.Core;
using Club.Core.Data;
using Club.Core.Domain.Directory;
using Club.Services.Events;
using System;
using System.Linq;

namespace Club.Services.Directory
{
    public partial class CityService:ICityService
    {
        #region Fields
        private readonly IRepository<City> _cityRepository;
        private readonly IEventPublisher _eventPublisher;
        #endregion

        #region Ctor

        public CityService(IRepository<City> cityRepository,
            IEventPublisher eventPublisher)
        {
            this._cityRepository = cityRepository;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods

        public void DeleteCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException("city");

            _cityRepository.Delete(city);

            //event notification
            _eventPublisher.EntityDeleted(city);
        }

        public City GetCityById(int cityId)
        {
            if (cityId == 0)
                return null;

            return _cityRepository.GetById(cityId);
        }

        public IPagedList<City> GetAllCity(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _cityRepository.Table;
            query = query.OrderBy(c => c.Id);
            var city = new PagedList<City>(query, pageIndex, pageSize);
            return city;
        }
        public IPagedList<City> GetCitysByProvinceId(int stateProvinceId, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _cityRepository.Table;
            query = query.Where(p => p.StateProvinceId.Equals(stateProvinceId));
            query = query.OrderBy(c => c.StateProvinceId);
            var city = new PagedList<City>(query, pageIndex, pageSize);
            return city;
        }

        public void InsertCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException("city");

            _cityRepository.Insert(city);

            //event notification
            _eventPublisher.EntityInserted(city);
        }

        public void UpdateCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException("city");

            _cityRepository.Update(city);

            //event notification
            _eventPublisher.EntityUpdated(city);
        }

        public City GetCityByCityName(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
                return null;

            var query = from d in _cityRepository.Table
                        where d.Name.Equals(cityName)
                        orderby d.Id
                        select d;
            var city = query.FirstOrDefault();
            return city;
        }
        #endregion


       
    }
}
