using Club.Core.Domain.Shipping;

namespace Club.Data.Mapping.Shipping
{
    public class WarehouseMap : SiteEntityTypeConfiguration<Warehouse>
    {
        public WarehouseMap()
        {
            this.ToTable("Warehouse");
            this.HasKey(wh => wh.Id);
            this.Property(wh => wh.Name).IsRequired().HasMaxLength(400);
        }
    }
}
