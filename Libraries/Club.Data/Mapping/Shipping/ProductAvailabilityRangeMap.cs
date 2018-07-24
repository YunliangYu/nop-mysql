using Club.Core.Domain.Shipping;

namespace Club.Data.Mapping.Shipping
{
    public class ProductAvailabilityRangeMap : SiteEntityTypeConfiguration<ProductAvailabilityRange>
    {
        public ProductAvailabilityRangeMap()
        {
            this.ToTable("ProductAvailabilityRange");
            this.HasKey(range => range.Id);
            this.Property(range => range.Name).IsRequired().HasMaxLength(400);
        }
    }
}
