using Club.Core.Domain.Customers;

namespace Club.Data.Mapping.Customers
{
    public partial class RewardPointsHistoryMap : SiteEntityTypeConfiguration<RewardPointsHistory>
    {
        public RewardPointsHistoryMap()
        {
            this.ToTable("RewardPointsHistory");
            this.HasKey(rph => rph.Id);

            this.Property(rph => rph.UsedAmount).HasPrecision(18, 4);

            this.HasRequired(rph => rph.Customer)
                .WithMany()
                .HasForeignKey(rph => rph.CustomerId);

            this.HasOptional(rph => rph.UsedWithOrder)
                .WithOptionalDependent(o => o.RedeemedRewardPointsEntry)
                .WillCascadeOnDelete(false);
        }
    }
}