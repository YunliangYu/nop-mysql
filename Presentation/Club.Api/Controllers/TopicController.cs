using Club.Services.Topics;
using Club.Web.Framework.Controllers;
using System;
using System.Net.Http;
using System.Web.Http;
using Club.Web.Extensions;
using Club.Core;
using System.Web;
using Club.Services.Localization;

namespace Club.Web.Controllers.API
{
    [AllowAnonymous]
    public class TopicController : BaseApiController
    {
        private readonly ITopicService _topicService;
        private readonly IWebHelper _webHelper;
        private readonly HttpContextBase _httpContext;
        private readonly ILocalizationService _localizationService;

        public TopicController(ITopicService topicService, IWebHelper webHelper, HttpContextBase httpContext, ILocalizationService localizationService)
        {
            this._topicService = topicService;
            this._webHelper = webHelper;
            this._httpContext = httpContext;
            this._localizationService = localizationService;
        }

        [HttpGet]
        [ActionName("GetTopic")]
        public HttpResponseMessage GetTopic(string systemName)
        {
            var language = GetLanguageId(_httpContext);
            try
            {
                var topic = _topicService.GetTopicBySystemName(systemName);
                if (topic == null)
                    return ReturnResult(string.Empty, 1, "读取失败");
                var result = new
                {
                    Title = topic.GetLocalized(x => x.Title, language),
                    Fulldescription = topic.GetLocalized(x=> x.Body, language).ConvertImageTakeHost(_webHelper.GetStoreLocation())
                };
                return ReturnResult(result, 0, "");
            }
            catch (Exception ex)
            {
                LogException(ex);
                return ReturnResult(string.Empty, 1, "读取失败");
            }
        }
    }
}
