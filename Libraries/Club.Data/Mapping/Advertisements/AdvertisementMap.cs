using Club.Core.Domain.Advertisements;

namespace Club.Data.Mapping.Advertisements
{
    public partial class AdvertisementMap : SiteEntityTypeConfiguration<Advertisement>
    {
        public AdvertisementMap()
        {
            this.ToTable("Advertisement");
            this.HasKey(a => a.Id);
        }
    }
}
