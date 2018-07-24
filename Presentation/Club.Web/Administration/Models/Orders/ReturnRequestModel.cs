using System;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Orders;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    [Validator(typeof(ReturnRequestValidator))]
    public partial class ReturnRequestModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.CustomNumber")]
        public string CustomNumber { get; set; }
        
        public int OrderId { get; set; }
        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }

        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.Customer")]
        public int CustomerId { get; set; }
        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.Customer")]
        public string CustomerInfo { get; set; }

        public int ProductId { get; set; }
        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.Product")]
        public string ProductName { get; set; }
        public string AttributeInfo { get; set; }

        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.Quantity")]
        public int Quantity { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.ReasonForReturn")]
        public string ReasonForReturn { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.RequestedAction")]
        public string RequestedAction { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.CustomerComments")]
        public string CustomerComments { get; set; }

        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.UploadedFile")]
        public Guid UploadedFileGuid { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.StaffNotes")]
        public string StaffNotes { get; set; }

        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.Status")]
        public int ReturnRequestStatusId { get; set; }
        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.Status")]
        public string ReturnRequestStatusStr { get; set; }

        [SiteResourceDisplayName("Admin.ReturnRequests.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }
    }
}