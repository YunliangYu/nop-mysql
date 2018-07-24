using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class ProductWarehouseInventoryMap : SiteEntityTypeConfiguration<ProductWarehouseInventory>
    {
        public ProductWarehouseInventoryMap()
        {
            this.ToTable("ProductWarehouseInventory");
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.Product)
                .WithMany(p => p.ProductWarehouseInventory)
                .HasForeignKey(x => x.ProductId)
                .WillCascadeOnDelete(true);

            this.HasRequired(x => x.Warehouse)
                .WithMany()
                .HasForeignKey(x => x.WarehouseId)
                .WillCascadeOnDelete(true);
        }
    }
}