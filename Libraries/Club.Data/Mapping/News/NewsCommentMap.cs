using Club.Core.Domain.News;

namespace Club.Data.Mapping.News
{
    public partial class NewsCommentMap : SiteEntityTypeConfiguration<NewsComment>
    {
        public NewsCommentMap()
        {
            this.ToTable("NewsComment");
            this.HasKey(comment => comment.Id);

            this.HasRequired(comment => comment.NewsItem)
                .WithMany(news => news.NewsComments)
                .HasForeignKey(comment => comment.NewsItemId);

            this.HasRequired(comment => comment.Customer)
                .WithMany()
                .HasForeignKey(comment => comment.CustomerId);

            this.HasRequired(comment => comment.Store)
                .WithMany()
                .HasForeignKey(comment => comment.StoreId);
        }
    }
}