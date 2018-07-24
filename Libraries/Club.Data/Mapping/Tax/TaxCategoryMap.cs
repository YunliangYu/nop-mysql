using Club.Core.Domain.Tax;

namespace Club.Data.Mapping.Tax
{
    public class TaxCategoryMap : SiteEntityTypeConfiguration<TaxCategory>
    {
        public TaxCategoryMap()
        {
            this.ToTable("TaxCategory");
            this.HasKey(tc => tc.Id);
            this.Property(tc => tc.Name).IsRequired().HasMaxLength(400);
        }
    }
}
