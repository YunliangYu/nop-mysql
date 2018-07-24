using Club.Core;
using Club.Core.Domain.Directory;

namespace Club.Services.Directory
{
    public partial interface ICityService
    {
        /// <summary>
        /// Deletes a city
        /// </summary>
        /// <param name="city">city item</param>
       void DeleteCity(City city);

        /// <summary>
       /// Gets a city
        /// </summary>
       /// <param name="cityId">The city identifier</param>
       /// <returns>City</returns>
       City GetCityById(int cityId);

        /// <summary>
       /// Gets all city
        /// </summary>
        /// <param name="languageId">Language identifier; 0 if you want to get all records</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
       /// <returns>City items</returns>
       IPagedList<City> GetAllCity(int pageIndex = 0, int pageSize = int.MaxValue);

       IPagedList<City> GetCitysByProvinceId(int provinceId, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
       /// Inserts a city item
        /// </summary>
       /// <param name="city">City item</param>
       void InsertCity(City city);

        /// <summary>
       /// Updates the city item
        /// </summary>
       /// <param name="city">City item</param>
       void UpdateCity(City city);

       City GetCityByCityName(string cityName);
    }
}
