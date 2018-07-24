using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Home
{
    public partial class CommonStatisticsModel : BaseSiteModel
    {
        public int NumberOfOrders { get; set; }

        public int NumberOfCustomers { get; set; }

        public int NumberOfPendingReturnRequests { get; set; }

        public int NumberOfLowStockProducts { get; set; }
    }
}