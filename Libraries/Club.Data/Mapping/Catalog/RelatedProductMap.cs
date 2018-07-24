using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class RelatedProductMap : SiteEntityTypeConfiguration<RelatedProduct>
    {
        public RelatedProductMap()
        {
            this.ToTable("RelatedProduct");
            this.HasKey(c => c.Id);
        }
    }
}