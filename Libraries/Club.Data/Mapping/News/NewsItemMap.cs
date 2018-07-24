using Club.Core.Domain.News;

namespace Club.Data.Mapping.News
{
    public partial class NewsItemMap : SiteEntityTypeConfiguration<NewsItem>
    {
        public NewsItemMap()
        {
            this.ToTable("News");
            this.HasKey(ni => ni.Id);
            this.Property(ni => ni.Title).IsRequired();
            this.Property(ni => ni.Short).IsRequired();
            this.Property(ni => ni.Full).IsRequired();
            this.Property(ni => ni.MetaKeywords).HasMaxLength(400);
            this.Property(ni => ni.MetaTitle).HasMaxLength(400);

            this.HasRequired(ni => ni.Language)
                .WithMany()
                .HasForeignKey(ni => ni.LanguageId).WillCascadeOnDelete(true);

            this.HasMany(n => n.NewsTags)
                .WithMany(pt => pt.News)
                .Map(m => m.ToTable("News_Tags_Mapping"));
        }
    }
}