using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class ProductAttributeMap : SiteEntityTypeConfiguration<ProductAttribute>
    {
        public ProductAttributeMap()
        {
            this.ToTable("ProductAttribute");
            this.HasKey(pa => pa.Id);
            this.Property(pa => pa.Name).IsRequired();
        }
    }
}