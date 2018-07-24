using Club.Core.Domain.Advertisements;
namespace Club.Data.Mapping.Advertisements
{
    public partial class AdvertisementPlatformMap : SiteEntityTypeConfiguration<AdvertisementPlatform>
    {
        public AdvertisementPlatformMap()
        {
            this.ToTable("Advert_Platform_Mapping");
            this.HasKey(ap => ap.Id);

            this.HasRequired(ap => ap.Platform)
                .WithMany()
                .HasForeignKey(ap => ap.PlatformId);


            this.HasRequired(ap => ap.Advertisement)
                .WithMany(a => a.AdvertisementPlatforms)
                .HasForeignKey(ap => ap.AdvertisementId);
        }
    }
}
