using Club.Core.Domain.Common;

namespace Club.Data.Mapping.Common
{
    public partial class SearchTermMap : SiteEntityTypeConfiguration<SearchTerm>
    {
        public SearchTermMap()
        {
            this.ToTable("SearchTerm");
            this.HasKey(st => st.Id);
        }
    }
}
