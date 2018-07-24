using Club.Core.Domain.Customers;

namespace Club.Data.Mapping.Customers
{
    public partial class CustomerAttributeMap : SiteEntityTypeConfiguration<CustomerAttribute>
    {
        public CustomerAttributeMap()
        {
            this.ToTable("CustomerAttribute");
            this.HasKey(ca => ca.Id);
            this.Property(ca => ca.Name).IsRequired().HasMaxLength(400);

            this.Ignore(ca => ca.AttributeControlType);
        }
    }
}