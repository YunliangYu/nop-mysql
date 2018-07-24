using System;

namespace Club.Core.Domain.Advertisements
{
    public partial class Platform : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public int DisplayOrder { get; set; }
    }
}
