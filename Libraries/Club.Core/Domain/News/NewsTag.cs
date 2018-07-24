using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Core.Domain.News
{
    public partial class NewsTag : BaseEntity
    {
        private ICollection<NewsItem> _news;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the NewsItem
        /// </summary>
        public virtual ICollection<NewsItem> News
        {
            get { return _news ?? (_news = new List<NewsItem>()); }
            protected set { _news = value; }
        }
    }
}
