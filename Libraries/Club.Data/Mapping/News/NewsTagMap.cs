using Club.Core.Domain.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Mapping.News
{
    public partial class NewsTagMap : SiteEntityTypeConfiguration<NewsTag>
    {
        public NewsTagMap()
        {
            this.ToTable("NewsTag");
            this.HasKey(nt => nt.Id);
            this.Property(nt => nt.Name).IsRequired().HasMaxLength(400);
        }
    }
}
