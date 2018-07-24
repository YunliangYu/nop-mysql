using Club.Core.Domain.Advertisements;
namespace Club.Data.Mapping.Advertisements
{
    public partial class PlatformMap : SiteEntityTypeConfiguration<Platform>
    {
        public PlatformMap()
        {
            this.ToTable("Platform");
            this.HasKey(pf => pf.Id);
            this.Property(pf => pf.Name).IsRequired().HasMaxLength(400);
        }
    }
}
