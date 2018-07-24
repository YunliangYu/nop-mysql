using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Order
{
    public partial class SubmitReturnRequestModel : BaseSiteModel
    {
        public SubmitReturnRequestModel()
        {
            Items = new List<OrderItemModel>();
            AvailableReturnReasons = new List<ReturnRequestReasonModel>();
            AvailableReturnActions= new List<ReturnRequestActionModel>();
        }

        public int OrderId { get; set; }
        public string CustomOrderNumber { get; set; }

        public IList<OrderItemModel> Items { get; set; }
        
        [AllowHtml]
        [SiteResourceDisplayName("ReturnRequests.ReturnReason")]
        public int ReturnRequestReasonId { get; set; }
        public IList<ReturnRequestReasonModel> AvailableReturnReasons { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("ReturnRequests.ReturnAction")]
        public int ReturnRequestActionId { get; set; }
        public IList<ReturnRequestActionModel> AvailableReturnActions { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("ReturnRequests.Comments")]
        public string Comments { get; set; }

        public bool AllowFiles { get; set; }
        [SiteResourceDisplayName("ReturnRequests.UploadedFile")]
        public Guid UploadedFileGuid { get; set; }

        public string Result { get; set; }
        
        #region Nested classes

        public partial class OrderItemModel : BaseSiteEntityModel
        {
            public int ProductId { get; set; }

            public string ProductName { get; set; }

            public string ProductSeName { get; set; }

            public string AttributeInfo { get; set; }

            public string UnitPrice { get; set; }

            public int Quantity { get; set; }
        }

        public partial class ReturnRequestReasonModel : BaseSiteEntityModel
        {
            public string Name { get; set; }
        }
        public partial class ReturnRequestActionModel : BaseSiteEntityModel
        {
            public string Name { get; set; }
        }

        #endregion
    }

}