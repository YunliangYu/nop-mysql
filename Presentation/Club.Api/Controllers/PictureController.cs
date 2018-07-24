using Club.Core.Domain.Media;
using Club.Services.Catalog;
using Club.Services.Customers;
using Club.Services.Media;
using Club.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Club.Api.Controllers.WebAPI
{
    [AllowAnonymous]
    public class PictureController : BaseApiController
    {
        private readonly IPictureService _pictureService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly MediaSettings _mediaSettings;

        public PictureController(IPictureService pictureService,
            IProductService productService,
            ICustomerService customerService,
            MediaSettings mediaSettings)
        {
            this._pictureService = pictureService;
            this._productService = productService;
            this._mediaSettings = mediaSettings;
            this._customerService = customerService;
        }
        // GET: api/PictureAPI
        public HttpResponseMessage Get(int productId,int pagenumber,int pagesize)
        {
            if (productId == 0)
            {
                return ReturnResult(string.Empty, 1, "不能提供空的参数值");
            }
            try
            {
                var pictureList = _pictureService.GetPicturesByProductId(productId, 0);
                var result = (from o in pictureList
                              select new
                              {
                                  id = o.Id,
                                  imageurl = _pictureService.GetPictureUrl(o, _mediaSettings.ProductDetailsPictureSize, true),
                              }).Skip(pagenumber * pagesize).Take(pagesize).ToList();
                return ReturnResultList(result, 0, string.Empty);
            }
            catch (Exception ex )
            {
                LogException(ex);
                return ReturnResultList(new List<object>(), 1, "读取数据出现错误");
            }
        }



        //[HttpPost]
        //[ActionName("UploadMultiPicture")]
        //public async Task<HttpResponseMessage> UploadMultiPicture()
        //{
        //    //var streamProvider = new MultipartMemoryStreamProvider();
        //    string root = HttpContext.Current.Server.MapPath("~");
        //    string tmpRoot = root + "/App_Data/image";
        //    var provider = new MultipartFormDataStreamProvider(tmpRoot);

        //    Request.Content.Headers.ContentType.CharSet = "UTF-8";

        //    await Request.Content.ReadAsMultipartAsync(provider);

        //    if (provider.FileData.Count > 8)
        //    {
        //        return ReturnResult("", 1, "对不起，上传的图片不能超过8张");
        //    }
        //    var productId = Convert.ToInt32(provider.FormData.GetValues("productId")[0]);
        //    var customerid = Convert.ToInt32(provider.FormData.GetValues("customerId")[0]);

        //    var customer = _customerService.GetCustomerById(customerid);
        //    if(customer == null)
        //        return ReturnResult("", 1, "对不起，上传发生错误"); 
        //    var product = _productService.GetProductById(Convert.ToInt32(productId));
        //    if (product == null || product.Deleted || !product.Published)
        //        return ReturnResult("", 1, "对不起，此产品不能上传图片");

        //    //notify store owner
        //    if (_catalogSettings.NotifyStoreOwnerAboutNewProductReviews)
        //        _workflowMessageService.SendProductReviewNotificationMessage(productReview, _localizationSettings.DefaultAdminLanguageId);

        //    //activity log
        //    _customerActivityService.InsertActivity("PublicStore.AddProductReview", _localizationService.GetResource("ActivityLog.PublicStore.AddProductReview"), product.Name);

        //    try
        //    {
        //        var pictureList = _pictureService.GetPicturesByProductId(productId, 0);
        //        var result = (from o in pictureList
        //                      select new
        //                      {
        //                          id = o.Id,
        //                          imageurl = _pictureService.GetPictureUrl(o, _mediaSettings.ProductDetailsPictureSize, true),
        //                      }).ToList();
        //        return ReturnResultList(result, 0, string.Empty);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        return ReturnResultList(new List<object>(), 1, "读取数据出现错误");
        //    }
        //}
    }
}
