using System.Collections.Generic;

namespace Club.Web.Models.Boards
{
    public partial class BoardsIndexModel
    {
        public BoardsIndexModel()
        {
            this.ForumGroups = new List<ForumGroupModel>();
        }
        
        public IList<ForumGroupModel> ForumGroups { get; set; }
    }
}