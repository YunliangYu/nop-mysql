using Club.Core.Domain.Customers;

namespace Club.Data.Mapping.Customers
{
    public partial class ExternalAuthenticationRecordMap : SiteEntityTypeConfiguration<ExternalAuthenticationRecord>
    {
        public ExternalAuthenticationRecordMap()
        {
            this.ToTable("ExternalAuthenticationRecord");

            this.HasKey(ear => ear.Id);

            this.HasRequired(ear => ear.Customer)
                .WithMany(c => c.ExternalAuthenticationRecords)
                .HasForeignKey(ear => ear.CustomerId);

        }
    }
}