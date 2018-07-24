using System;
using System.Collections.Generic;

namespace Club.Core.Domain.Advertisements
{
    public partial class Advertisement : BaseEntity
    {
        private ICollection<AdvertisementPlatform> _advertPlatforms;
        private ICollection<AdvertisementView> _adverdViews;

        public int AdvertisementType { get; set; }
        public string Content { get; set; }
        public string LinkUrl { get; set; }
        public string LinkTitle { get; set; }
        public int PictureId { get; set; }
        public int DisplayOrder { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<AdvertisementPlatform> AdvertisementPlatforms
        {
            get { return _advertPlatforms ?? (_advertPlatforms = new List<AdvertisementPlatform>()); }
            protected set { _advertPlatforms = value; }
        }

        public virtual ICollection<AdvertisementView> AdvertisementViews
        {
            get { return _adverdViews ?? (_adverdViews = new List<AdvertisementView>()); }
            protected set { _adverdViews = value; }
        }
    }
}
