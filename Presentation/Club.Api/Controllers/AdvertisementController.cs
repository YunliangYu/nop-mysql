using Club.Core.Domain.Media;
using Club.Services.Advertisements;
using Club.Services.Helpers;
using Club.Services.Media;
using Club.Api.Models.Advertisements;
using Club.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Club.Web.Extensions;
using Club.Core;
using Club.Core.Domain.Advertisements;

namespace Club.Web.Controllers.WebAPI
{
    [AllowAnonymous]
    public class AdvertisementController : BaseApiController
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IPictureService _pictureService; 
        private readonly MediaSettings _mediaSettings;
        private readonly IWebHelper _webHelper;

        public AdvertisementController(IAdvertisementService advertisementService,
             MediaSettings mediaSettings,
             IDateTimeHelper dateTimeHelper, 
            IPictureService pictureService,
            IWebHelper webHelper)
        {
            this._advertisementService = advertisementService;
            this._dateTimeHelper = dateTimeHelper;
            this._mediaSettings = mediaSettings;
            this._pictureService = pictureService;
            this._webHelper = webHelper;
        }
        [HttpGet]
        [ActionName("GetAdvertisementList")]
        public HttpResponseMessage GetAdvertisementList(int areaId)
        {
            var adverts = _advertisementService.SearchAdvertisements(1, areaId);
            List<AdvertisementModel> advertModelList = new List<AdvertisementModel>();
            foreach (var advert in adverts.OrderBy(a=> a.DisplayOrder).ToList())
            {
                AdvertisementModel advertModel = new AdvertisementModel();
                advertModel.id = advert.Id;
                advertModel.imageurl = _pictureService.GetPictureUrl(_pictureService.GetPictureById(advert.PictureId), 375, true);
                advertModel.type = advert.AdvertisementType;
                if (advert.AdvertisementType == 0)
                    advertModel.url = advert.LinkUrl;
                else
                    advertModel.url = _webHelper.GetStoreLocation() + "api/Advertisement/GetAdvertisement?id=" + advert.Id;
                advertModelList.Add(advertModel);
            }
            return ReturnResultList(advertModelList, 0, string.Empty);        
        }

        [HttpGet]
        [ActionName("GetAdvert")]
        public HttpResponseMessage GetAdvert(int id)
        {
            try
            {
                var content = _advertisementService.GetAdvertisementById(id).Content;
                var result = new
                {
                    content = content.ConvertImageTakeHost(_webHelper.GetStoreLocation())
                };
                var advertView = new AdvertisementView()
                {
                    AdvertisementId = id,
                    IPAddress = _webHelper.GetCurrentIpAddress(),
                    ViewOnUtc = DateTime.UtcNow
                };
                _advertisementService.InsertAdvertisementView(advertView);
                return ReturnResult(result, 0, "");
            }
            catch (Exception ex)
            {
                LogException(ex);
                return ReturnResult("", 1, "读取广告数据出现错误");
            }
        }

        [HttpPost]
        [ActionName("PostAdvertView")]
        public void PostAdvertView(int advertId)
        {
            var advertView = new AdvertisementView()
            {
                AdvertisementId = advertId,
                IPAddress = _webHelper.GetCurrentIpAddress(),
                ViewOnUtc = DateTime.UtcNow
            };
            _advertisementService.InsertAdvertisementView(advertView);
        }
    }
}
