namespace Club.Core.Domain.Advertisements
{
    public partial class AdvertisementPlatform : BaseEntity
    {
        public int AdvertisementId { get; set; }
        public int PlatformId { get; set; }
        public virtual Advertisement Advertisement { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
