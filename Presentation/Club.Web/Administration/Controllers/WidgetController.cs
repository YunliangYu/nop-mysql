﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Club.Admin.Extensions;
using Club.Admin.Models.Cms;
using Club.Core.Domain.Cms;
using Club.Core.Plugins;
using Club.Services.Cms;
using Club.Services.Configuration;
using Club.Services.Security;
using Club.Web.Framework.Kendoui;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Controllers
{
    public partial class WidgetController : BaseAdminController
	{
		#region Fields

        private readonly IWidgetService _widgetService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly WidgetSettings _widgetSettings;
	    private readonly IPluginFinder _pluginFinder;

        #endregion

        #region Ctor

        public WidgetController(IWidgetService widgetService,
            IPermissionService permissionService,
            ISettingService settingService,
            WidgetSettings widgetSettings,
            IPluginFinder pluginFinder)
		{
            this._widgetService = widgetService;
            this._permissionService = permissionService;
            this._settingService = settingService;
            this._widgetSettings = widgetSettings;
            this._pluginFinder = pluginFinder;
        }

		#endregion 
        
        #region Methods
        
        public virtual ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual ActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            return View();
        }

        [HttpPost]
        public virtual ActionResult List(DataSourceRequest command)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedKendoGridJson();

            var widgetsModel = new List<WidgetModel>();
            var widgets = _widgetService.LoadAllWidgets();
            foreach (var widget in widgets)
            {
                var tmp1 = widget.ToModel();
                tmp1.IsActive = widget.IsWidgetActive(_widgetSettings);
                widgetsModel.Add(tmp1);
            }
            widgetsModel = widgetsModel.ToList();
            var gridModel = new DataSourceResult
            {
                Data = widgetsModel,
                Total = widgetsModel.Count()
            };

            return Json(gridModel);
        }

        [HttpPost]
        public virtual ActionResult WidgetUpdate([Bind(Exclude = "ConfigurationRouteValues")] WidgetModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var widget = _widgetService.LoadWidgetBySystemName(model.SystemName);
            if (widget.IsWidgetActive(_widgetSettings))
            {
                if (!model.IsActive)
                {
                    //mark as disabled
                    _widgetSettings.ActiveWidgetSystemNames.Remove(widget.PluginDescriptor.SystemName);
                    _settingService.SaveSetting(_widgetSettings);
                }
            }
            else
            {
                if (model.IsActive)
                {
                    //mark as active
                    _widgetSettings.ActiveWidgetSystemNames.Add(widget.PluginDescriptor.SystemName);
                    _settingService.SaveSetting(_widgetSettings);
                }
            }
            var pluginDescriptor = widget.PluginDescriptor;
            //display order
            pluginDescriptor.DisplayOrder = model.DisplayOrder;
            PluginFileParser.SavePluginDescriptionFile(pluginDescriptor);
            //reset plugin cache
            _pluginFinder.ReloadPlugins();

            return new NullJsonResult();
        }
        
        public virtual ActionResult ConfigureWidget(string systemName)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var widget = _widgetService.LoadWidgetBySystemName(systemName);
            if (widget == null)
                //No widget found with the specified id
                return RedirectToAction("List");

            var model = widget.ToModel();
            string actionName, controllerName;
            RouteValueDictionary routeValues;
            widget.GetConfigurationRoute(out actionName, out controllerName, out routeValues);
            model.ConfigurationActionName = actionName;
            model.ConfigurationControllerName = controllerName;
            model.ConfigurationRouteValues = routeValues;
            return View(model);
        }

        [ChildActionOnly]
        public virtual ActionResult WidgetsByZone(string widgetZone)
        {
            //model
            var model = new List<RenderWidgetModel>();

            var widgets = _widgetService.LoadActiveWidgetsByWidgetZone(widgetZone);
            foreach (var widget in widgets)
            {
                var widgetModel = new RenderWidgetModel();

                string actionName;
                string controllerName;
                RouteValueDictionary routeValues;
                widget.GetDisplayWidgetRoute(widgetZone, out actionName, out controllerName, out routeValues);
                widgetModel.ActionName = actionName;
                widgetModel.ControllerName = controllerName;
                widgetModel.RouteValues = routeValues;

                model.Add(widgetModel);
            }

            return PartialView(model);
        }

        #endregion
    }
}
