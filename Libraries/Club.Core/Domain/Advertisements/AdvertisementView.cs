using System;

namespace Club.Core.Domain.Advertisements
{
    public partial class AdvertisementView : BaseEntity
    {
        public int AdvertisementId { get; set; }
        public string IPAddress { get; set; }
        public DateTime ViewOnUtc { get; set; }
        public virtual Advertisement Advertisement { get; set; }
    }
}
