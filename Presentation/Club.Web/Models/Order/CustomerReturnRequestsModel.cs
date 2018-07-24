﻿using System;
using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Order
{
    public partial class CustomerReturnRequestsModel : BaseSiteModel
    {
        public CustomerReturnRequestsModel()
        {
            Items = new List<ReturnRequestModel>();
        }

        public IList<ReturnRequestModel> Items { get; set; }

        #region Nested classes
        public partial class ReturnRequestModel : BaseSiteEntityModel
        {
            public string CustomNumber { get; set; }
            public string ReturnRequestStatus { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductSeName { get; set; }
            public int Quantity { get; set; }

            public string ReturnReason { get; set; }
            public string ReturnAction { get; set; }
            public string Comments { get; set; }
            public Guid UploadedFileGuid { get; set; }

            public DateTime CreatedOn { get; set; }
        }
        #endregion
    }
}