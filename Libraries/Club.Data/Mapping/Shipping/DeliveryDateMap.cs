using Club.Core.Domain.Shipping;

namespace Club.Data.Mapping.Shipping
{
    public class DeliveryDateMap : SiteEntityTypeConfiguration<DeliveryDate>
    {
        public DeliveryDateMap()
        {
            this.ToTable("DeliveryDate");
            this.HasKey(dd => dd.Id);
            this.Property(dd => dd.Name).IsRequired().HasMaxLength(400);
        }
    }
}
