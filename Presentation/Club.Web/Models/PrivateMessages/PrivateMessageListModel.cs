using System.Collections.Generic;
using Club.Web.Models.Common;

namespace Club.Web.Models.PrivateMessages
{
    public partial class PrivateMessageListModel
    {
        public IList<PrivateMessageModel> Messages { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}