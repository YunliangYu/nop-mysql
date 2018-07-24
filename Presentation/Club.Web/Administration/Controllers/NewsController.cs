using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Club.Admin.Extensions;
using Club.Admin.Models.News;
using Club.Core.Domain.Customers;
using Club.Core.Domain.News;
using Club.Services.Events;
using Club.Services.Helpers;
using Club.Services.Localization;
using Club.Services.Logging;
using Club.Services.News;
using Club.Services.Security;
using Club.Services.Seo;
using Club.Services.Stores;
using Club.Web.Framework;
using Club.Web.Framework.Controllers;
using Club.Web.Framework.Kendoui;
using Club.Web.Framework.Mvc;
using System.Text;
using Club.Services.Media;

namespace Club.Admin.Controllers
{
    public partial class NewsController : BaseAdminController
	{
		#region Fields

        private readonly INewsService _newsService;
        private readonly INewsTagService _newsTagService;
        private readonly ILanguageService _languageService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IEventPublisher _eventPublisher;

        private readonly IPictureService _pictureService;
        private readonly IPermissionService _permissionService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IStoreService _storeService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly ICustomerActivityService _customerActivityService;

        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        #endregion

        #region Ctor

        public NewsController(INewsService newsService, 
            INewsTagService newsTagService,
            ILanguageService languageService,
            IDateTimeHelper dateTimeHelper,
            IEventPublisher eventPublisher,
            IPictureService pictureService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            IPermissionService permissionService,
            IUrlRecordService urlRecordService,
            IStoreService storeService, 
            IStoreMappingService storeMappingService,
            ICustomerActivityService customerActivityService)
        {
            this._newsService = newsService;
            this._newsTagService = newsTagService;
            this._languageService = languageService;
            this._dateTimeHelper = dateTimeHelper;
            this._eventPublisher = eventPublisher;
            this._pictureService = pictureService;
            this._localizationService = localizationService;
            this._localizedEntityService = localizedEntityService;
            this._permissionService = permissionService;
            this._urlRecordService = urlRecordService;
            this._storeService = storeService;
            this._storeMappingService = storeMappingService;
            this._customerActivityService = customerActivityService;
        }

        #endregion

        #region Utilities

        [NonAction]
        protected virtual void PrepareLanguagesModel(NewsItemModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var languages = _languageService.GetAllLanguages(true);
            foreach (var language in languages)
            {
                model.AvailableLanguages.Add(new SelectListItem
                {
                    Text = language.Name,
                    Value = language.Id.ToString()
                });
            }
        }

        [NonAction]
        protected virtual void PrepareStoresMappingModel(NewsItemModel model, NewsItem newsItem, bool excludeProperties)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (!excludeProperties && newsItem != null)
                model.SelectedStoreIds = _storeMappingService.GetStoresIdsWithAccess(newsItem).ToList();

            var allStores = _storeService.GetAllStores();
            foreach (var store in allStores)
            {
                model.AvailableStores.Add(new SelectListItem
                {
                    Text = store.Name,
                    Value = store.Id.ToString(),
                    Selected = model.SelectedStoreIds.Contains(store.Id)
                });
            }
        }

        [NonAction]
        protected virtual void SaveStoreMappings(NewsItem newsItem, NewsItemModel model)
        {
            newsItem.LimitedToStores = model.SelectedStoreIds.Any();

            var existingStoreMappings = _storeMappingService.GetStoreMappings(newsItem);
            var allStores = _storeService.GetAllStores();
            foreach (var store in allStores)
            {
                if (model.SelectedStoreIds.Contains(store.Id))
                {
                    //new store
                    if (existingStoreMappings.Count(sm => sm.StoreId == store.Id) == 0)
                        _storeMappingService.InsertStoreMapping(newsItem, store.Id);
                }
                else
                {
                    //remove store
                    var storeMappingToDelete = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
                    if (storeMappingToDelete != null)
                        _storeMappingService.DeleteStoreMapping(storeMappingToDelete);
                }
            }
        }

        [NonAction]
        protected virtual string[] ParseNewsTags(string newsTags)
        {
            var result = new List<string>();
            if (!String.IsNullOrWhiteSpace(newsTags))
            {
                string[] values = newsTags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string val1 in values)
                    if (!String.IsNullOrEmpty(val1.Trim()))
                        result.Add(val1.Trim());
            }
            return result.ToArray();
        }

        #endregion

        #region News items

        public virtual ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual ActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var model = new NewsItemListModel();
            //stores
            model.AvailableStores.Add(new SelectListItem { Text = _localizationService.GetResource("Admin.Common.All"), Value = "0" });
            foreach (var s in _storeService.GetAllStores())
                model.AvailableStores.Add(new SelectListItem { Text = s.Name, Value = s.Id.ToString() });

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult List(DataSourceRequest command, NewsItemListModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedKendoGridJson();

            var news = _newsService.GetAllNews(0, model.SearchStoreId, command.Page - 1, command.PageSize, true);
            var gridModel = new DataSourceResult
            {
                Data = news.Select(x =>
                {
                    var m = x.ToModel();
                    //little performance optimization: ensure that "Full" is not returned
                    m.Full = "";
                    if (x.StartDateUtc.HasValue)
                        m.StartDate = _dateTimeHelper.ConvertToUserTime(x.StartDateUtc.Value, DateTimeKind.Utc);
                    if (x.EndDateUtc.HasValue)
                        m.EndDate = _dateTimeHelper.ConvertToUserTime(x.EndDateUtc.Value, DateTimeKind.Utc);
                    m.CreatedOn = _dateTimeHelper.ConvertToUserTime(x.CreatedOnUtc, DateTimeKind.Utc);
                    m.LanguageName = x.Language.Name;
                    m.ApprovedComments = _newsService.GetNewsCommentsCount(x, isApproved: true);
                    m.NotApprovedComments = _newsService.GetNewsCommentsCount(x, isApproved: false);

                    return m;
                }),
                Total = news.TotalCount
            };

            return Json(gridModel);
        }

        public virtual ActionResult Create()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var model = new NewsItemModel();
            //languages
            PrepareLanguagesModel(model);
            //Stores
            PrepareStoresMappingModel(model, null, false);
            //default values
            model.Published = true;
            model.AllowComments = true;
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual ActionResult Create(NewsItemModel model, bool continueEditing)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var newsItem = model.ToEntity();
                newsItem.StartDateUtc = model.StartDate;
                newsItem.EndDateUtc = model.EndDate;
                newsItem.CreatedOnUtc = DateTime.UtcNow;
                _newsService.InsertNews(newsItem);

                //activity log
                _customerActivityService.InsertActivity("AddNewNews", _localizationService.GetResource("ActivityLog.AddNewNews"), newsItem.Id);

                //search engine name
                var seName = newsItem.ValidateSeName(model.SeName, model.Title, true);
                _urlRecordService.SaveSlug(newsItem, seName, newsItem.LanguageId);

                //Stores
                SaveStoreMappings(newsItem, model);
                //tags
                _newsTagService.UpdateNewsTags(newsItem, ParseNewsTags(model.NewsTags));


                SuccessNotification(_localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Added"));

                if (continueEditing)
                {
                    //selected tab
                    SaveSelectedTabName();

                    return RedirectToAction("Edit", new { id = newsItem.Id });
                }
                return RedirectToAction("List");

            }

            //If we got this far, something failed, redisplay form
            PrepareLanguagesModel(model);
            PrepareStoresMappingModel(model, null, true);
            return View(model);
        }

        public virtual ActionResult Edit(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var newsItem = _newsService.GetNewsById(id);
            if (newsItem == null)
                //No news item found with the specified id
                return RedirectToAction("List");

            var model = newsItem.ToModel();
            model.StartDate = newsItem.StartDateUtc;
            model.EndDate = newsItem.EndDateUtc;

            //news tags
            if (newsItem != null)
            {
                var result = new StringBuilder();
                for (int i = 0; i < newsItem.NewsTags.Count; i++)
                {
                    var pt = newsItem.NewsTags.ToList()[i];
                    result.Append(pt.Name);
                    if (i != newsItem.NewsTags.Count - 1)
                        result.Append(", ");
                }
                model.NewsTags = result.ToString();
            }
            //languages
            PrepareLanguagesModel(model);
            //Store
            PrepareStoresMappingModel(model, newsItem, false);
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual ActionResult Edit(NewsItemModel model, bool continueEditing)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var newsItem = _newsService.GetNewsById(model.Id);
            if (newsItem == null)
                //No news item found with the specified id
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                newsItem = model.ToEntity(newsItem);
                newsItem.StartDateUtc = model.StartDate;
                newsItem.EndDateUtc = model.EndDate;
                _newsService.UpdateNews(newsItem);

                //activity log
                _customerActivityService.InsertActivity("EditNews", _localizationService.GetResource("ActivityLog.EditNews"), newsItem.Id);

                //search engine name
                var seName = newsItem.ValidateSeName(model.SeName, model.Title, true);
                _urlRecordService.SaveSlug(newsItem, seName, newsItem.LanguageId);

                //Stores
                SaveStoreMappings(newsItem, model);
                //tags
                _newsTagService.UpdateNewsTags(newsItem, ParseNewsTags(model.NewsTags));


                SuccessNotification(_localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Updated"));

                if (continueEditing)
                {
                    //selected tab
                    SaveSelectedTabName();

                    return RedirectToAction("Edit", new {id = newsItem.Id});
                }
                return RedirectToAction("List");
            }

            //If we got this far, something failed, redisplay form
            PrepareLanguagesModel(model);
            PrepareStoresMappingModel(model, newsItem, true);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Delete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var newsItem = _newsService.GetNewsById(id);
            if (newsItem == null)
                //No news item found with the specified id
                return RedirectToAction("List");

            _newsService.DeleteNews(newsItem);

            //activity log
            _customerActivityService.InsertActivity("DeleteNews", _localizationService.GetResource("ActivityLog.DeleteNews"), newsItem.Id);

            SuccessNotification(_localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Deleted"));
            return RedirectToAction("List");
        }

        #endregion

        #region News tags

        public virtual ActionResult NewsTags()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            return View();
        }

        [HttpPost]
        public virtual ActionResult NewsTags(DataSourceRequest command)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedKendoGridJson();

            var tags = _newsTagService.GetAllNewsTags()
                //order by news count
                .OrderByDescending(x => _newsTagService.GetNewsCount(x.Id, 0))
                .Select(x => new NewsTagModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    NewsCount = _newsTagService.GetNewsCount(x.Id, 0)
                })
                .ToList();

            var gridModel = new DataSourceResult
            {
                Data = tags.PagedForCommand(command),
                Total = tags.Count
            };

            return Json(gridModel);
        }

        [HttpPost]
        public virtual ActionResult NewsTagDelete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var tag = _newsTagService.GetNewsTagById(id);
            if (tag == null)
                throw new ArgumentException("No news tag found with the specified id");
            _newsTagService.DeleteNewsTag(tag);

            return new NullJsonResult();
        }

        //edit
        public virtual ActionResult EditNewsTag(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var newsTag = _newsTagService.GetNewsTagById(id);
            if (newsTag == null)
                //No news tag found with the specified id
                return RedirectToAction("List");

            var model = new NewsTagModel
            {
                Id = newsTag.Id,
                Name = newsTag.Name,
                NewsCount = _newsTagService.GetNewsCount(newsTag.Id, 0)
            };

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult EditNewsTag(string btnId, string formId, NewsTagModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var newsTag = _newsTagService.GetNewsTagById(model.Id);
            if (newsTag == null)
                //No news tag found with the specified id
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                newsTag.Name = model.Name;
                _newsTagService.UpdateNewsTag(newsTag);


                ViewBag.RefreshPage = true;
                ViewBag.btnId = btnId;
                ViewBag.formId = formId;
                return View(model);
            }

            //If we got this far, something failed, redisplay form
            return View(model);
        }

        #endregion

        #region News pictures

        [ValidateInput(false)]
        public virtual ActionResult NewsPictureAdd(int pictureId, int displayOrder,
            string overrideAltAttribute, string overrideTitleAttribute,
            int newsId)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            if (pictureId == 0)
                throw new ArgumentException();

            var news = _newsService.GetNewsById(newsId);
            if (news == null)
                throw new ArgumentException("No news found with the specified id");

            var picture = _pictureService.GetPictureById(pictureId);
            if (picture == null)
                throw new ArgumentException("No picture found with the specified id");

            _pictureService.UpdatePicture(picture.Id,
                _pictureService.LoadPictureBinary(picture),
                picture.MimeType,
                picture.SeoFilename,
                overrideAltAttribute,
                overrideTitleAttribute);

            _pictureService.SetSeoFilename(pictureId, _pictureService.GetPictureSeName(string.Format("{0}_{1}", news.CreatedOnUtc.ToString("yyyyMMddHHmmss"), news.Id)));

            _newsService.InsertNewsPicture(new NewsPicture
            {
                PictureId = pictureId,
                NewsId = newsId,
                DisplayOrder = displayOrder,
            });

            return Json(new { Result = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual ActionResult NewsPictureList(DataSourceRequest command, int newsId)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedKendoGridJson();

            var newsPictures = _newsService.GetNewsPicturesByNewsId(newsId);
            var newsPicturesModel = newsPictures
                .Select(x =>
                {
                    var picture = _pictureService.GetPictureById(x.PictureId);
                    if (picture == null)
                        throw new Exception("Picture cannot be loaded");
                    var m = new NewsItemModel.NewsPictureModel
                    {
                        Id = x.Id,
                        NewsId = x.NewsId,
                        PictureId = x.PictureId,
                        PictureUrl = _pictureService.GetPictureUrl(picture),
                        OverrideAltAttribute = picture.AltAttribute,
                        OverrideTitleAttribute = picture.TitleAttribute,
                        DisplayOrder = x.DisplayOrder
                    };
                    return m;
                })
                .ToList();

            var gridModel = new DataSourceResult
            {
                Data = newsPicturesModel,
                Total = newsPicturesModel.Count
            };

            return Json(gridModel);
        }

        [HttpPost]
        public virtual ActionResult NewsPictureUpdate(NewsItemModel.NewsPictureModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var newsPicture = _newsService.GetNewsPictureById(model.Id);
            if (newsPicture == null)
                throw new ArgumentException("No news picture found with the specified id");

            var picture = _pictureService.GetPictureById(newsPicture.PictureId);
            if (picture == null)
                throw new ArgumentException("No picture found with the specified id");

            _pictureService.UpdatePicture(picture.Id,
                _pictureService.LoadPictureBinary(picture),
                picture.MimeType,
                picture.SeoFilename,
                model.OverrideAltAttribute,
                model.OverrideTitleAttribute);

            newsPicture.DisplayOrder = model.DisplayOrder;
            _newsService.UpdateNewsPicture(newsPicture);

            return new NullJsonResult();
        }

        [HttpPost]
        public virtual ActionResult NewsPictureDelete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var newsPicture = _newsService.GetNewsPictureById(id);
            if (newsPicture == null)
                throw new ArgumentException("No news picture found with the specified id");

            var newsId = newsPicture.NewsId;

            var pictureId = newsPicture.PictureId;
            _newsService.DeleteNewsPicture(newsPicture);

            var picture = _pictureService.GetPictureById(pictureId);
            if (picture == null)
                throw new ArgumentException("No picture found with the specified id");
            _pictureService.DeletePicture(picture);

            return new NullJsonResult();
        }

        #endregion

        #region Comments

        public virtual ActionResult Comments(int? filterByNewsItemId)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            ViewBag.FilterByNewsItemId = filterByNewsItemId;
            var model = new NewsCommentListModel();

            //"approved" property
            //0 - all
            //1 - approved only
            //2 - disapproved only
            model.AvailableApprovedOptions.Add(new SelectListItem { Text = _localizationService.GetResource("Admin.ContentManagement.News.Comments.List.SearchApproved.All"), Value = "0" });
            model.AvailableApprovedOptions.Add(new SelectListItem { Text = _localizationService.GetResource("Admin.ContentManagement.News.Comments.List.SearchApproved.ApprovedOnly"), Value = "1" });
            model.AvailableApprovedOptions.Add(new SelectListItem { Text = _localizationService.GetResource("Admin.ContentManagement.News.Comments.List.SearchApproved.DisapprovedOnly"), Value = "2" });

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Comments(int? filterByNewsItemId, DataSourceRequest command, NewsCommentListModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedKendoGridJson();

            var createdOnFromValue = model.CreatedOnFrom == null ? null
                           : (DateTime?)_dateTimeHelper.ConvertToUtcTime(model.CreatedOnFrom.Value, _dateTimeHelper.CurrentTimeZone);

            var createdOnToValue = model.CreatedOnTo == null ? null
                            : (DateTime?)_dateTimeHelper.ConvertToUtcTime(model.CreatedOnTo.Value, _dateTimeHelper.CurrentTimeZone).AddDays(1);

            bool? approved = null;
            if (model.SearchApprovedId > 0)
                approved = model.SearchApprovedId == 1;

            var comments = _newsService.GetAllComments(0, 0, filterByNewsItemId, approved, createdOnFromValue, createdOnToValue, model.SearchText);

            var storeNames = _storeService.GetAllStores().ToDictionary(store => store.Id, store => store.Name);

            var gridModel = new DataSourceResult
            {
                Data = comments.PagedForCommand(command).Select(newsComment =>
                {
                    var commentModel = new NewsCommentModel();
                    commentModel.Id = newsComment.Id;
                    commentModel.NewsItemId = newsComment.NewsItemId;
                    commentModel.NewsItemTitle = newsComment.NewsItem.Title;
                    commentModel.CustomerId = newsComment.CustomerId;
                    var customer = newsComment.Customer;
                    commentModel.CustomerInfo = customer.IsRegistered() ? customer.Email : _localizationService.GetResource("Admin.Customers.Guest");
                    commentModel.CreatedOn = _dateTimeHelper.ConvertToUserTime(newsComment.CreatedOnUtc, DateTimeKind.Utc);
                    commentModel.CommentTitle = newsComment.CommentTitle;
                    commentModel.CommentText = Core.Html.HtmlHelper.FormatText(newsComment.CommentText, false, true, false, false, false, false);
                    commentModel.IsApproved = newsComment.IsApproved;
                    commentModel.StoreId = newsComment.StoreId;
                    commentModel.StoreName = storeNames.ContainsKey(newsComment.StoreId) ? storeNames[newsComment.StoreId] : "Deleted";

                    return commentModel;
                }),
                Total = comments.Count,
            };

            return Json(gridModel);
        }

        [HttpPost]
        public virtual ActionResult CommentUpdate(NewsCommentModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var comment = _newsService.GetNewsCommentById(model.Id);
            if (comment == null)
                throw new ArgumentException("No comment found with the specified id");

            var previousIsApproved = comment.IsApproved;

            comment.IsApproved = model.IsApproved;
            _newsService.UpdateNews(comment.NewsItem);

            //activity log
            _customerActivityService.InsertActivity("EditNewsComment", _localizationService.GetResource("ActivityLog.EditNewsComment"), model.Id);

            //raise event (only if it wasn't approved before and is approved now)
            if (!previousIsApproved && comment.IsApproved)
                _eventPublisher.Publish(new NewsCommentApprovedEvent(comment));

            return new NullJsonResult();
        }

        [HttpPost]
        public virtual ActionResult CommentDelete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            var comment = _newsService.GetNewsCommentById(id);
            if (comment == null)
                throw new ArgumentException("No comment found with the specified id");

            var newsItem = comment.NewsItem;
            _newsService.DeleteNewsComment(comment);

            //activity log
            _customerActivityService.InsertActivity("DeleteNewsComment", _localizationService.GetResource("ActivityLog.DeleteNewsComment"), id);

            return new NullJsonResult();
        }
        
        [HttpPost]
        public virtual ActionResult DeleteSelectedComments(ICollection<int> selectedIds)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            if (selectedIds != null)
            {
                var comments = _newsService.GetNewsCommentsByIds(selectedIds.ToArray());
                var news = _newsService.GetNewsByIds(comments.Select(p => p.NewsItemId).Distinct().ToArray());

                _newsService.DeleteNewsComments(comments);

                //activity log
                foreach (var newsComment in comments)
                {
                    _customerActivityService.InsertActivity("DeleteNewsComment", _localizationService.GetResource("ActivityLog.DeleteNewsComment"), newsComment.Id);
                }
            }

            return Json(new { Result = true });
        }

        [HttpPost]
        public virtual ActionResult ApproveSelected(ICollection<int> selectedIds)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            if (selectedIds != null)
            {
                //filter not approved comments
                var newsComments = _newsService.GetNewsCommentsByIds(selectedIds.ToArray()).Where(comment => !comment.IsApproved);

                foreach (var newsComment in newsComments)
                {
                    newsComment.IsApproved = true;
                    _newsService.UpdateNews(newsComment.NewsItem);
                    
                    //raise event 
                    _eventPublisher.Publish(new NewsCommentApprovedEvent(newsComment));

                    //activity log
                    _customerActivityService.InsertActivity("EditNewsComment", _localizationService.GetResource("ActivityLog.EditNewsComment"), newsComment.Id);
                }
            }

            return Json(new { Result = true });
        }

        [HttpPost]
        public virtual ActionResult DisapproveSelected(ICollection<int> selectedIds)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageNews))
                return AccessDeniedView();

            if (selectedIds != null)
            {
                //filter approved comments
                var newsComments = _newsService.GetNewsCommentsByIds(selectedIds.ToArray()).Where(comment => comment.IsApproved);

                foreach (var newsComment in newsComments)
                {
                    newsComment.IsApproved = false;
                    _newsService.UpdateNews(newsComment.NewsItem);

                    //activity log
                    _customerActivityService.InsertActivity("EditNewsComment", _localizationService.GetResource("ActivityLog.EditNewsComment"), newsComment.Id);
                }
            }

            return Json(new { Result = true });
        }

        #endregion
    }
}
