using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class CategoryMap : SiteEntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Category");
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired().HasMaxLength(400);
            this.Property(c => c.MetaKeywords).HasMaxLength(400);
            this.Property(c => c.MetaTitle).HasMaxLength(400);
            this.Property(c => c.PriceRanges).HasMaxLength(400);
            this.Property(c => c.PageSizeOptions).HasMaxLength(200);
        }
    }
}