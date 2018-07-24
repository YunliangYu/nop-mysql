using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class CrossSellProductMap : SiteEntityTypeConfiguration<CrossSellProduct>
    {
        public CrossSellProductMap()
        {
            this.ToTable("CrossSellProduct");
            this.HasKey(c => c.Id);
        }
    }
}