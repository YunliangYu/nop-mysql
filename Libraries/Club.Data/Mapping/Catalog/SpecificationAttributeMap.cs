using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class SpecificationAttributeMap : SiteEntityTypeConfiguration<SpecificationAttribute>
    {
        public SpecificationAttributeMap()
        {
            this.ToTable("SpecificationAttribute");
            this.HasKey(sa => sa.Id);
            this.Property(sa => sa.Name).IsRequired();
        }
    }
}