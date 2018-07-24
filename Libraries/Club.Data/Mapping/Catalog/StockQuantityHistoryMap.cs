using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class StockQuantityHistoryMap : SiteEntityTypeConfiguration<StockQuantityHistory>
    {
        public StockQuantityHistoryMap()
        {
            this.ToTable("StockQuantityHistory");
            this.HasKey(historyEntry => historyEntry.Id);

            this.HasRequired(historyEntry => historyEntry.Product)
                .WithMany()
                .HasForeignKey(historyEntry => historyEntry.ProductId)
                .WillCascadeOnDelete(true);
        }
    }
}