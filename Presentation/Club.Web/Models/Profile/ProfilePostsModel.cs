using System.Collections.Generic;
using Club.Web.Models.Common;

namespace Club.Web.Models.Profile
{
    public partial class ProfilePostsModel
    {
        public IList<PostsModel> Posts { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}