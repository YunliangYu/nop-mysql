using Club.Core.Domain.Orders;

namespace Club.Data.Mapping.Orders
{
    public partial class ReturnRequestMap : SiteEntityTypeConfiguration<ReturnRequest>
    {
        public ReturnRequestMap()
        {
            this.ToTable("ReturnRequest");
            this.HasKey(rr => rr.Id);
            this.Property(rr => rr.ReasonForReturn).IsRequired();
            this.Property(rr => rr.RequestedAction).IsRequired();

            this.Ignore(rr => rr.ReturnRequestStatus);

            this.HasRequired(rr => rr.Customer)
                .WithMany(c => c.ReturnRequests)
                .HasForeignKey(rr => rr.CustomerId);
        }
    }
}