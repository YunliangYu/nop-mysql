using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class ProductTagMap : SiteEntityTypeConfiguration<ProductTag>
    {
        public ProductTagMap()
        {
            this.ToTable("ProductTag");
            this.HasKey(pt => pt.Id);
            this.Property(pt => pt.Name).IsRequired().HasMaxLength(400);
        }
    }
}