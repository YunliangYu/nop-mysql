using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class BackInStockSubscriptionMap : SiteEntityTypeConfiguration<BackInStockSubscription>
    {
        public BackInStockSubscriptionMap()
        {
            this.ToTable("BackInStockSubscription");
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .WillCascadeOnDelete(true);
            
            this.HasRequired(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .WillCascadeOnDelete(true);
        }
    }
}