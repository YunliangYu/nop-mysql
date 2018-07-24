using Club.Core;
using Club.Services.Localization;
using Club.Services.Logging;
using Club.Services.Security;
using System;
using System.Linq;
using System.Web.Mvc;
using Club.Admin.Extensions;
using Club.Web.Framework.Kendoui;
using Club.Web.Framework.Controllers;
using Club.Services.Directory;
using Club.Admin.Models.Directory;
using Club.Core.Domain.Directory;

namespace Club.Admin.Controllers
{
    public class CityController  : BaseAdminController
    {
        #region Fields

        private readonly ICityService _cityService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly ILocalizationService _localizationService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IPermissionService _permissionService;
        private readonly IWorkContext _workContext;

		#endregion

		#region Constructors

        public CityController(ICityService cityService,
            IStateProvinceService stateProvinceService,
            ILocalizationService localizationService,
            ICustomerActivityService customerActivityService,
            IPermissionService permissionService,
            IWorkContext workContext)
		{
            this._cityService = cityService;
            this._stateProvinceService = stateProvinceService;
            this._localizationService = localizationService;
            this._customerActivityService = customerActivityService;
            this._permissionService = permissionService;
            this._workContext = workContext;
		}

		#endregion 

        #region Utilities

        [NonAction]
        protected virtual void PrepareAllProvinceModel(CityModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
           
            //model.Provinces.Add(new SelectListItem
            //{
            //    Text = "NA",
            //    Value = "0"
            //});

            var stateProvinces = _stateProvinceService.GetStateProvinces();
            foreach (var p in stateProvinces)
            {
                model.Provinces.Add(new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });
            }
        }

        [NonAction]
        protected CityModel PrepareCityModel(City city)
        {
            var model = city.ToModel();
            return model;
        }

        #endregion

        #region Citys 

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

		public ActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDealersBasic))
                return AccessDeniedView();
            
			return View();
		}

		[HttpPost]
		public ActionResult List(DataSourceRequest command)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDealersBasic))
                return AccessDeniedView();

            var citys = _cityService.GetAllCity(pageIndex: command.Page - 1, pageSize: command.PageSize);
            var gridModel = new DataSourceResult
			{
                Data = citys.Select(PrepareCityModel),
                Total = citys.TotalCount
			};
			return new JsonResult
			{
				Data = gridModel
			};
		}

        public ActionResult Create()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDealersBasic))
                return AccessDeniedView();
            
            var model = new CityModel();
            PrepareAllProvinceModel(model);
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(CityModel model, bool continueEditing)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDealersBasic))
                return AccessDeniedView();
            
            if (ModelState.IsValid)
            {
                var city = model.ToEntity();
                _cityService.InsertCity(city);

                //activity log
                _customerActivityService.InsertActivity("AddNewCity", _localizationService.GetResource("ActivityLog.AddNewCity"), city.Name);

                SuccessNotification(_localizationService.GetResource("Admin.Configuration.Countries.Citys.Added"));
                return continueEditing ? RedirectToAction("Edit", new { id = city.Id }) : RedirectToAction("List");
            }
            PrepareAllProvinceModel(model);
            //If we got this far, something failed, redisplay form
            return View(model);
        }

		public ActionResult Edit(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDealersBasic))
                return AccessDeniedView();
            
            var city = _cityService.GetCityById(id);
            if (city == null)
                //No calendar role found with the specified id
                return RedirectToAction("List");

            var model = PrepareCityModel(city);
            PrepareAllProvinceModel(model);
            return View(model);
		}

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(CityModel model, bool continueEditing)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDealersBasic))
                return AccessDeniedView();
            
            var city = _cityService.GetCityById(model.Id);
            if (city == null)
                //No calendar role found with the specified id
                return RedirectToAction("List");

            try
            {
                if (ModelState.IsValid)
                {
                    city = model.ToEntity(city);
                    _cityService.UpdateCity(city);

                    //activity log
                    _customerActivityService.InsertActivity("EditCity", _localizationService.GetResource("ActivityLog.EditCity"), city.Name);

                    SuccessNotification(_localizationService.GetResource("Admin.Configuration.Countries.Citys.Updated"));
                    return continueEditing ? RedirectToAction("Edit", new { id = city.Id}) : RedirectToAction("List");
                }
                PrepareAllProvinceModel(model);
                //If we got this far, something failed, redisplay form
                return View(model);
            }
            catch (Exception exc)
            {
                ErrorNotification(exc);
                return RedirectToAction("Edit", new { id = city.Id });
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDealersBasic))
                return AccessDeniedView();

            var city = _cityService.GetCityById(id);
            if (city == null)
                //No calendar role found with the specified id
                return RedirectToAction("List");
            try
            {
                _cityService.DeleteCity(city);

                //activity log
                _customerActivityService.InsertActivity("DeleteCity", _localizationService.GetResource("ActivityLog.DeleteCity"), city.Name);

                SuccessNotification(_localizationService.GetResource("Admin.Configuration.Countries.Citys.Deleted"));
                return RedirectToAction("List");
            }
            catch (Exception exc)
            {
                ErrorNotification(exc.Message);
                return RedirectToAction("Edit", new { id = city.Id });
            }
		}

		#endregion
	}
}