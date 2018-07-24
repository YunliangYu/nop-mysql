using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class CategoryTemplateMap : SiteEntityTypeConfiguration<CategoryTemplate>
    {
        public CategoryTemplateMap()
        {
            this.ToTable("CategoryTemplate");
            this.HasKey(p => p.Id);
            this.Property(p => p.Name).IsRequired().HasMaxLength(400);
            this.Property(p => p.ViewPath).IsRequired().HasMaxLength(400);
        }
    }
}