using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Boards
{
    public partial class TopicMoveModel : BaseSiteEntityModel
    {
        public TopicMoveModel()
        {
            ForumList = new List<SelectListItem>();
        }

        public int ForumSelected { get; set; }
        public string TopicSeName { get; set; }

        public IEnumerable<SelectListItem> ForumList { get; set; }
    }
}