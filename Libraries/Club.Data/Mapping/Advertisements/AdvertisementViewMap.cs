using Club.Core.Domain.Advertisements;
namespace Club.Data.Mapping.Advertisements
{
    public partial class AdvertisementViewMap : SiteEntityTypeConfiguration<AdvertisementView>
    {
        public AdvertisementViewMap()
        {
            this.ToTable("AdvertisementView");
            this.HasKey(av=>av.Id);
            this.HasRequired(av => av.Advertisement)
                .WithMany(ap => ap.AdvertisementViews)
                .HasForeignKey(ap => ap.AdvertisementId);
        }
    }
}
